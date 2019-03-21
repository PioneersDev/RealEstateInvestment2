using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Status")]
    public class StatusController : Controller
    {

        private dbContainer _db = new dbContainer();

        /*************************************Status*****************************************/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStatuses()
        {
            var statuses = _db.Statuses.Select(a => new { Id = a.Id, Name = a.Name }).OrderBy(a => a.Id).ToList();
            return Json(new { data = statuses }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var status = _db.Statuses.Find(id);
            return View(status);
        }

        [HttpPost]
        public ActionResult Save(Status Status)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (Status.Id > 0)
                {
                    //Edit
                    var oldStatus = _db.Statuses.Find(Status.Id);
                    if (oldStatus != null)
                    {
                        oldStatus.Name = Status.Name;
                        message = " تم تعديل بيانات الحالة " + Status.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { Status.Id = _db.Statuses.Max(a => a.Id) + 1; } catch { Status.Id = 1; }
                    _db.Statuses.Add(Status);
                    message = " تم اضافة الحالة " + Status.Name + " بنجاح ";
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
            var Status = _db.Statuses.Find(id);
            if (Status != null)
            {
                return View(Status);
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
            var Status = _db.Statuses.Find(id);
            if (Status != null)
            {
                _db.Statuses.Remove(Status);
                _db.SaveChanges();
                status = true;
                message = " تم حذف الحالة " + Status.Name + " بنجاح ";
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