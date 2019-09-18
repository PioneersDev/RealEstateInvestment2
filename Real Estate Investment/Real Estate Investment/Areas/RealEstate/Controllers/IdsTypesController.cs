using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("IdsTypes")]
    public class IdsTypesController : Controller
    {
        private dbContainer _db = new dbContainer();

        /*************************************IdsTypes*****************************************/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetIds()
        {
            var Ids = _db.TypeIds.Select(a => new { Id = a.Id, IdName = a.IdName }).OrderBy(a => a.Id).ToList();
            return Json(new { data = Ids }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var type = _db.TypeIds.Find(id);
            return View(type);
        }

        [HttpPost]
        public ActionResult Save(TypeId type)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (type.Id > 0)
                {
                    //Edit
                    var oldtype = _db.TypeIds.Find(type.Id);
                    if (oldtype != null)
                    {
                        oldtype.IdName = type.IdName;
                        message = " تم تعديل بيانات الهوية " + type.IdName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { type.Id = _db.TypeIds.Max(a => a.Id) + 1; } catch { type.Id = 1; }
                    _db.TypeIds.Add(type);
                    message = " تم اضافة الهوية " + type.IdName + " بنجاح ";
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
            var type = _db.TypeIds.Find(id);
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
            var type = _db.TypeIds.Find(id);
            if (type != null)
            {
                _db.TypeIds.Remove(type);
                _db.SaveChanges();
                status = true;
                message = " تم حذف الهوية " + type.IdName + " بنجاح ";
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