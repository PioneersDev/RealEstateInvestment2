using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Nationalties")]
    public class NationaltiesController : Controller
    {
        private dbContainer _db = new dbContainer();

        /*************************************Nationalties*****************************************/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNationalties()
        {
            var nationalties = _db.Nationalities.Select(a => new { Id = a.Id, NationalityName = a.NationalityName}).OrderBy(a => a.Id).ToList();
            return Json(new { data = nationalties }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var nationalty = _db.Nationalities.Find(id);
            return View(nationalty);
        }

        [HttpPost]
        public ActionResult Save(Nationality nationalty)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (nationalty.Id > 0)
                {
                    //Edit
                    var oldnationalty = _db.Nationalities.Find(nationalty.Id);
                    if (oldnationalty != null)
                    {
                        oldnationalty.NationalityName = nationalty.NationalityName;
                        message = " تم تعديل بيانات الجنسية " + nationalty.NationalityName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { nationalty.Id = _db.Nationalities.Max(a => a.Id) + 1; } catch { nationalty.Id = 1; }
                    _db.Nationalities.Add(nationalty);
                    message = " تم اضافة الجنسية " + nationalty.NationalityName + " بنجاح ";
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
            var nationalty = _db.Nationalities.Find(id);
            if (nationalty != null)
            {
                return View(nationalty);
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
            var nationalty = _db.Nationalities.Find(id);
            if (nationalty != null)
            {
                _db.Nationalities.Remove(nationalty);
                _db.SaveChanges();
                status = true;
                message = " تم حذف الجنسية " + nationalty.NationalityName + " بنجاح ";
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