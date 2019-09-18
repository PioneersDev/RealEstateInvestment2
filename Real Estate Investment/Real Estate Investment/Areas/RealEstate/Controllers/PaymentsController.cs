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
    [CustomAuthorize("Payments")]
    public class PaymentsController : Controller
    {

        private dbContainer _db = new dbContainer();

        /******************************************PymentTypes***********************************************/
        public ActionResult PaymentTypeIndex()
        {
            return View();
        }

        public ActionResult GetPymentTypes()
        {
            var types = _db.PaymentTypes.Select(a => new { Id = a.Id, Name = a.Name, PaymentTypePropertyName = a.PaymentTypeProperty.Name }).OrderBy(a => a.Id).ToList();
            return Json(new { data = types }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SavePymentType(int id)
        {
            var type = _db.PaymentTypes.Find(id);
            ViewBag.PaymentTypeProperties = new SelectList(_db.PaymentTypeProperties.ToList(), "Id", "Name");
            return View(type);
        }

        [HttpPost]
        public ActionResult SavePymentType(PaymentType type)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (type.Id > 0)
                {
                    //Edit
                    var oldtype = _db.PaymentTypes.Find(type.Id);
                    if (oldtype != null)
                    {
                        oldtype.Name = type.Name; oldtype.PaymentTypePropertyId = type.PaymentTypePropertyId;
                        message = " تم تعديل بيانات النوع " + type.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { type.Id = _db.PaymentTypes.Max(a => a.Id) + 1; } catch { type.Id = 1; }
                    _db.PaymentTypes.Add(type);
                    message = " تم اضافة النوع " + type.Name + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeletePymentType(int id)
        {
            var type = _db.PaymentTypes.Include("PaymentTypeProperty").FirstOrDefault(a=>a.Id==id);
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
        [ActionName("DeletePymentType")]
        public ActionResult ConfirmDeletePymentType(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var type = _db.PaymentTypes.Find(id);
            if (type != null)
            {
                _db.PaymentTypes.Remove(type);
                _db.SaveChanges();
                status = true;
                message = " تم حذف النوع " + type.Name + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /************************************Payment Method Header*******************************************/

        public ActionResult PaymentMethodHeaderIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetPaymentMethodHeaders(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var paymentHeaders = _db.PaymentMethodHeaders.Select(a => new PaymentMethodHeaderDTO { Id = a.Id, Name = a.Name, TotalMonthPeriod = a.TotalMonthPeriod }).AsQueryable();
            // Total record count.
            int totalRecords = paymentHeaders.Count();
            // Apply search
            if (id != null)
                paymentHeaders = paymentHeaders.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                paymentHeaders = paymentHeaders.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.Name.ToLower().Contains(search.ToLower()) ||
                p.TotalMonthPeriod.ToString().ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            paymentHeaders = SortPaymentMethodHeadersByColumnWithOrder(order, orderDir, paymentHeaders);
            int recFilter = paymentHeaders.Count();
            // Apply pagination.
            paymentHeaders = paymentHeaders.Skip(startRec).Take(pageSize);
            return Json(new { data = paymentHeaders.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPaymentMethodHeaders()
        {
            var paymentHeaders = _db.PaymentMethodHeaders.Select(a => new PaymentMethodHeader { Id = a.Id, Name = a.Name, TotalMonthPeriod = a.TotalMonthPeriod }).OrderBy(a => a.Id).ToList();
            return Json(new { data = paymentHeaders }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaymentMethodHeaderName(string term)
        {
            List<RealEstateAutoComplete> Names = null;
            Names = _db.PaymentMethodHeaders.Where(a => a.Name.Contains(term)).Select(d => new RealEstateAutoComplete { label = d.Name, value = d.Name, Id = d.Id }).Take(20).ToList();
            return Json(Names, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPaymentMethodHeaderId(string term)
        {
            List<RealEstateAutoComplete> Ids = null;
            Ids = _db.PaymentMethodHeaders.Where(d => d.Id.ToString().StartsWith(term)).Select(d => new RealEstateAutoComplete { label = d.Id.ToString(), value = d.Id.ToString(), Name = d.Name }).Take(20).ToList();
            return Json(Ids, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<PaymentMethodHeaderDTO> SortPaymentMethodHeadersByColumnWithOrder(string order, string orderDir, IQueryable<PaymentMethodHeaderDTO> paymentHeaders)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        paymentHeaders = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? paymentHeaders.OrderByDescending(p => p.Id) : paymentHeaders.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        paymentHeaders = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? paymentHeaders.OrderByDescending(p => p.Name) : paymentHeaders.OrderBy(p => p.Name);
                        break;
                    case "2":
                        // Setting.   
                        paymentHeaders = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? paymentHeaders.OrderByDescending(p => p.TotalMonthPeriod) : paymentHeaders.OrderBy(p => p.TotalMonthPeriod);
                        break;
                    default:
                        // Setting.   
                        paymentHeaders = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? paymentHeaders.OrderByDescending(p => p.Id) : paymentHeaders.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return paymentHeaders;
            }
            return paymentHeaders;
        }

        [HttpGet]
        public ActionResult SavePaymentMethodHeader(int id)
        {
            var paymentHeader = _db.PaymentMethodHeaders.Find(id);
            return View(paymentHeader);
        }

        [HttpPost]
        public ActionResult SavePaymentMethodHeader(PaymentMethodHeader paymentHeader)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (paymentHeader.Id > 0)
                {
                    //Edit
                    var oldpaymentHeader = _db.PaymentMethodHeaders.Find(paymentHeader.Id);
                    if (oldpaymentHeader != null)
                    {
                        oldpaymentHeader.Name = paymentHeader.Name; oldpaymentHeader.TotalMonthPeriod = paymentHeader.TotalMonthPeriod;
                        message = " تم تعديل بيانات نظام الدفع " + paymentHeader.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { paymentHeader.Id = _db.PaymentMethodHeaders.Max(a => a.Id) + 1; } catch { paymentHeader.Id = 1; }
                    _db.PaymentMethodHeaders.Add(paymentHeader);
                    message = " تم اضافة نظام الدفع " + paymentHeader.Name + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeletePaymentMethodHeader(int id)
        {
            var paymentHeader = _db.PaymentMethodHeaders.Find(id);
            if (paymentHeader != null)
            {
                return View(paymentHeader);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeletePaymentMethodHeader")]
        public ActionResult ConfirmDeletePaymentMethodHeader(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var paymentHeader = _db.PaymentMethodHeaders.Find(id);
            if (paymentHeader != null)
            {
                _db.PaymentMethodHeaders.Remove(paymentHeader);
                _db.SaveChanges();
                status = true;
                message = " تم حذف نظام الدفع " + paymentHeader.Name + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /***********************************Payment Method Details*******************************************/

        public ActionResult PaymentMethodDetailIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetPaymentMethodHeaderDetails(int id)
        {
            var HeaderDetails = _db.PaymentMethodDetails.Where(a => a.PaymentMethodHeaderId == id).Select(a => new { Id = a.Id, PaymentTypeName = a.PaymentType.Name, Ratio = a.Ratio, MinimumAmount = a.MinimumAmount, StartFrom = a.StartFrom, Period = a.Period, PaymentsCounts = a.PaymentsCounts }).OrderBy(a => a.Id).ToList();
            return Json(new { data = HeaderDetails }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SavePaymentMethodHeaderDetail(int id, int PaymentMethodHeaderId)
        {
            var PaymentDetail = _db.PaymentMethodDetails.Where(a => a.Id == id && a.PaymentMethodHeaderId == PaymentMethodHeaderId).FirstOrDefault();
            if (id > 0 && PaymentMethodHeaderId > 0)
            {
                ViewBag.PaymentTypes = new SelectList(_db.PaymentTypes.ToList(), "Id", "Name", PaymentDetail.PaymentTypeId);
            }
            else
            {
                PaymentDetail = new PaymentMethodDetail() { PaymentMethodHeaderId = PaymentMethodHeaderId,MinimumAmount=null };
                ViewBag.PaymentTypes = new SelectList(_db.PaymentTypes.ToList(), "Id", "Name");
            }
            ViewBag.TotalMonthPeriod = _db.PaymentMethodHeaders.Find(PaymentMethodHeaderId).TotalMonthPeriod;
            return View(PaymentDetail);
        }

        [HttpPost]
        public ActionResult SavePaymentMethodHeaderDetail(PaymentMethodDetail PaymentDetail)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (PaymentDetail.Id > 0)
                {
                    //Edit
                    var oldPaymentDetail = _db.PaymentMethodDetails.Find(PaymentDetail.Id);
                    if (oldPaymentDetail != null)
                    {
                        oldPaymentDetail.PaymentTypeId = PaymentDetail.PaymentTypeId; oldPaymentDetail.Ratio = PaymentDetail.Ratio; oldPaymentDetail.MinimumAmount = PaymentDetail.MinimumAmount; oldPaymentDetail.StartFrom = PaymentDetail.StartFrom; oldPaymentDetail.Period = PaymentDetail.Period; oldPaymentDetail.PaymentsCounts = PaymentDetail.PaymentsCounts;
                    }
                }
                else
                {
                    //Create
                    try { PaymentDetail.Id = _db.PaymentMethodDetails.Max(a => a.Id) + 1; } catch { PaymentDetail.Id = 1; }
                    _db.PaymentMethodDetails.Add(PaymentDetail);
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult DeletePaymentMethodHeaderDetail(int id)
        {   //please dont forget this view
            var PaymentDetail = _db.PaymentMethodDetails.Find(id);
            _db.Entry(PaymentDetail).Reference(s => s.PaymentType).Load();
            if (PaymentDetail != null)
            {
                return View(PaymentDetail);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeletePaymentMethodHeaderDetail")]
        public ActionResult ConfirmDeletePaymentMethodHeaderDetail(int id)
        {
            bool status = false;
            var PaymentDetail = _db.PaymentMethodDetails.Find(id);
            if (PaymentDetail != null)
            {
                _db.PaymentMethodDetails.Remove(PaymentDetail);
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        /****************************************************************************************************/
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