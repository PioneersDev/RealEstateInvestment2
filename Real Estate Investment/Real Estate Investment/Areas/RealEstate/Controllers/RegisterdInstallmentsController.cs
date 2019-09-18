using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models;
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
    [CustomAuthorize("RegisterdInstallments")]
    public class RegisterdInstallmentsController : Controller
    {
        private dbContainer _db = new dbContainer();

        /******************************************Registerd Contracts***********************************************/

        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetRegisterdInstallments(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var installments = _db.Database.SqlQuery<ufn_GetContractsInstallmentsResultModel>("SELECT * FROM [con].[ufn_GetContractsInstallments] (null)").AsQueryable();
            // Total record count.
            int totalRecords = installments.Count();
            // Apply search
            if (id != null)
                installments = installments.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                installments = installments.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.CustomerId.ToString().ToLower().Contains(search.ToLower()) ||
                p.ContractId.ToString().ToLower().Contains(search.ToLower()) ||
                p.PayDate.ToString().ToLower().Contains(search.ToLower()) ||
                p.TransactionDate.ToString().ToLower().Contains(search.ToLower()) ||
                p.CHEQUEINBOXID.ToString().ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            installments = SortByColumnWithOrder(order, orderDir, installments);
            int recFilter = installments.Count();
            // Apply pagination.
            installments = installments.Skip(startRec).Take(pageSize);
            return Json(new { data = installments.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<ufn_GetContractsInstallmentsResultModel> SortByColumnWithOrder(string order, string orderDir, IQueryable<ufn_GetContractsInstallmentsResultModel> installments)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.Id) : installments.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.ContractId) : installments.OrderBy(p => p.ContractId);
                        break;
                    case "2":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.CustomerId) : installments.OrderBy(p => p.CustomerId);
                        break;
                    case "3":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.Serial) : installments.OrderBy(p => p.Serial);
                        break;
                    case "4":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.PaymentMethodDetailName) : installments.OrderBy(p => p.PaymentMethodDetailName);
                        break;
                    case "5":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.PayDate) : installments.OrderBy(p => p.PayDate);
                        break;
                    case "6":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.PayValue) : installments.OrderBy(p => p.PayValue);
                        break;
                    case "8":
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.TransactionDate) : installments.OrderBy(p => p.TransactionDate);
                        break;
                    default:
                        // Setting.   
                        installments = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? installments.OrderByDescending(p => p.Id) : installments.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return installments;
            }
            return installments;
        }

        [HttpGet]
        public ActionResult PayInstallment(int id)
        {
            PayInstallmentViewModel model = new PayInstallmentViewModel();
            ViewBag.Accounts = new SelectList(_db.Database.SqlQuery<AccountDTO>("SELECT [ACCOUNTID],CONCAT([ACCOUNTID],' ',[ACCOUNTNAMEA])[ACCOUNTNAMEA] FROM [GL_SQUER].[dbo].[ACCOUNT]").ToList(), "ACCOUNTID", "ACCOUNTNAMEA");
            model.Id = id;
            return View(model);
        }

        public JsonResult SearchById(string term)
        {
            var result= _db.Database.SqlQuery<AccountDTO>("SELECT [ACCOUNTID],[ACCOUNTNAMEA] FROM [GL_SQUER].[dbo].[ACCOUNT]").Where(a=>a.ACCOUNTID.ToString().StartsWith(term)).Select(a=>new { ACCOUNTID=a.ACCOUNTID, ACCOUNTNAMEA=a.ACCOUNTNAMEA}).Take(20).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult searchByName(string term, int id)
        {
            var result = _db.Database.SqlQuery<AccountDTO>("SELECT [ACCOUNTID],[ACCOUNTNAMEA] FROM [GL_SQUER].[dbo].[ACCOUNT]").Where(a => a.ACCOUNTNAMEA.ToString().StartsWith(term)).Take(20).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PayInstallment(PayInstallmentViewModel model)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    //Edit
                    var oldinstallment = _db.Installments.Include("Contract.Project").Include("Customer").FirstOrDefault(a=>a.Id==model.Id);
                    if (oldinstallment != null)
                    {
                        decimal sysacc = 0;
                        if (oldinstallment.PayProperty == 2)
                            sysacc = oldinstallment.Contract.Project.MintananceAccount.Value;
                        else
                            sysacc = oldinstallment.Contract.Project.InstallmentAccount.Value;
                        PayRealEstateInstallmentParams param = new PayRealEstateInstallmentParams();
                        param.InstallmentId = oldinstallment.Id;
                        param.TicketId = oldinstallment.TICKETID.Value;
                        param.mULTIPLECHEQUE_TYPE = new List<MULTIPLECHEQUE_TYPE>();
                        param.mULTIPLECHEQUE_TYPE.Add(new MULTIPLECHEQUE_TYPE{ accountid = oldinstallment.Customer.AccountNumber.Value, currid = 1, currrate = 1, remarksa = model.Remarks, remarkse = model.Remarks, ticketdate = oldinstallment.TICKETDATE.Value, SysAccount = sysacc,ACTIONTYPE=null,bankbranch=null,bankname=null,chequeno= oldinstallment.CHEQUENO.Value.ToString(), chequevalue= oldinstallment.PayValue, COMPANYNAME=null,duedate=DateTime.Now,InstallmentId= oldinstallment.Id, LOGINUSER=null,MACHINEIP=null,MACHINENAME=null,USERNAME=null });
                        param.mULTIPLECHEQUE_TYPE.Add(new MULTIPLECHEQUE_TYPE { accountid = 110803, currid = 1, currrate = 1, remarksa = model.Remarks, remarkse = model.Remarks, ticketdate = oldinstallment.TICKETDATE.Value, SysAccount = model.BankAccount, ACTIONTYPE = null, bankbranch = null, bankname = null, chequeno = oldinstallment.CHEQUENO.Value.ToString(), chequevalue = oldinstallment.PayValue, COMPANYNAME = null, duedate = DateTime.Now, InstallmentId = oldinstallment.Id, LOGINUSER = null, MACHINEIP = null, MACHINENAME = null, USERNAME = null });
                        param.CompanyName = "GL_SQUER";
                        try
                        {
                            HttpResponseMessage response = GlobalApiVariables.WebApiClient.PostAsJsonAsync("PayRealEstateInstallment", param).Result;
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var Result = response.Content.ReadAsAsync<CreateJournalEntriesResult>().Result;
                                if (Result.STATUS)
                                {
                                    oldinstallment.IsPaid = true; oldinstallment.TransactionDate = DateTime.Now; oldinstallment.PayNote = model.Remarks;
                                    message = " تم دفع القسط كود " + model.Id + " بنجاح ";
                                    className = "info";
                                }
                                else
                                {
                                    //throw new Exception(" Installment Not Payed Correctly " + Result.MESSAGE);
                                    message = " Installment Not Payed Correctly " + Result.MESSAGE;
                                    className = "error";
                                    status = true;
                                }
                            }
                            else
                            {
                                //throw new Exception("Error in Calling API");
                                message = "Error in Calling API";
                                className = "error";
                                status = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            //throw ex;
                            message = ex.Message;
                            className = "error";
                            status = true;
                        }
                    }
                }
                else
                {
                    return HttpNotFound();
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /***********************************************************************************************************/
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