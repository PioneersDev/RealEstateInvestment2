using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.Areas.RealEstate.Models.ReportModels;
using RealEstateInvestment.Areas.RealEstate.Models.Serializer;
using RealEstateInvestment.Areas.RealEstate.Models.ViewModels;
using RealEstateInvestment.Areas.RealEstate.ReportsDataSet;
using RealEstateInvestment.CLS;
using RealEstateInvestment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tafqeet;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Contracts")]
    public class ContractsController : Controller
    {

        private dbContainer _db = new dbContainer();
        private ApplicationDbContext _context = new ApplicationDbContext();

        /*******************************************Contracts Types**************************************************/

        public ActionResult ContractTypesIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetContractTypes(int? id)
        {
            IQueryable<ContractType> types = null;
            if (id == null)
                types = _db.ContractTypes;
            else
                types = _db.ContractTypes.Where(a => a.Id == id);
            return Json(new { data = types.Select(a => new { Id = a.Id, Name = a.Name }).ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveContractType(int id)
        {
            var type = _db.ContractTypes.Find(id);
            return View(type);
        }

        [HttpPost]
        public ActionResult SaveContractType(ContractType type)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (type.Id > 0)
                {
                    //Edit
                    var oldtype = _db.ContractTypes.Find(type.Id);
                    if (oldtype != null)
                    {
                        oldtype.Name = type.Name;
                        message = " تم تعديل بيانات نوع العقد " + type.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { type.Id = _db.ContractTypes.Max(a => a.Id) + 1; } catch { type.Id = 1; }
                    _db.ContractTypes.Add(type);
                    message = " تم اضافة نوع العقد " + type.Name + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteContractType(int id)
        {
            var type = _db.ContractTypes.Find(id);
            if (type != null)
            {
                return View(type);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteContractType")]
        public ActionResult ConfirmDeleteContractType(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var type = _db.ContractTypes.Find(id);
            if (type != null)
            {
                if (_db.Contracts.Count(a => a.ContractModelId == id) == 0)
                {
                    var models = _db.ContractModels.Where(a => a.ContractTypeId == id).ToList();
                    foreach (var model in models)
                    {
                        var modelItems = _db.ContractItems.Where(a => a.ContractModelId == model.Id).ToList();
                        _db.ContractItems.RemoveRange(modelItems);
                    }
                    _db.ContractModels.RemoveRange(models);
                    _db.ContractTypes.Remove(type);
                    _db.SaveChanges();
                    message = " تم حذف نوع العقد " + type.Name + " بنجاح ";
                }
                else
                {
                    message = " لم يتم حذف نوع العقد " + type.Name + " لوجود عقود تم تكويدها به ";
                }
                status = true;
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /*******************************************Contracts Syses**************************************************/

        public ActionResult ContractSysIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetContractSyses(int? id)
        {
            IQueryable<ContractSys> variables = null;
            if (id == null)
                variables = _db.ContractSyses;
            else
                variables = _db.ContractSyses.Where(a => a.VarId == id);
            return Json(new { data = variables.Select(a => new { a.VarId, a.VarName, a.VarDescription, a.VarType, a.VarValue, a.IsTafqet, a.IsMoney }).ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveContractSys(int id)
        {
            var var = _db.ContractSyses.Find(id);
            PopulateContractSysDropDownList();
            return View(var);
        }

        [HttpPost]
        public ActionResult SaveContractSys(ContractSys var)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (var.VarId > 0)
                {
                    //Edit
                    var oldvar = _db.ContractSyses.Find(var.VarId);
                    if (oldvar != null)
                    {
                        oldvar.VarType = var.VarType; oldvar.VarDescription = var.VarDescription; oldvar.IsTafqet = var.IsTafqet; oldvar.IsMoney = var.IsMoney; oldvar.VarValue = var.VarValue;
                        message = " تم تعديل بيانات المتغير " + var.VarDescription + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { var.VarId = _db.ContractSyses.Max(a => a.VarId) + 1; } catch { var.VarId = 1; }
                    var.VarName = "@" + var.VarId;
                    _db.ContractSyses.Add(var);
                    message = " تم اضافة المتغير " + var.VarDescription + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteContractSys(int id)
        {
            var var = _db.ContractSyses.Find(id);
            if (var != null)
            {
                return View(var);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteContractSys")]
        public ActionResult ConfirmDeleteContractSys(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var var = _db.ContractSyses.Find(id);
            if (var != null)
            {
                _db.ContractSyses.Remove(var);
                _db.SaveChanges();
                status = true;
                message = " تم حذف المتغير " + var.VarDescription + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        private void PopulateContractSysDropDownList(object selectedType = null)
        {
            ViewBag.Types = new SelectList(new List<SelectListItem>
                                            {
                                                new SelectListItem{ Text="مبلغ", Value = "money"},
                                                new SelectListItem{ Text="عدد", Value = "int"},
                                                new SelectListItem{ Text="نسبة", Value = "decimal"},
                                                new SelectListItem{ Text="تاريخ", Value = "datetime"},
                                                new SelectListItem{ Text="نص", Value = "string"},
                                             }, "Value", "Text", selectedType);
        }

        /*******************************************Contracts Models with Items************************************************/

        public ActionResult ContractModelIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetContractModels(int? id)
        {
            IQueryable<ContractModel> models = null;
            if (id == null)
                models = _db.ContractModels;
            else
                models = _db.ContractModels.Where(a => a.Id == id);
            return Json(new { data = models.Select(a => new { Id = a.Id, Name = a.Name, ContractTypeName = a.ContractType.Name }).ToList() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetContractModelsByContractType(int id)
        {
            var models = _db.ContractModels.Where(a => a.ContractTypeId == id);
            return Json(models.Select(a => new { Id = a.Id, Name = a.Name }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveContractModel(int id)
        {
            var model = _db.ContractModels.Find(id);
            if (id > 0)
                PopulateContractModelsDropDownList(model.ContractTypeId);
            else
                PopulateContractModelsDropDownList();
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveContractModel(ContractModel model)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    //Edit
                    var oldmodel = _db.ContractModels.Find(model.Id);
                    if (oldmodel != null)
                    {
                        oldmodel.Name = model.Name; oldmodel.ContractTypeId = model.ContractTypeId;
                        message = " تم تعديل بيانات النموذج " + model.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { model.Id = _db.ContractModels.Max(a => a.Id) + 1; } catch { model.Id = 1; }
                    _db.ContractModels.Add(model);
                    message = " تم اضافة النموذج " + model.Name + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteContractModel(int id)
        {
            var model = _db.ContractModels.Find(id);
            if (model != null)
            {
                _db.Entry(model).Reference(s => s.ContractType).Load();
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteContractModel")]
        public ActionResult ConfirmDeleteContractModel(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var model = _db.ContractModels.Find(id);
            if (model != null)
            {
                if (_db.Contracts.Count(a => a.ContractModelId == id) == 0)
                {
                    var items = _db.ContractItems.Where(a => a.ContractModelId == id).ToList();
                    _db.ContractItems.RemoveRange(items);
                    _db.ContractModels.Remove(model);
                    _db.SaveChanges();
                    message = " تم حذف النموذج " + model.Name + " بنجاح ";
                }
                else
                {
                    message = " لم يتم حذف النموذج " + model.Name + " لوجود عقود تم تكويدها به";
                }
                status = true;
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        private void PopulateContractModelsDropDownList(object selectedContractType = null)
        {
            ViewBag.ContractTypes = new SelectList(_db.ContractTypes.ToList(), "Id", "Name", selectedContractType);
        }

        public ActionResult ContractItemIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetContractItems(int? id)
        {
            IQueryable<ContractItem> items = null;
            if (id == null)
                items = _db.ContractItems;
            else
                items = _db.ContractItems.Where(a => a.ContractModelId == id);
            return Json(new { data = items.Select(a => new { Id = a.Id, ContractItemName = a.ContractItemName, ContractItemString = a.ContractItemString }).ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveContractItem(int id, int ContractModelId)
        {
            var item = _db.ContractItems.FirstOrDefault(a => a.Id == id && a.ContractModelId == ContractModelId);
            return View(item);
        }

        [HttpPost]
        public ActionResult SaveContractItem(ContractItem itme)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (itme.Id > 0)
                {
                    //Edit
                    var olditme = _db.ContractItems.Find(itme.Id);
                    if (olditme != null)
                    {
                        olditme.ContractItemName = itme.ContractItemName; olditme.ContractItemString = itme.ContractItemString;
                        message = " تم تعديل بيانات البند " + itme.ContractItemName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { itme.Id = _db.ContractItems.Max(a => a.Id) + 1; } catch { itme.Id = 1; }
                    _db.ContractItems.Add(itme);
                    message = " تم اضافة البند " + itme.ContractItemName + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }
        public ActionResult GetContractsVariables()
        {
            ContractLogic logic = new ContractLogic();
            ContractWriteViewModel model = new ContractWriteViewModel();
            model.Variables = _db.ContractSyses.ToList();
            model.Variables = logic.GetContractsVariablesList(null, model);
            return Json(model.Variables, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteContractItem(int id)
        {
            var itme = _db.ContractItems.Find(id);
            if (itme != null)
            {
                return View(itme);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteContractItem")]
        public ActionResult ConfirmDeleteContractItem(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var itme = _db.ContractItems.Find(id);
            if (itme != null)
            {
                _db.ContractItems.Remove(itme);
                _db.SaveChanges();
                status = true;
                message = " تم حذف البند " + itme.ContractItemName + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /******************************************Contracts Request***********************************************/

        public ActionResult ContractRequestIndex(int? id)
        {
            ViewBag.id = id;
            var ApproveSystem = _context.ApproveDefinitions.FirstOrDefault(a => a.TableName == "Contract");
            var ApproveSystemFirstStep = _context.ApproveSteps.FirstOrDefault(a => a.ApproveDefinitionId == ApproveSystem.Id && a.ApproveOrder == 1);
            var ApproveSystemFirstStepPendingStatus = _context.StepStatusDefinitions.FirstOrDefault(a => a.ApproveStepId == ApproveSystemFirstStep.Id && a.Binding == true);
            ViewBag.ApproveSystemFirstStep = ApproveSystemFirstStep.Id;
            ViewBag.ApproveSystemFirstStepPendingStatus = ApproveSystemFirstStepPendingStatus.Id;
            return View();
        }

        [HttpPost]
        public ActionResult GetContractsRequests(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var contractsRequests = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (null, null, 1)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, Remarks = a.Remarks, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId }).AsQueryable();
            // Total record count.
            int totalRecords = contractsRequests.Count();
            // Apply search
            if (id != null)
                contractsRequests = contractsRequests.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                contractsRequests = contractsRequests.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.ContractId.ToString().ToLower().Contains(search.ToLower()) ||
                p.ProjectName.ToLower().Contains(search.ToLower()) ||
                p.UnitName.ToLower().Contains(search.ToLower()) ||
                p.CustomerName.ToLower().Contains(search.ToLower()) ||
                p.ContractDate.ToString().ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            contractsRequests = SortContractsRequestsByColumnWithOrder(order, orderDir, contractsRequests);
            int recFilter = contractsRequests.Count();
            // Apply pagination.
            contractsRequests = contractsRequests.Skip(startRec).Take(pageSize);
            return Json(new { data = contractsRequests.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<ContractRequests> SortContractsRequestsByColumnWithOrder(string order, string orderDir, IQueryable<ContractRequests> contractsRequests)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        contractsRequests = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contractsRequests.OrderByDescending(p => p.Id) : contractsRequests.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        contractsRequests = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contractsRequests.OrderByDescending(p => p.ContractId) : contractsRequests.OrderBy(p => p.ContractId);
                        break;
                    case "2":
                        // Setting.   
                        contractsRequests = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contractsRequests.OrderByDescending(p => p.ProjectName) : contractsRequests.OrderBy(p => p.ProjectName);
                        break;
                    case "3":
                        // Setting.   
                        contractsRequests = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contractsRequests.OrderByDescending(p => p.UnitName) : contractsRequests.OrderBy(p => p.UnitName);
                        break;
                    case "4":
                        // Setting.   
                        contractsRequests = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contractsRequests.OrderByDescending(p => p.CustomerName) : contractsRequests.OrderBy(p => p.CustomerName);
                        break;
                    case "5":
                        // Setting.   
                        contractsRequests = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contractsRequests.OrderByDescending(p => p.ContractDate) : contractsRequests.OrderBy(p => p.ContractDate);
                        break;
                    default:
                        // Setting.   
                        contractsRequests = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contractsRequests.OrderByDescending(p => p.Id) : contractsRequests.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return contractsRequests;
            }
            return contractsRequests;
        }

        [HttpGet]
        public ActionResult ContractRequestSave(int id)
        {
            ContractRequestViewModel contractRequest = new ContractRequestViewModel();
            contractRequest.Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId,Remarks=a.Remarks }).FirstOrDefault();
            contractRequest.InstallmentData = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + id + ")").ToList();
            contractRequest.DeliverySpecificationData = _db.Database.SqlQuery<DeliverySpecificationSerializer>("SELECT * FROM[con].[ufn_GetRequestDeliverySpecificationData](" + id + ")").ToList();
            if (id > 0)
            {
                PopulateDropDownList(contractRequest.Request.ProjectId, contractRequest.Request.UnitId, contractRequest.Request.CustomerId, contractRequest.Request.PaymentMethodHeaderId, contractRequest.Request.ContractTypeId, contractRequest.Request.ContractModelId);
            }
            else
            {
                PopulateDropDownList();
            }
            return View(contractRequest);
        }

        [HttpPost]
        public ActionResult ContractRequestSave(ContractRequestViewModel contractRequest)
        {
            bool status = false;
            long ReqId = 0;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                ContractLogic contractLogic = new ContractLogic();
                contractRequest.Request.UserId = User.Identity.GetUserId<int>();
                var ApproveSystem = _context.ApproveDefinitions.FirstOrDefault(a => a.TableName == "Contract");
                var ApproveSystemFirstStep = _context.ApproveSteps.FirstOrDefault(a => a.ApproveDefinitionId == ApproveSystem.Id && a.ApproveOrder == 1);
                var ApproveSystemFirstStepPendingStatus = _context.StepStatusDefinitions.FirstOrDefault(a => a.ApproveStepId == ApproveSystemFirstStep.Id && a.Binding == true);
                if (contractRequest.Request.Id > 0)
                {
                    //Edit
                    var oldRequest = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + contractRequest.Request.Id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId }).FirstOrDefault();
                    if (oldRequest != null)
                    {
                        ReqId = contractLogic.EditContract(contractRequest, ApproveSystem, ApproveSystemFirstStep, ApproveSystemFirstStepPendingStatus);
                        if (ReqId > 0)
                        {
                            message = " تم تعديل الطلب " + ReqId + " بنجاح ";
                            className = "success";
                        }
                        else
                        {
                            message = "لم يتم تعديل الطلب بنجاح ";
                            className = "error";
                        }
                        status = true;
                    }
                }
                else
                {
                    //Create
                    ReqId = contractLogic.AddContract(contractRequest, ApproveSystem, ApproveSystemFirstStep, ApproveSystemFirstStepPendingStatus);
                    if (ReqId > 0)
                    {
                        message = " تم اضافة الطلب " + ReqId + " بنجاح ";
                        className = "success";
                    }
                    else
                    {
                        message = "لم تتم اضافة الطلب بنجاح ";
                        className = "error";
                    }
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        public ActionResult ContractRequestDetails(int id)
        {
            RequestDetailsDTO model = new RequestDetailsDTO();
            model.Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId }).FirstOrDefault();
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

        public ActionResult GetInstallments(int id)
        {
            var Installments = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + id + ")").ToList();
            return Json(new { data = Installments }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAutomaticInstallments(ContractRequests contractRequest)
        {
            ContractLogic contractLogic = new ContractLogic();
            var Installments = contractLogic.GetInstallmentData(contractRequest);
            return Json(new { data = Installments }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAutomaticInstallmentsView(ContractRequests contractRequest)
        {
            ContractLogic contractLogic = new ContractLogic();
            ContractRequestViewModel vm = new ContractRequestViewModel();
            vm.InstallmentData = contractLogic.GetInstallmentData(contractRequest);
            return View(vm);
        }

        public ActionResult GetAutomaticInstallmentsViewForEdit(int id)
        {
            ContractLogic contractLogic = new ContractLogic();
            ContractRequestViewModel vm = new ContractRequestViewModel();
            vm.InstallmentData = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + id + ")").ToList(); ;
            return View(vm);
        }

        [HttpGet]
        public ActionResult ContractRequestDelete(int id)
        {
            var contractRequest = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId }).FirstOrDefault();
            if (contractRequest != null)
            {
                return View(contractRequest);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("ContractRequestDelete")]
        public ActionResult ContractRequestConfirmDelete(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var Request = _context.Requests.Find(id);
            if (Request != null)
            {
                _context.Requests.Remove(Request);
                _context.SaveChanges();
                status = true;
                message = " تم حذف الطلب رقم " + Request.Id + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        private void PopulateDropDownList(object selectedProject = null, object selectedUnit = null, object selectedCustomer = null, object selectedPaymentMethodHeader = null, object selectedContractType = null, object selectedContractModel = null)
        {
            ViewBag.Projects = new SelectList(_db.Projects.ToList(), "Id", "ProjectName", selectedProject);
            ViewBag.Units = new SelectList(_db.Units.ToList(), "Id", "UnitName", selectedUnit);
            ViewBag.Customers = new SelectList(_db.Customers.ToList(), "Id", "NameArab", selectedCustomer);
            ViewBag.PaymentMethodHeaders = new SelectList(_db.PaymentMethodHeaders.ToList(), "Id", "Name", selectedPaymentMethodHeader);
            ViewBag.ContractTypes = new SelectList(_db.ContractTypes.ToList(), "Id", "Name", selectedContractType);
            if (selectedContractType != null)
                ViewBag.ContractModels = new SelectList(_db.ContractModels.Where(a => a.ContractTypeId == (int)selectedContractType).ToList(), "Id", "Name", selectedContractModel);
            else
                ViewBag.ContractModels = new SelectList(new List<ContractModel> { }, "Id", "Name");
        }

        /*************************************Contract DocHeader Operations*****************************************/
        public ActionResult ContractDocHeaderOperations(int? id)
        {
            var contractRequest = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId }).FirstOrDefault();
            ViewBag.id = id;
            ViewBag.docHeaderId = contractRequest.DocHeaderId;
            ViewBag.step = contractRequest.Step;
            return View();
        }

        public ActionResult ContractDocHeaderWrite(int? id)
        {
            ContractWriteViewModel model = new ContractWriteViewModel();
            model.Id = id.Value;
            model.Variables = _db.ContractSyses.ToList();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ContractDocHeaderWrite(ContractWriteViewModel model)
        {
            ContractLogic contractLogic = new ContractLogic();
            model = contractLogic.SetAllContractData(model);
            ContractRpt rpt = new ContractRpt();
            rpt = contractLogic.SetupContract(model);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Areas/RealEstate/Reports"), "ContractTemplate.rpt"));
            rd.Database.Tables["RptInstallmentData"].SetDataSource(rpt.RptInstallmentData.ListToDataTable());
            rd.Database.Tables["RptDeliverySpecification"].SetDataSource(rpt.RptDeliverySpecification.ListToDataTable());
            rd.Database.Tables["RptContractItem"].SetDataSource(rpt.RptContractItem.ListToDataTable());
            rd.Database.Tables["RptContractRequest"].SetDataSource(rpt.RptContractRequest.ObjectToDataTable());
            rd.Database.Tables["RptProject"].SetDataSource(rpt.RptProject.ObjectToDataTable());
            rd.Database.Tables["RptUnit"].SetDataSource(rpt.RptUnit.ObjectToDataTable());
            rd.Database.Tables["RptCustomer"].SetDataSource(rpt.RptCustomer.ObjectToDataTable());
            rd.Database.Tables["RptProjectOwner"].SetDataSource(rpt.RptProjectOwner.ObjectToDataTable());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/msword", "عقد العميل " + model.ContractRequest.Request.CustomerName + ".doc");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult ContractDocHeaderScan(int? id)
        {
            DocHeaderSubmit doc = new DocHeaderSubmit();
            doc.Id = id.Value;
            return PartialView(doc);
        }

        [HttpPost]
        public ActionResult ContractDocHeaderScanSubmit(DocHeaderSubmit doc)
        {
            bool status = false;
            long ReqId = 0;
            string message = null;
            string className = null;
            try
            {
                ContractLogic contractLogic = new ContractLogic();
                ContractRequestViewModel contractRequest = new ContractRequestViewModel();
                contractRequest.Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + doc.Id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId,ContractModelId=a.ContractModelId,ContractTypeId=a.ContractTypeId,Remarks=a.Remarks }).FirstOrDefault();
                contractRequest.InstallmentData = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + doc.Id + ")").ToList();
                contractRequest.DeliverySpecificationData = _db.Database.SqlQuery<DeliverySpecificationSerializer>("SELECT * FROM[con].[ufn_GetRequestDeliverySpecificationData](" + doc.Id + ")").ToList();
                contractRequest.Request.UserId = User.Identity.GetUserId<int>();
                contractRequest.Request.DocHeaderId = doc.DocHeaderId;
                var ApproveSystem = _context.ApproveDefinitions.FirstOrDefault(a => a.TableName == "Contract");
                var ApproveSystemFirstStep = _context.ApproveSteps.FirstOrDefault(a => a.ApproveDefinitionId == ApproveSystem.Id && a.ApproveOrder == 2);
                var ApproveSystemFirstStepPendingStatus = _context.StepStatusDefinitions.FirstOrDefault(a => a.ApproveStepId == ApproveSystemFirstStep.Id && a.Binding == true);
                ReqId = contractLogic.EditContract(contractRequest, ApproveSystem, ApproveSystemFirstStep, ApproveSystemFirstStepPendingStatus);
                if (ReqId > 0)
                {
                    message = " تم حفظ المستند بنجاح ";
                    className = "success";
                    status = true;
                }
                else
                {
                    message = "لم يتم حفظ المستند بنجاح ";
                    className = "error";
                    status = true;
                }
            }
            catch
            {
                message = "لم يتم حفظ المستند بنجاح ";
                className = "error";
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        public ActionResult ContractDocHeaderReviow(int? id)
        {
            if (id != null)
            {
                return RedirectToAction("DocHeaderReviow", "Documents", new { id = id });
            }
            else
            {
                return HttpNotFound();
            }
        }
        /***********************************************Contract Agreet*********************************************/

        public ActionResult ContractAgreeIndex()
        {
            using (ContractApproveStepLogic logic = new ContractApproveStepLogic(User.Identity.GetUserId<int>()))
            {
                if (logic.IsContractApproveUser())
                {
                    ViewBag.AuthorizedUser = true;
                    ViewBag.Header = logic.GetPageHeader();
                }
                else
                {
                    ViewBag.AuthorizedUser = false;
                    ViewBag.Header = "غير متاح لك التعامل مع هذه الصفحة";
                }
            }
            return View();
        }

        public ActionResult GetData()
        {
            ContractApproveDataTable Table = new ContractApproveDataTable();
            using (ContractApproveStepLogic logic = new ContractApproveStepLogic(User.Identity.GetUserId<int>()))
            {
                IQueryable<ContractRequests> Requests = logic.FilterData();
                Table.data = Requests.ToList().Select(model => new ContractApproveModel(model) { UserSteps = logic.GetUserSteps() }).ToList();
                Table.contractapprovestepcolumns = logic.GetRowsStepColumns(Table.data);
            }
            return Json(Table, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ContractAgreeSave(int id,bool isApprove)
        {
            ContractAgreeViewModel model = new ContractAgreeViewModel();
            model.Id = id;model.IsApprove = isApprove;
            var Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId, ContractModelId = a.ContractModelId, ContractTypeId = a.ContractTypeId, Remarks = a.Remarks }).FirstOrDefault();
            model.Remarks = Request.Remarks;
            return View(model);
        }

        [HttpPost]
        public ActionResult ContractAgreeSave(ContractAgreeViewModel model)
        {
            bool status = false;
            long ReqId = 0;
            string message = null;
            string className = null;
            try
            {
                using (ContractApproveLogic logic = new ContractApproveLogic())
                {
                    ContractRequestViewModel contractRequest = new ContractRequestViewModel();
                    contractRequest.Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + model.Id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId, ContractModelId = a.ContractModelId, ContractTypeId = a.ContractTypeId, Remarks = a.Remarks }).FirstOrDefault();
                    contractRequest.InstallmentData = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + model.Id + ")").ToList();
                    contractRequest.DeliverySpecificationData = _db.Database.SqlQuery<DeliverySpecificationSerializer>("SELECT * FROM[con].[ufn_GetRequestDeliverySpecificationData](" + model.Id + ")").ToList();
                    contractRequest.Request.Remarks = model.Remarks;
                    contractRequest.Request.UserId = User.Identity.GetUserId<int>();
                    ReqId = logic.ChangeContractStatus(contractRequest,model.IsApprove);
                    if (ReqId > 0)
                    {
                        if (model.IsApprove)
                            message = " تمت الموافقة على الطلب";
                        else
                            message = " تمت رفض الطلب";
                        className = "success";
                        status = true;
                    }
                    else
                    {
                        if (model.IsApprove)
                            message = " هناك مشكلة لم تتم الموافقة على الطلب";
                        else
                            message = " هناك مشكلة لم يتم رفض الطلب";
                        className = "error";
                        status = true;
                    }
                }
            }
            catch
            {
                if (model.IsApprove)
                    message = " هناك مشكلة لم تتم الموافقة على الطلب";
                else
                    message = " هناك مشكلة لم يتم رفض الطلب";
                className = "error";
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        public ActionResult ContractAgreeRegisterContract(int id)
        {
            DocHeaderSubmit doc = new DocHeaderSubmit();
            doc.Id = id;
            return PartialView(doc);
        }

        [HttpPost]
        public ActionResult ContractAgreeRegisterContract(DocHeaderSubmit doc)
        {
            bool status = false;
            long ReqId = 0;
            int ContractId = 0;
            string message = null;
            string className = null;
            try
            {
                using (ContractApproveLogic logic = new ContractApproveLogic())
                {
                    ContractRequestViewModel contractRequest = new ContractRequestViewModel();
                    contractRequest.Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + doc.Id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId, ContractModelId = a.ContractModelId, ContractTypeId = a.ContractTypeId, Remarks = a.Remarks }).FirstOrDefault();
                    contractRequest.InstallmentData = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + doc.Id + ")").ToList();
                    contractRequest.DeliverySpecificationData = _db.Database.SqlQuery<DeliverySpecificationSerializer>("SELECT * FROM[con].[ufn_GetRequestDeliverySpecificationData](" + doc.Id + ")").ToList();
                    contractRequest.Request.UserId = User.Identity.GetUserId<int>();
                    contractRequest.Request.DocHeaderId = doc.DocHeaderId;
                    ContractId = logic.RegisterContract(contractRequest);
                    if (ContractId == 0)
                        throw new Exception("Contract Not Registered");
                    else
                    {
                        contractRequest.Request.ContractId = ContractId;
                        ReqId = logic.ChangeContractStatus(contractRequest, true);
                    }
                    if (ReqId > 0)
                    {
                        message = " تم حفظ المستند بنجاح ";
                        className = "success";
                        status = true;
                    }
                    else
                    {
                        message = "لم يتم حفظ المستند بنجاح ";
                        className = "error";
                        status = true;
                    }
                }
            }
            catch
            {
                message = "لم يتم حفظ المستند بنجاح ";
                className = "error";
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
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}