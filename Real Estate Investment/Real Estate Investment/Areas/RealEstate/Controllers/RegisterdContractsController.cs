using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.Areas.RealEstate.Models.Serializer;
using RealEstateInvestment.Areas.RealEstate.Models.ViewModels;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("RegisterdContracts")]
    public class RegisterdContractsController : Controller
    {

        private dbContainer _db = new dbContainer();

        /******************************************Registerd Contracts***********************************************/

        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetRegisterdContracts(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var contracts = _db.Database.SqlQuery<ufn_GetContractsResultModel>("SELECT * FROM [con].[ufn_GetContracts] (null)").AsQueryable();
            // Total record count.
            int totalRecords = contracts.Count();
            // Apply search
            if (id != null)
                contracts = contracts.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                contracts = contracts.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.ProjectName.ToLower().Contains(search.ToLower()) ||
                p.MainUnitName.ToLower().Contains(search.ToLower()) ||
                p.UnitName.ToLower().Contains(search.ToLower()) ||
                p.CustomerName.ToLower().Contains(search.ToLower()) ||
                p.ContractDate.ToString().ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            contracts = SortByColumnWithOrder(order, orderDir, contracts);
            int recFilter = contracts.Count();
            // Apply pagination.
            contracts = contracts.Skip(startRec).Take(pageSize);
            return Json(new { data = contracts.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<ufn_GetContractsResultModel> SortByColumnWithOrder(string order, string orderDir, IQueryable<ufn_GetContractsResultModel> contracts)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.Id) : contracts.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.ProjectName) : contracts.OrderBy(p => p.ProjectName);
                        break;
                    case "2":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.UnitName) : contracts.OrderBy(p => p.UnitName);
                        break;
                    case "3":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.MainUnitName) : contracts.OrderBy(p => p.MainUnitName);
                        break;
                    case "4":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.CustomerName) : contracts.OrderBy(p => p.CustomerName);
                        break;
                    case "5":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.ContractDate) : contracts.OrderBy(p => p.ContractDate);
                        break;
                    default:
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.Id) : contracts.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return contracts;
            }
            return contracts;
        }

        public ActionResult RegisterdContractSaveJournal(int id)
        {
            RequestDetailsDTO model = new RequestDetailsDTO();
            model.id = (int)_db.Contracts.FirstOrDefault(a => a.Id == id).RequestId;
            model.Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId, FirstInstallmentDate = a.FirstInstallmentDate, MarketingCompanyId = a.MarketingCompanyId, MarketingCompanyName = a.MarketingCompanyName, MarketingCompanyPayValue = a.MarketingCompanyPayValue }).FirstOrDefault();
            model.Installments = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + id + ")").ToList();
            model.DeliverySpecificationData = _db.Database.SqlQuery<DeliverySpecificationSerializer>("SELECT * FROM[con].[ufn_GetRequestDeliverySpecificationData](" + id + ")").ToList();
            if (model.Request != null)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("RegisterdContractSaveJournal")]
        public ActionResult RegisterdContractSaveJournalPost(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var contract = _db.Contracts.Include("Project").Include("Unit").Include("Customer").Include("MarketingCompany").FirstOrDefault(a => a.Id == id);
            var MainUnit = _db.Units.FirstOrDefault(a => a.Id == contract.Unit.MainUnitId);
            var Remark = " عقد " + contract.Customer.NameArab + " " + contract.Unit.UnitName + " " + (MainUnit != null ? (MainUnit.UnitName + " ") : "") + contract.Project.ProjectName;
            var Installments = _db.Installments.Include("PaymentMethodDetail").Where(a => a.ContractId == contract.Id && a.PayProperty != 1).ToList();
            var Fpay = _db.Installments.FirstOrDefault(a => a.ContractId == contract.Id && a.PayProperty == 1 && a.JOURNALTYPEID == 5);
            //1-INSERTDAILYJOURNAL
            CreateJournalEntriesParams param = new CreateJournalEntriesParams();
            param.BRANCHID = 1; param.TICKETDATE = contract.ContractDate; param.userdesc = User.Identity.Name;
            param.isallokupdate = 0; param.REMARKSA = Remark; param.REMARKSE = Remark; param.ContractId = contract.Id;
            param.dETAIL_TYPEs = new List<DETAIL_TYPE>();
            param.dETAIL_TYPEs.Add(new DETAIL_TYPE { TRANSTYPE = 1, ACCOUNTID = contract.Customer.AccountNumber.Value, TRANSVALUE = contract.UnitTotalValue, CURRID = 1, CURRRATE = 1, REMARKSA = "مدينية بإجمالي قيمة الوحدة", REMARKSE = "مدينية بإجمالي قيمة الوحدة" });
            param.dETAIL_TYPEs.Add(new DETAIL_TYPE { TRANSTYPE = 2, ACCOUNTID = 210107, TRANSVALUE = contract.UnitTotalValue, CURRID = 1, CURRRATE = 1, REMARKSA = "دائنية باجمإلي قيمة الوحدة", REMARKSE = "دائنية بإجمالي قيمة الوحدة" });
            //دفعة التعاقد
            param.dETAIL_TYPEs.Add(new DETAIL_TYPE { TRANSTYPE = 1, ACCOUNTID = contract.MarketingCompany.AccountNumber.Value, TRANSVALUE = Fpay.PayValue, CURRID = 1, CURRRATE = 1, REMARKSA = "مدينية بدفعة التعاقد ", REMARKSE = "مدينية بدفعة التعاقد " });
            param.dETAIL_TYPEs.Add(new DETAIL_TYPE { TRANSTYPE = 2, ACCOUNTID = contract.Customer.AccountNumber.Value, TRANSVALUE = Fpay.PayValue, CURRID = 1, CURRRATE = 1, REMARKSA = "دائنية بدفعة التعاقد ", REMARKSE = "دائنية بدفعة التعاقد " });
            param.mULTIPLECHEQUE_TYPEs = new List<MULTIPLECHEQUE_TYPE>();
            var ticketdate = contract.ContractDate;
            //الأقساط مفصلة
            var installmentType = string.Empty;
            foreach (var item in Installments)
            {
                installmentType = _db.PaymentTypes.FirstOrDefault(a=>a.Id== item.PaymentMethodDetail.PaymentTypeId).Name;
                if (item.PayProperty == 2 && item.JOURNALTYPEID == 3)
                    //دفعة الصيانة
                    param.mULTIPLECHEQUE_TYPEs.Add(new MULTIPLECHEQUE_TYPE { accountid = contract.Project.MintananceAccount.Value, ACTIONTYPE = "Insert", bankbranch = item.BANKBRANCH, bankname = item.BANKNAME, chequeno = item.CHEQUENO.Value.ToString(), chequevalue = item.PayValue, COMPANYNAME = "GL_SQUARE", currid = 1, currrate = 1, duedate = item.PayDate, InstallmentId = item.Id, LOGINUSER = User.Identity.Name, MACHINEIP = Request.UserHostAddress, MACHINENAME = "", remarksa = " دفعة صيانة " + Remark, remarkse = " دفعة صيانة " + Remark, SysAccount = 15, USERNAME = User.Identity.Name, ticketdate = ticketdate });
                else
                    //أقساط عادية
                    param.mULTIPLECHEQUE_TYPEs.Add(new MULTIPLECHEQUE_TYPE { accountid = contract.Project.InstallmentAccount.Value, ACTIONTYPE = "Insert", bankbranch = item.BANKBRANCH, bankname = item.BANKNAME, chequeno = item.CHEQUENO.Value.ToString(), chequevalue = item.PayValue, COMPANYNAME = "GL_SQUARE", currid = 1, currrate = 1, duedate = item.PayDate, InstallmentId = item.Id, LOGINUSER = User.Identity.Name, MACHINEIP = Request.UserHostAddress, MACHINENAME = "", remarksa = " قسط " + installmentType + Remark, remarkse = " قسط " + installmentType + Remark, SysAccount = 16, USERNAME = User.Identity.Name, ticketdate = ticketdate });
            }
            param.CompanyName = "GL_SQUERLOCAL";

            CustomerQaed custq = new CustomerQaed();

            var response = custq.CreateJournalEntries(param);
            //var response = GlobalApiVariables.WebApiClient.PostAsJsonAsync("CreateJournalEntries", param).Result;
           
             
                if (response.STATUS)
                {
                    message = "تم انشاء قيود العقد بنجاح";
                    className = "success";
                    status = true;
                }
                else
                {
                    //throw new Exception(" Journal Entries Not Added Correctly " + CreateJournalEntriesResult.MESSAGE);
                    message = " Journal Entries Not Added Correctly " + response.MESSAGE;
                    className = "error";
                    status = true;
                }
            
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }
        /********************************************************************************************/
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}