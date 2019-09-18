using AutoMapper;
using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Projects")]
    public class ProjectsController : Controller
    {
        private dbContainer _db = new dbContainer();

        /******************************************Project***********************************************/
        public ActionResult ProjectsIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetProjectsPost(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var projects = _db.ProjectOwners.Select(a =>
            new ProjectDTO
            {
                Id = a.ProjectId,
                ProjectName = a.Project.ProjectName,
                TransmissionDate = a.Project.TransmissionDate,
                ProjectDescription = a.Project.ProjectDescription,
                ProjectContentDetails = a.Project.ProjectContentDetails,
                ProjectOwnerName = a.ProjectOwnerObj.Name,
                MainOwnerName = a.ProjectMainOwnerObj.Name,
                Country = a.Project.Country.CountryName,
                City = a.Project.City.CityName,
                District = a.Project.District.DistrictName,
                Location = a.Project.Location,
                DocHeaderId = a.Project.DocHeaderId,
                MintananceAccount = a.Project.MintananceAccount,
                InstallmentAccount = a.Project.InstallmentAccount
            }
            ).AsQueryable();
            // Total record count.
            int totalRecords = projects.Count();
            // Apply search
            if (id != null)
                projects = projects.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                projects = projects.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.ProjectName.ToLower().Contains(search.ToLower()) ||
                p.TransmissionDate.ToString().ToLower().Contains(search.ToLower()) ||
                p.ProjectOwnerName.ToLower().Contains(search.ToLower()) ||
                p.MainOwnerName.ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            projects = SortProjectsByColumnWithOrder(order, orderDir, projects);
            int recFilter = projects.Count();
            // Apply pagination.
            projects = projects.Skip(startRec).Take(pageSize);
            return Json(new { data = projects.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjects()
        {
            var projects = _db.Projects.Select(a => new { Id = a.Id, ProjectName = a.ProjectName }).OrderBy(a => a.Id).ToList();
            return Json(new { data = projects }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<ProjectDTO> SortProjectsByColumnWithOrder(string order, string orderDir, IQueryable<ProjectDTO> projects)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        projects = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? projects.OrderByDescending(p => p.Id) : projects.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        projects = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? projects.OrderByDescending(p => p.ProjectName) : projects.OrderBy(p => p.ProjectName);
                        break;
                    case "2":
                        // Setting.   
                        projects = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? projects.OrderByDescending(p => p.ProjectOwnerName) : projects.OrderBy(p => p.ProjectOwnerName);
                        break;
                    case "3":
                        // Setting.   
                        projects = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? projects.OrderByDescending(p => p.MainOwnerName) : projects.OrderBy(p => p.MainOwnerName);
                        break;
                    case "6":
                        // Setting.   
                        projects = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? projects.OrderByDescending(p => p.TransmissionDate) : projects.OrderBy(p => p.TransmissionDate);
                        break;
                    default:
                        // Setting.   
                        projects = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? projects.OrderByDescending(p => p.Id) : projects.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return projects;
            }
            return projects;
        }

        [HttpGet]
        public ActionResult SaveProject(int id)
        {
            var projectOwner = _db.ProjectOwners.Where(a => a.ProjectId == id).FirstOrDefault();
            var projectDTO = Mapper.Map<ProjectOwner, ProjectDTO>(projectOwner);
            var project = _db.Projects.Find(id);
            Mapper.Map<Project, ProjectDTO>(project, projectDTO);
            if (id > 0)
            {
                PopulateProjectDropDownList(project.CountryId, project.CityId, project.DistrictId);
            }
            else
            {
                PopulateProjectDropDownList();
            }
            return View(projectDTO);
        }

        [HttpPost]
        public ActionResult SaveProject(ProjectDTO project)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                try
                {
                    if (project.Id > 0)
                    {
                        //Edit
                        var oldproject = _db.Projects.Find(project.Id);
                        var oldOwner = _db.ProjectOwners.Where(a => a.ProjectId == project.Id).FirstOrDefault();
                        if (oldproject != null)
                        {
                            //Edit Project Data
                            oldproject.ProjectName = project.ProjectName; oldproject.ProjectDescription = project.ProjectDescription; oldproject.ProjectContentDetails = project.ProjectContentDetails; oldproject.TransmissionDate = project.TransmissionDate; oldproject.CountryId = project.CountryId; oldproject.CityId = project.CityId; oldproject.DistrictId = project.DistrictId; oldproject.Location = project.Location; oldproject.DocHeaderId = project.DocHeaderId; oldproject.InstallmentAccount = project.InstallmentAccount; oldproject.MintananceAccount = project.MintananceAccount;

                            //Edit Project Owner
                            oldOwner.ProjectOwnerId = project.ProjectOwnerId; oldOwner.ProjectOwnerDelegateName = project.ProjectOwnerDelegateName; oldOwner.ProjectOwnerDelegateRepresent = project.ProjectOwnerDelegateRepresent; oldOwner.ProjectOwnerDetails = project.ProjectOwnerDetails; oldOwner.IsMainOwner = project.IsMainOwner;
                            if (project.IsMainOwner == true)
                                oldOwner.MainOwnerId = oldOwner.ProjectOwnerId;
                            else
                                oldOwner.MainOwnerId = project.MainOwnerId;
                            message = " تم تعديل بيانات مشروع " + project.ProjectName + " بنجاح ";
                            className = "info";
                        }
                    }
                    else
                    {
                        //Create
                        var NewProject = Mapper.Map<ProjectDTO, Project>(project);
                        try { NewProject.Id = _db.Projects.Max(a => a.Id) + 1; } catch { NewProject.Id = 1; }
                        _db.Projects.Add(NewProject);
                        var NewProjectOwner = Mapper.Map<ProjectDTO, ProjectOwner>(project);
                        try { NewProjectOwner.Id = _db.ProjectOwners.Max(a => a.Id) + 1; } catch { NewProjectOwner.Id = 1; }
                        NewProjectOwner.ProjectId = NewProject.Id;
                        if (NewProjectOwner.IsMainOwner == true)
                            NewProjectOwner.MainOwnerId = NewProjectOwner.ProjectOwnerId;
                        _db.ProjectOwners.Add(NewProjectOwner);
                        message = " تم اضافة مشروع " + project.ProjectName + " بنجاح ";
                        className = "success";
                    }
                    _db.SaveChanges();
                    status = true;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteProject(int id)
        {
            var project = _db.Projects.Find(id);
            if (project != null)
            {
                _db.Entry(project).Reference(s => s.Country).Load(); _db.Entry(project).Reference(s => s.City).Load(); _db.Entry(project).Reference(s => s.District).Load();
                var Owner = _db.ProjectOwners.Where(a => a.ProjectId == project.Id).FirstOrDefault();
                var ProjectDTO = Mapper.Map<ProjectOwner, ProjectDTO>(Owner);
                _db.Entry(Owner).Reference(s => s.ProjectMainOwnerObj).Load(); _db.Entry(Owner).Reference(s => s.ProjectOwnerObj).Load();
                Mapper.Map<Project, ProjectDTO>(project, ProjectDTO);
                ProjectDTO.Country = project.Country.CountryName; ProjectDTO.City = project.City.CityName; ProjectDTO.District = project.District.DistrictName;
                ProjectDTO.ProjectOwnerName = Owner.ProjectOwnerObj.Name; ProjectDTO.MainOwnerName = Owner.ProjectMainOwnerObj?.Name ?? string.Empty;
                return View(ProjectDTO);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteProject")]
        public ActionResult ConfirmDeleteProject(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var project = _db.Projects.Find(id);
            var owner = _db.ProjectOwners.Where(a => a.ProjectId == id).FirstOrDefault();
            if (project != null)
            {
                //dont forget remove childs
                _db.ProjectOwners.Remove(owner);
                _db.Projects.Remove(project);
                _db.SaveChanges();
                status = true;
                message = " تم حذف مشروع " + project.ProjectName + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        private void PopulateProjectDropDownList(object selectedCountry = null, object selectedCity = null, object selectedDistrict = null)
        {
            ViewBag.Countries = new SelectList(_db.Countries.ToList(), "Id", "CountryName", selectedCountry);
            if (selectedCountry != null)
                ViewBag.Cities = new SelectList(_db.Cities.Where(a => a.CountryId == (int)selectedCountry).ToList(), "Id", "CityName", selectedCity);
            else
                ViewBag.Cities = new SelectList(new List<City> { }, "Id", "CityName");
            if (selectedCity != null)
                ViewBag.Districts = new SelectList(_db.Districts.Where(a => a.CityId == (int)selectedCity).ToList(), "Id", "DistrictName", selectedDistrict);
            else
                ViewBag.Districts = new SelectList(new List<District> { }, "Id", "DistrictName");
            ViewBag.Owners = new SelectList(_db.Owners.ToList(), "Id", "Name");
        }
        /****************************************Project Units Types********************************************/
        public ActionResult ProjectUnitsTypes(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetProjectUnitsTypes(int id)
        {
            var projectUnits = _db.ProjectUnitsTypes.Where(a => a.ProjectId == id).Select(a => new { Id = a.Id, UnitTypeName = a.UnitType.UnitTypeName, ProjectUnitTypeName = a.ProjectUnitTypeName, ProjectUnitTypeDescription = a.ProjectUnitTypeDescription, Count = a.Count, NameContain = a.NameContain, NumStartFrom = a.NumStartFrom, CharStartFrom = a.CharStartFrom, NameIncrementIn = a.NameIncrementIn, NameIncrement = a.NameIncrement, MainUnitSubUnitsNum = a.MainUnitSubUnitsNum, DocHeaderId = a.DocHeaderId }).OrderBy(a => a.Id).ToList();
            return Json(new { data = projectUnits }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SavePUnitType(int id, int ProjectId)
        {
            var PUnitType = _db.ProjectUnitsTypes.Where(a => a.Id == id && a.ProjectId == ProjectId).FirstOrDefault();
            if (id > 0 && ProjectId > 0)
            {
                ViewBag.unitTypes = new SelectList(_db.UnitTypes.ToList(), "Id", "UnitTypeName", PUnitType.UnitTypeId);
            }
            else
            {
                PUnitType = new ProjectUnitType() { ProjectId = ProjectId };
                ViewBag.unitTypes = new SelectList(_db.UnitTypes.ToList(), "Id", "UnitTypeName");
            }
            ViewBag.Contain = new SelectList(new List<SelectListItem>
                                            {
                                                new SelectListItem{ Text="أرقام", Value = "1"},
                                                new SelectListItem{ Text="حروف", Value = "2"},
                                                new SelectListItem{ Text="أرقام وحروف", Value = "3"},
                                             }, "Value", "Text");
            ViewBag.UnitsTypes = _db.UnitTypes.ToList();
            return View(PUnitType);
        }

        [HttpPost]
        public ActionResult SavePUnitType(ProjectUnitType PUnitType)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (PUnitType.Id > 0)
                {
                    //Edit
                    var oldPUnitType = _db.ProjectUnitsTypes.Find(PUnitType.Id);
                    if (oldPUnitType != null)
                    {
                        oldPUnitType.UnitTypeId = PUnitType.UnitTypeId; oldPUnitType.ProjectUnitTypeName = PUnitType.ProjectUnitTypeName; oldPUnitType.Count = PUnitType.Count; oldPUnitType.ProjectUnitTypeDescription = PUnitType.ProjectUnitTypeDescription; oldPUnitType.NameContain = PUnitType.NameContain; oldPUnitType.NumStartFrom = PUnitType.NumStartFrom; oldPUnitType.CharStartFrom = PUnitType.CharStartFrom; oldPUnitType.NameIncrementIn = PUnitType.NameIncrementIn; oldPUnitType.NameIncrement = PUnitType.NameIncrement; oldPUnitType.MainUnitSubUnitsNum = PUnitType.MainUnitSubUnitsNum; oldPUnitType.DocHeaderId = PUnitType.DocHeaderId;
                    }
                }
                else
                {
                    //Create
                    try { PUnitType.Id = _db.ProjectUnitsTypes.Max(a => a.Id) + 1; } catch { PUnitType.Id = 1; }
                    _db.ProjectUnitsTypes.Add(PUnitType);
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult DeletePUnitType(int id)
        {   //please dont forget this view
            var PUnitType = _db.ProjectUnitsTypes.Find(id);
            _db.Entry(PUnitType).Reference(s => s.UnitType).Load();
            if (PUnitType != null)
            {
                return View(PUnitType);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeletePUnitType")]
        public ActionResult ConfirmDeletePUnitType(int id)
        {
            bool status = false;
            var PUnitType = _db.ProjectUnitsTypes.Find(id);
            if (PUnitType != null)
            {
                _db.ProjectUnitsTypes.Remove(PUnitType);
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        /************************************Project Units ******************************************/

        public ActionResult ProjectUnits(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetProjectUnits(int id)
        {
            var projectUnits = _db.Units.Where(a => a.ProjectId == id).Select(a => new { Id = a.Id, UnitTypeName = a.ProjectUnitType.ProjectUnitTypeName, UniteName = a.UnitName, TotalMeters = a.TotalMeters, TotalPrice = a.TotalPrice, NetPrice = a.NetPrice, Description = a.Description, Garage = a.Garage, GarageMetes = a.GarageMetes, GaragePrice = a.GaragePrice, Perecent = a.Perecent, MaintenanceDeposit = a.MaintenanceDeposit, MainUnitId = a.MainUnitId, UnitNo = a.UnitNo }).OrderBy(a => a.Id).ToList();
            return Json(new { data = projectUnits }, JsonRequestBehavior.AllowGet);
        }

        /********************************************************************************************/
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