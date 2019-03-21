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
    [CustomAuthorize("Owners")]
    public class OwnersController : Controller
    {

        private dbContainer _db = new dbContainer();

        /******************************************Owners***********************************************/
        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetOwners(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var owners = _db.Owners.Select(a => new OwnerDTO { Id = a.Id, Name = a.Name,Address=a.Address }).AsQueryable();
            // Total record count.
            int totalRecords = owners.Count();
            // Apply search
            if (id != null)
                owners = owners.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                    owners = owners.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                    p.Name.ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            owners = SortByColumnWithOrder(order, orderDir, owners);
            int recFilter = owners.Count();
            // Apply pagination.
            owners = owners.Skip(startRec).Take(pageSize);
            return Json(new { data = owners.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllOwners()
        {
            var owners = _db.Owners.Select(a => new Owner { Id = a.Id, Name = a.Name }).OrderBy(a => a.Id).ToList();
            return Json(new { data = owners }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOwnerName(string term)
        {
            List<RealEstateAutoComplete> Names = null;
            Names = _db.Owners.Where(a => a.Name.Contains(term)).Select(d => new RealEstateAutoComplete { label = d.Name, value = d.Name, Id = d.Id }).Take(20).ToList();
            return Json(Names, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOwnerId(string term)
        {
            List<RealEstateAutoComplete> Ids = null;
            Ids = _db.Owners.Where(d => d.Id.ToString().StartsWith(term)).Select(d => new RealEstateAutoComplete { label = d.Id.ToString(), value = d.Id.ToString(), Name = d.Name }).Take(20).ToList();
            return Json(Ids, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<OwnerDTO> SortByColumnWithOrder(string order, string orderDir, IQueryable<OwnerDTO> owners)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        owners = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? owners.OrderByDescending(p => p.Id) : owners.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        owners = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? owners.OrderByDescending(p => p.Name) : owners.OrderBy(p => p.Name);
                        break;
                    default:
                        // Setting.   
                        owners = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? owners.OrderByDescending(p => p.Id) : owners.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return owners;
            }
            return owners;
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var owner = _db.Owners.Find(id);
            return View(owner);
        }

        [HttpPost]
        public ActionResult Save(Owner owner)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (owner.Id > 0)
                {
                    //Edit
                    var oldowner = _db.Owners.Find(owner.Id);
                    if (oldowner != null)
                    {
                        oldowner.Name = owner.Name;
                        message = " تم تعديل بيانات المالك " + owner.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { owner.Id = _db.Owners.Max(a => a.Id)+1; } catch { owner.Id = 1; }
                    _db.Owners.Add(owner);
                    message = " تم اضافة المالك " + owner.Name + " بنجاح ";
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
            var owner = _db.Owners.Find(id);
            if (owner != null)
            {
                return View(owner);
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
            var owner = _db.Owners.Find(id);
            if (owner != null)
            {
                _db.Owners.Remove(owner);
                _db.SaveChanges();
                status = true;
                message = " تم حذف المالك " + owner.Name + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }
        /***********************************************************************************************/
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