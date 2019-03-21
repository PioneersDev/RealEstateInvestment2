using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Units")]
    public class UnitsController : Controller
    {
        private dbContainer _db = new dbContainer();
        /****************************************Units**************************************/
        public ActionResult Index()
        {
            ViewBag.Projects = new SelectList(_db.Projects.ToList(), "Id", "ProjectName");
            return View();
        }

        public ActionResult GetUnitByProject(int id, string str)
        {
            List<Unit> ParentUnits = null;
            if (str == "null")
            {
                ParentUnits = _db.Units.Where(a => a.ProjectId == id && a.MainUnitId == 0).ToList();
            }
            else
            {
                ParentUnits = _db.Units.Where(a => a.ProjectId == id && a.MainUnitId == 0 && a.UnitName.Contains(str)).ToList();
            }
            ViewBag.ProjectId = id;
            return View(ParentUnits);
        }

        public JsonResult GetSubUnits(int id)
        {
            var SubMenues = _db.Units.Where(a => a.MainUnitId == id).OrderBy(a => a.UnitName).ToList();
            return new JsonResult { Data = SubMenues, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult OpenUnitData(int id, int ProjectId)
        {
            UnitViewModel uvm = new UnitViewModel();
            var currentUnit = _db.Units.Find(id);
            uvm.unit = currentUnit;
            if (id > 0 && ProjectId > 0)
            {
                uvm.isParent = _db.ProjectUnitsTypes.Where(a => a.Id == uvm.unit.ProjectUnitTypeId).Select(a => a.UnitType.IsParent).FirstOrDefault();
                ViewBag.projectUnitTypes = new SelectList(_db.ProjectUnitsTypes.ToList(), "Id", "ProjectUnitTypeName", uvm.unit.ProjectUnitTypeId);
                ViewBag.nullDropDownList = new SelectList(new List<nullableDropDownList> { new nullableDropDownList { Text = "غير محدد", Value = null }, new nullableDropDownList { Text = "نعم", Value = true }, new nullableDropDownList { Text = "لا", Value = false } }, "Value", "Text", uvm.unit.Perecent);
                ViewBag.ParentsUnits = new SelectList(_db.Units.Where(a => a.ProjectId == ProjectId && a.MainUnitId == 0).Select(a => new { Id = a.Id, UnitName = a.UnitName }), "Id", "UnitName", uvm.unit.MainUnitId);
                ViewBag.Statuses = new SelectList(_db.Statuses.ToList(), "Id", "Name", uvm.unit.StatusId);
            }
            else
            {
                uvm.unit = new Unit() { ProjectId = ProjectId };
                ViewBag.projectUnitTypes = new SelectList(_db.ProjectUnitsTypes.ToList(), "Id", "ProjectUnitTypeName");
                ViewBag.nullDropDownList = new SelectList(new List<nullableDropDownList> { new nullableDropDownList { Text = "غير محدد", Value = null }, new nullableDropDownList { Text = "نعم", Value = true }, new nullableDropDownList { Text = "لا", Value = false } }, "Value", "Text");
                ViewBag.ParentsUnits = new SelectList(_db.Units.Where(a => a.ProjectId == ProjectId && a.MainUnitId == 0).Select(a => new { Id = a.Id, UnitName = a.UnitName }), "Id", "UnitName");
                ViewBag.Statuses = new SelectList(_db.Statuses.ToList(), "Id", "Name");
            }
            return View(uvm);
        }

        public ActionResult GetUnitContents(int id)
        {
            var contents = _db.UnitContents.Where(a => a.UnitId == id).Select(a => new { Id = a.Id, ContentName = a.ContentType.ContentName, ContentMeters = a.ContentMeters, ContentCount = a.ContentCount, ContentDetail = a.ContentDetail, UnitId = a.UnitId }).OrderBy(a => a.Id).ToList();
            return Json(new { data = contents }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveUnitContent(int id, int UnitId)
        {
            var uc = _db.UnitContents.Find(id);
            if (id > 0)
            {
                ViewBag.ContentTypes = new SelectList(_db.ContentTypes.ToList(), "Id", "ContentName", uc.ContentTypeId);
            }
            else
            {
                uc = new UnitContent { UnitId = UnitId };
                ViewBag.ContentTypes = new SelectList(_db.ContentTypes.ToList(), "Id", "ContentName", uc.ContentTypeId);
            }
            return View(uc);
        }

        [HttpPost]
        public ActionResult SaveUnitContent(UnitContent uc)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (uc.Id > 0)
                {
                    //Edit
                    var olduc = _db.UnitContents.Find(uc.Id);
                    if (olduc != null)
                    {
                        olduc.ContentTypeId = uc.ContentTypeId; olduc.ContentMeters = uc.ContentMeters; olduc.ContentCount = uc.ContentCount; olduc.ContentDetail = uc.ContentDetail;
                    }
                }
                else
                {
                    //Create
                    try { uc.Id = _db.UnitContents.Max(a => a.Id) + 1; } catch { uc.Id = 1; }
                    _db.UnitContents.Add(uc);
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult DeleteUnitContent(int id)
        {
            var uc = _db.UnitContents.Find(id);
            _db.Entry(uc).Reference(a => a.ContentType).Load();
            if (uc != null)
            {
                return View(uc);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteUnitContent")]
        public ActionResult ConfirmDeleteUnitContent(int id)
        {
            bool status = false;
            var type = _db.UnitContents.Find(id);
            if (type != null)
            {
                _db.UnitContents.Remove(type);
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult SaveUnit(int id, int ProjectId)
        {
            var unit = new Unit() { ProjectId = ProjectId };
            ViewBag.Statuses = new SelectList(_db.Statuses.ToList(), "Id", "Name");
            var subList = _db.UnitTypes.Select(a => a.SubUnitId).ToList();
            ViewBag.projectUnitTypes = new SelectList(_db.ProjectUnitsTypes.Where(a => !subList.Contains(a.UnitTypeId) && a.ProjectId == ProjectId).ToList(), "Id", "ProjectUnitTypeName");
            ViewBag.nullDropDownList = new SelectList(new List<nullableDropDownList> { new nullableDropDownList { Text = "غير محدد", Value = null }, new nullableDropDownList { Text = "نعم", Value = true }, new nullableDropDownList { Text = "لا", Value = false } }, "Value", "Text");
            ViewBag.ParentsUnits = new SelectList(_db.Units.Where(a => a.ProjectId == ProjectId && a.MainUnitId == 0).Select(a => new { Id = a.Id, UnitName = a.UnitName }), "Id", "UnitName");
            return View(unit);
        }

        public ActionResult GetUnitTypesByIsParent(bool isParentUnit, int ProjectId)
        {
            List<ProjectUnitType> result = null;
            var subList = _db.UnitTypes.Select(a => a.SubUnitId).ToList();
            if (isParentUnit == true)
                result = _db.ProjectUnitsTypes.Where(a => !subList.Contains(a.UnitTypeId) && a.ProjectId == ProjectId).ToList();
            else
                result = _db.ProjectUnitsTypes.Where(a => subList.Contains(a.UnitTypeId) && a.ProjectId == ProjectId).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUnitByIsParent(bool isParentUnit, int ProjectId, int? MainUnitId)
        {
            List<UnitDTO> result = null;
            var subList = _db.UnitTypes.Select(a => a.SubUnitId).ToList();
            if (MainUnitId == null)
            {
                if (isParentUnit == true)
                    result = _db.Units.Where(a => !subList.Contains(a.ProjectUnitType.UnitTypeId) && a.ProjectId == ProjectId).Select(a => new UnitDTO { Id = a.Id, UnitName = a.UnitName }).ToList();
                else
                    result = _db.Units.Where(a => subList.Contains(a.ProjectUnitType.UnitTypeId) && a.ProjectId == ProjectId).Select(a => new UnitDTO { Id = a.Id, UnitName = a.UnitName }).ToList();
            }
            else
            {
                if (isParentUnit == true)
                    result = _db.Units.Where(a => !subList.Contains(a.ProjectUnitType.UnitTypeId) && a.ProjectId == ProjectId && a.MainUnitId == MainUnitId).Select(a => new UnitDTO { Id = a.Id, UnitName = a.UnitName }).ToList();
                else
                    result = _db.Units.Where(a => subList.Contains(a.ProjectUnitType.UnitTypeId) && a.ProjectId == ProjectId && a.MainUnitId == MainUnitId).Select(a => new UnitDTO { Id = a.Id, UnitName = a.UnitName }).ToList();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveUnit(UnitViewModel uvm)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (uvm.unit.Id > 0)
                {
                    //Edit
                    var oldunit = _db.Units.Find(uvm.unit.Id);
                    if (oldunit != null)
                    {
                        oldunit.UnitName = uvm.unit.UnitName; oldunit.TotalMeters = uvm.unit.TotalMeters; oldunit.TotalPrice = uvm.unit.TotalPrice; oldunit.NetPrice = uvm.unit.NetPrice; oldunit.Description = uvm.unit.Description; oldunit.Garage = uvm.unit.Garage; oldunit.GarageMetes = uvm.unit.GarageMetes; oldunit.GaragePrice = uvm.unit.GaragePrice; oldunit.Perecent = uvm.unit.Perecent; oldunit.MaintenanceDeposit = uvm.unit.MaintenanceDeposit; oldunit.MainUnitId = uvm.unit.MainUnitId ?? 0; oldunit.ProjectUnitTypeId = uvm.unit.ProjectUnitTypeId;oldunit.MeterPrice = uvm.unit.MeterPrice;oldunit.UnitContractAddress = uvm.unit.UnitContractAddress;oldunit.FloorNumber = uvm.unit.FloorNumber;oldunit.StatusId = uvm.unit.StatusId;oldunit.DocHeaderId = uvm.unit.DocHeaderId;
                    }
                }
                else
                {
                    //Create
                    _db.Units.Add(uvm.unit);
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult AddUnit(Unit unit)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //Create
                UnitLogic unitLogic = new UnitLogic();
                status = unitLogic.AddUnit(unit);
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult DeleteUnit(int id)
        {
            var unit = _db.Units.Find(id);
            _db.Entry(unit).Reference(a => a.ProjectUnitType).Load();
            if (unit != null)
            {
                return View(unit);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteUnit")]
        public ActionResult ConfirmDeleteUnit(int id)
        {
            bool status = false;
            var unit = _db.Units.Find(id);
            if (unit != null)
            {
                //remove unit childs
                var list = _db.Units.Where(a => a.MainUnitId == unit.Id).ToList();
                var contentList = _db.UnitContents.Where(a => a.UnitId == unit.Id);
                _db.UnitContents.RemoveRange(contentList);
                foreach (Unit i in list)
                {
                    var subcontent = _db.UnitContents.Where(a => a.UnitId == i.Id);
                    _db.UnitContents.RemoveRange(subcontent);
                }
                _db.Units.RemoveRange(list);
                _db.Units.Remove(unit);
                bool saveFailed;
                do
                {
                    saveFailed = false;

                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);
                //_db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
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