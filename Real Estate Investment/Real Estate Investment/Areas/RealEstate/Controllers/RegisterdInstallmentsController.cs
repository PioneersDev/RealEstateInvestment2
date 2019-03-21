using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.ViewModels;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
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
                p.CustomerId.ToString().ToLower().Contains(search.ToLower())||
                p.ContractId.ToString().ToLower().Contains(search.ToLower()) ||
                p.PayDate.ToString().ToLower().Contains(search.ToLower()) ||
                p.TransactionDate.ToString().ToLower().Contains(search.ToLower()));
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
            model.Id = id;
            return View(model);
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
                    var oldinstallment = _db.Installments.Find(model.Id);
                    if (oldinstallment != null)
                    {
                        oldinstallment.IsPaid = true; oldinstallment.TransactionDate = DateTime.Now;oldinstallment.RefId = model.RefId; oldinstallment.PayNote = model.Remarks;
                          message = " تم دفع القسط كود " + model.Id + " بنجاح ";
                        className = "info";
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