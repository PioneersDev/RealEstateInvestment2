using Microsoft.AspNet.Identity;
using RealEstateInvestment.Models;
using RealEstateInvestment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();

        /******************************************************************************************/
        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetNotesPost(int? id)
        {
            // Initialization.
            var UserId = User.Identity.GetUserId<int>();
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var notes = _context.UserNotifications.Where(n => n.UserId == UserId).Select(a => new NotificationViewModels { Id = a.Notification.Id, CreatedAt = a.Notification.CreatedAt, MessageText = a.Notification.MessageText, Url = a.Notification.Url, ActorId = a.Notification.ActorId, ActorName = a.Notification.ActorName, Seen = a.Seen, SeenAt = a.SeenAt }).AsQueryable();
            // Total record count.
            int totalRecords = notes.Count();
            // Apply search
            if (id != null)
                notes = notes.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                notes = notes.Where(p => p.CreatedAt.ToString().ToLower().Contains(search.ToLower()) ||
                p.ActorName.ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            notes = SortByColumnWithOrder(order, orderDir, notes);
            int recFilter = notes.Count();
            // Apply pagination.
            notes = notes.Skip(startRec).Take(pageSize);
            return Json(new { data = notes.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<NotificationViewModels> SortByColumnWithOrder(string order, string orderDir, IQueryable<NotificationViewModels> notes)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "1":
                        // Setting.   
                        notes = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? notes.OrderByDescending(p => p.ActorName) : notes.OrderBy(p => p.ActorName);
                        break;
                    case "2":
                        // Setting.   
                        notes = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? notes.OrderByDescending(p => p.CreatedAt) : notes.OrderBy(p => p.CreatedAt);
                        break;
                    default:
                        // Setting.   
                        notes = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? notes.OrderByDescending(p => p.Id) : notes.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return notes;
            }
            return notes;
        }

        public ActionResult GetNotesCount(int id)
        {
            var Count = _context.UserNotifications.Where(n => n.UserId == id && n.Seen == false).Count();
            ViewBag.Count = Count;
            return PartialView();
        }

        public ActionResult GetNotes(int id)
        {
            var UserNotes = _context.UserNotifications.Where(n => n.UserId == id && n.Seen == false).Select(a => new NotificationViewModels { Id = a.Notification.Id, CreatedAt = a.Notification.CreatedAt, MessageText = a.Notification.MessageText, Url = a.Notification.Url, ActorId = a.Notification.ActorId, ActorName = a.Notification.ActorName, Seen = a.Seen, SeenAt = a.SeenAt }).OrderByDescending(a => a.CreatedAt).ToList();
            return PartialView(UserNotes);
        }

        public ActionResult RemoveAlert(int id)
        {
            try
            {
                var UserId = User.Identity.GetUserId<int>();
                var alert = _context.UserNotifications.Where(n => n.UserId == UserId && n.NotificationId == id).FirstOrDefault();
                alert.Seen = true; alert.SeenAt = DateTime.Now;
                _context.Entry(alert).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(data:true,behavior:JsonRequestBehavior.AllowGet);
            }
            catch { return Json(data: false, behavior: JsonRequestBehavior.AllowGet); }
        }

        public ActionResult MarkAllAsReaded()
        {
            var UserId = User.Identity.GetUserId<int>();
            var alerts= _context.UserNotifications.Where(n => n.UserId == UserId && n.Seen==false).ToList();
            foreach(var alert in alerts)
            {
                alert.Seen = true; alert.SeenAt = DateTime.Now;
                _context.Entry(alert).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return View("Index");
        }

        /******************************************************************************************/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}