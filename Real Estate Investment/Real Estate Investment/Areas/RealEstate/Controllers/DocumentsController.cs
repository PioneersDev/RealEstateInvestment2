using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Documents")]
    public class DocumentsController : Controller
    {

        private dbContainer _db = new dbContainer();

        /***************************************DocHeaders*******************************************/
        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetDecHeadersPost(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var headers = _db.DocHeaders.Select(a =>
            new DocHeadersDTO
            {
                Id = a.Id,
                Name = a.Name,
                DocTypeId = a.DocTypeId,
                DocTypeName = a.DocType.Name,
                Notes = a.Notes
            }
            ).AsQueryable();
            // Total record count.
            int totalRecords = headers.Count();
            // Apply search
            if (id != null)
                headers = headers.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                headers = headers.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.Name.ToLower().Contains(search.ToLower()) ||
                p.DocTypeName.ToString().ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            headers = SortHeadersByColumnWithOrder(order, orderDir, headers);
            int recFilter = headers.Count();
            // Apply pagination.
            headers = headers.Skip(startRec).Take(pageSize);
            return Json(new { data = headers.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }
        private IQueryable<DocHeadersDTO> SortHeadersByColumnWithOrder(string order, string orderDir, IQueryable<DocHeadersDTO> headers)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        headers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? headers.OrderByDescending(p => p.Id) : headers.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        headers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? headers.OrderByDescending(p => p.Name) : headers.OrderBy(p => p.Name);
                        break;
                    case "2":
                        // Setting.   
                        headers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? headers.OrderByDescending(p => p.DocTypeName) : headers.OrderBy(p => p.DocTypeName);
                        break;
                    default:
                        // Setting.   
                        headers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? headers.OrderByDescending(p => p.Id) : headers.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return headers;
            }
            return headers;
        }

        [HttpGet]
        public ActionResult SaveDecHeader(int id)
        {
            var header = _db.DocHeaders.Find(id);
            if (id > 0)
            {
                PopulateDocHeaderDropDownList(header.DocTypeId);
            }
            else
            {
                PopulateDocHeaderDropDownList();
            }
            return View(header);
        }

        [HttpPost]
        public ActionResult SaveDecHeader(DocHeader header)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (header.Id > 0)
                {
                    //Edit
                    var oldheader = _db.DocHeaders.Find(header.Id);
                    if (oldheader != null)
                    {
                        oldheader.Name = header.Name; oldheader.DocTypeId = header.DocTypeId; oldheader.Notes = header.Notes;
                        message = " تم تعديل بيانات المستند الرئيسي " + header.Name + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { header.Id = _db.DocHeaders.Max(a => a.Id) + 1; } catch { header.Id = 1; }
                    _db.DocHeaders.Add(header);
                    message = " تم اضافة المستند الرئيسي " + header.Name + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteDecHeader(int id)
        {
            var header = _db.DocHeaders.Find(id);
            if (header != null)
            {
                _db.Entry(header).Reference(s => s.DocType).Load();
                return View(header);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteDecHeader")]
        public ActionResult ConfirmDeleteDecHeader(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var header = _db.DocHeaders.Find(id);
            if (header != null)
            {
                _db.DocHeaders.Remove(header);
                _db.SaveChanges();
                status = true;
                message = " تم حذف المستند الرئيسي " + header.Name + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }
        private void PopulateDocHeaderDropDownList(object selectedDocType = null)
        {
            ViewBag.DocTypes = new SelectList(_db.DocTypes.ToList(), "Id", "Name", selectedDocType);
        }

        public JsonResult IsDocHeaderIdAvailable(int DocHeaderId)
        {
            var IsDocHeeaderIdAvailable = false;
            IsDocHeeaderIdAvailable = _db.DocHeaders.Any(x => x.Id == DocHeaderId);
            if (IsDocHeeaderIdAvailable)
                return Json(_db.DocDetails.Any(x => x.DocHeaderId == DocHeaderId), JsonRequestBehavior.AllowGet);
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDocumentByName(string term)
        {
            List<RealEstateAutoComplete> Names = null;
            Names = _db.DocHeaders.Where(a => a.Name.Contains(term)).Select(d => new RealEstateAutoComplete { label = d.Name, value = d.Name, Id = d.Id }).Take(20).ToList();
            return Json(Names, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDocumentById(string term)
        {
            List<RealEstateAutoComplete> Ids = null;
            Ids = _db.DocHeaders.Where(d => d.Id.ToString().StartsWith(term)).Select(d => new RealEstateAutoComplete { label = d.Id.ToString(), value = d.Id.ToString(), Name = d.Name }).Take(20).ToList();
            return Json(Ids, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DocHeaderReviow(int id)
        {
            var DocHeaderDetails = _db.DocDetails.Where(a => a.DocHeaderId == id).Select(a => new DocDetailDTO { Id = a.Id, Name = a.Name }).OrderBy(a => a.Id).ToList();
            return View(DocHeaderDetails);
        }
        /*******************************************DocDetails********************************************/
        public ActionResult DocHeaderDetails(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetDocHeaderDetails(int id)
        {
            var DocHeaderDetails = _db.DocDetails.Where(a => a.DocHeaderId == id).Select(a => new { Id = a.Id, Name = a.Name }).OrderBy(a => a.Id).ToList();
            return Json(new { data = DocHeaderDetails }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveDocHeaderDetail(int id, int DocHeaderId)
        {
            var DocHeaderDetail = _db.DocDetails.Where(a => a.Id == id && a.DocHeaderId == DocHeaderId).Select(a => new DocDetailDTO { Id = a.Id, DocHeaderId = a.DocHeaderId, Name = a.Name }).FirstOrDefault();
            if (DocHeaderDetail == null)
                DocHeaderDetail = new DocDetailDTO { DocHeaderId = DocHeaderId };
            return View(DocHeaderDetail);
        }

        public async Task<ActionResult> GetDoc(int id)
        {
            DocDetail item = await _db.DocDetails.FindAsync(id);
            byte[] photoBack = item.Doc;
            return File(photoBack, "image/png");
        }

        [HttpPost]
        public ActionResult SaveDocHeaderDetail(DocDetail DocDetail, HttpPostedFileBase uploadFile, HttpPostedFileBase scanFile)
        {
            bool status = false;
            string message = null;
            string className = null;
            MemoryStream memoryStream = new MemoryStream();
            if (uploadFile != null)
                uploadFile.InputStream.CopyTo(memoryStream);
            else
                scanFile.InputStream.CopyTo(memoryStream);
            DocDetail.Doc = memoryStream.ToArray();
            if (DocDetail.Id > 0)
            {
                //Edit
                var oldDocDetail = _db.DocDetails.Find(DocDetail.Id);
                if (oldDocDetail != null)
                {
                     oldDocDetail.Name = DocDetail.Name; oldDocDetail.Doc = DocDetail.Doc;
                    message = " تم تعديل بيانات الصفحة " + DocDetail.Name + " بنجاح ";
                    className = "info";
                }
            }
            else
            {
                //Create
                try { DocDetail.Id = _db.DocDetails.Max(a => a.Id) + 1; } catch { DocDetail.Id = 1; }
                _db.DocDetails.Add(DocDetail);
                message = " تم اضافة الصفحة " + DocDetail.Name + " بنجاح ";
                className = "success";
            }
            _db.SaveChanges();
            status = true;
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        public ActionResult DeleteDocHeaderDetail(int id)
        {
            var DocDetail = _db.DocDetails.Where(a=>a.Id==id).Select(a=>new DocDetailDTO{Id=a.Id,Name=a.Name }).FirstOrDefault();
            if (DocDetail != null)
            {
                return View(DocDetail);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteDocHeaderDetail")]
        public ActionResult ConfirmDeleteDocHeaderDetail(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var DocDetail = _db.DocDetails.Find(id);
            if (DocDetail != null)
            {
                _db.DocDetails.Remove(DocDetail);
                _db.SaveChanges();
                status = true;
                message = " تم حذف الصفحة " + DocDetail.Name + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public async Task<ActionResult> DownloadFile(int id)
        {
            DocDetail docDetail = await _db.DocDetails.FindAsync(id);
            return File(docDetail.Doc, "application/pdf", docDetail.Name);
        }
        /*************************************************************************************************/
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