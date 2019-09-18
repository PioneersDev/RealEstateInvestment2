using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    //[CustomAuthorize("MarketingCompany")]
    public class MarketingCompanyController : Controller
    {
        private dbContainer _db = new dbContainer();

        /*************************************MarketingCompany*****************************************/
        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetCompanies()
        {
            var MarketingCompanys = _db.MarketingCompany.Select(a => new { Id = a.Id, Name = a.Name, MarketingCompanyDelegateName = a.MarketingCompanyDelegateName, Address = a.Address, CompanyPhones = a.CompanyPhones, AccountNumber = a.AccountNumber }).OrderBy(a => a.Id).ToList();
            return Json(new { data = MarketingCompanys }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCompaniesPost(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var MarketingCompanies = _db.MarketingCompany.Select(a => new MarketingCompanyDTO { Id = a.Id, Name = a.Name, AccountNumber = a.AccountNumber, MarketingCompanyDelegateName = a.MarketingCompanyDelegateName, Address = a.Address, CompanyPhones = a.CompanyPhones }).AsQueryable();
            // Total record count.
            int totalRecords = MarketingCompanies.Count();
            // Apply search
            if (id != null)
                MarketingCompanies = MarketingCompanies.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                MarketingCompanies = MarketingCompanies.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.Name.ToLower().Contains(search.ToLower()) ||
                p.AccountNumber.ToString().ToLower().Contains(search.ToLower()) ||
                p.MarketingCompanyDelegateName.ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            MarketingCompanies = SortByColumnWithOrder(order, orderDir, MarketingCompanies);
            int recFilter = MarketingCompanies.Count();
            // Apply pagination.
            MarketingCompanies = MarketingCompanies.Skip(startRec).Take(pageSize);
            return Json(new { data = MarketingCompanies.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<MarketingCompanyDTO> SortByColumnWithOrder(string order, string orderDir, IQueryable<MarketingCompanyDTO> MarketingCompanies)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        MarketingCompanies = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? MarketingCompanies.OrderByDescending(p => p.Id) : MarketingCompanies.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        MarketingCompanies = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? MarketingCompanies.OrderByDescending(p => p.Name) : MarketingCompanies.OrderBy(p => p.Name);
                        break;
                    case "2":
                        // Setting.   
                        MarketingCompanies = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? MarketingCompanies.OrderByDescending(p => p.AccountNumber) : MarketingCompanies.OrderBy(p => p.AccountNumber);
                        break;
                    case "3":
                        // Setting.   
                        MarketingCompanies = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? MarketingCompanies.OrderByDescending(p => p.MarketingCompanyDelegateName) : MarketingCompanies.OrderBy(p => p.MarketingCompanyDelegateName);
                        break;
                    default:
                        // Setting.   
                        MarketingCompanies = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? MarketingCompanies.OrderByDescending(p => p.Id) : MarketingCompanies.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return MarketingCompanies;
            }
            return MarketingCompanies;
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var MarketingCompany = _db.MarketingCompany.Find(id);
            return View(MarketingCompany);
        }

        [HttpPost]
        public ActionResult Save(MarketingCompany MarketingCompany)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (MarketingCompany.Id > 0)
                {
                    //Edit
                    var oldMarketingCompany = _db.MarketingCompany.Find(MarketingCompany.Id);
                    if (oldMarketingCompany != null)
                    {
                        oldMarketingCompany.Name = MarketingCompany.Name; oldMarketingCompany.MarketingCompanyDelegateName = MarketingCompany.MarketingCompanyDelegateName;
                        oldMarketingCompany.Address = MarketingCompany.Address; oldMarketingCompany.CompanyPhones = MarketingCompany.CompanyPhones; oldMarketingCompany.AccountNumber = MarketingCompany.AccountNumber;
                        message = " تم تعديل بيانات الشركة " + MarketingCompany.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { MarketingCompany.Id = _db.MarketingCompany.Max(a => a.Id) + 1; } catch { MarketingCompany.Id = 1; }
                    _db.MarketingCompany.Add(MarketingCompany);
                    message = " تم اضافة الشركة " + MarketingCompany.Name + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var type = _db.MarketingCompany.Find(id);
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
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var MarketingCompany = _db.MarketingCompany.Find(id);
            if (MarketingCompany != null)
            {
                _db.MarketingCompany.Remove(MarketingCompany);
                _db.SaveChanges();
                status = true;
                message = " تم حذف الشركة " + MarketingCompany.Name + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }
        /******************************************************************************************/
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