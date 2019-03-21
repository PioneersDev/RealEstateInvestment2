using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Types")]
    public class TypesController : Controller
    {
        private Models.dbContainer _db = new Models.dbContainer();

        /*************************************UniteType*****************************************/
        public ActionResult UnitTypeIndex()
        {
            return View();
        }

        public ActionResult GetUnitTypes()
        {
            var unitTypes = _db.UnitTypes.Select(a => new { Id = a.Id, UniteTypeName = a.UnitTypeName, IsParent = a.IsParent, SubUnitTypeName = a.SubUnit.UnitTypeName }).OrderBy(a => a.Id).ToList();
            return Json(new { data = unitTypes }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveUnitType(int id)
        {
            var unitType = _db.UnitTypes.Find(id);
            ViewBag.UnitTypes = new SelectList(_db.UnitTypes.Where(a=>a.IsParent==false).ToList(),"Id", "UnitTypeName");
            return View(unitType);
        }

        [HttpPost]
        public ActionResult SaveUnitType(UnitType type)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (type.Id > 0)
                {
                    //Edit
                    var oldtype = _db.UnitTypes.Find(type.Id);
                    if (oldtype != null)
                    {
                        oldtype.UnitTypeName = type.UnitTypeName; oldtype.IsParent = type.IsParent;oldtype.SubUnitId = type.SubUnitId;
                        message = " تم تعديل بيانات النوع " + type.UnitTypeName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { type.Id = _db.UnitTypes.Max(a => a.Id) + 1; } catch { type.Id = 1; }
                    _db.UnitTypes.Add(type);
                    message = " تم اضافة النوع " + type.UnitTypeName + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteUnitType(int id)
        {
            var type = _db.UnitTypes.Find(id);
            _db.Entry(type).Reference(s => s.SubUnit).Load();
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
        [ActionName("DeleteUnitType")]
        public ActionResult ConfirmDeleteUnitType(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var type = _db.UnitTypes.Find(id);
            if (type != null)
            {
                _db.UnitTypes.Remove(type);
                _db.SaveChanges();
                status = true;
                message = " تم حذف النوع " + type.UnitTypeName + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /*************************************ContentType*****************************************/

        public ActionResult ContentTypeIndex()
        {
            return View();
        }

        public ActionResult GetContentTypes()
        {
            var contentTypes = _db.ContentTypes.Select(a => new { Id = a.Id, ContentName = a.ContentName }).OrderBy(a => a.Id).ToList();
            return Json(new { data = contentTypes }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveContentType(int id)
        {
            var ContentType = _db.ContentTypes.Find(id);
            return View(ContentType);
        }

        [HttpPost]
        public ActionResult SaveContentType(ContentType type)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (type.Id > 0)
                {
                    //Edit
                    var oldtype = _db.ContentTypes.Find(type.Id);
                    if (oldtype != null)
                    {
                        oldtype.ContentName = type.ContentName;
                        message = " تم تعديل بيانات النوع " + type.ContentName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { type.Id = _db.ContentTypes.Max(a => a.Id) + 1; } catch { type.Id = 1; }
                    _db.ContentTypes.Add(type);
                    message = " تم اضافة النوع " + type.ContentName + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteContentType(int id)
        {
            var type = _db.ContentTypes.Find(id);
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
        [ActionName("DeleteContentType")]
        public ActionResult ConfirmDeleteContentType(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var type = _db.ContentTypes.Find(id);
            if (type != null)
            {
                _db.ContentTypes.Remove(type);
                _db.SaveChanges();
                status = true;
                message = " تم حذف النوع " + type.ContentName + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /*************************************************************************************/
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