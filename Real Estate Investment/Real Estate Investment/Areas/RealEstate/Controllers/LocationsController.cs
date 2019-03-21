using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.CLS;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Locations")]
    public class LocationsController : Controller
    {
        private dbContainer _db = new dbContainer();

        /*************************************Country*****************************************/

        public ActionResult CountryIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetCountriesPost(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var countries = _db.Countries.Select(a => new CountryDTO { Id = a.Id, CountryName = a.CountryName }).AsQueryable();
            // Total record count.
            int totalRecords = countries.Count();
            // Apply search
            if (id != null)
                countries = countries.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                countries = countries.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.CountryName.ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            countries = SortCountriesByColumnWithOrder(order, orderDir, countries);
            int recFilter = countries.Count();
            // Apply pagination.
            countries = countries.Skip(startRec).Take(pageSize);
            return Json(new { data = countries.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCountries()
        {
            var Countries = _db.Countries.Select(a => new { Id = a.Id, CountryName = a.CountryName }).OrderBy(a => a.Id).ToList();
            return Json(new { data = Countries }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<CountryDTO> SortCountriesByColumnWithOrder(string order, string orderDir, IQueryable<CountryDTO> countries)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        countries = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? countries.OrderByDescending(p => p.Id) : countries.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        countries = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? countries.OrderByDescending(p => p.CountryName) : countries.OrderBy(p => p.CountryName);
                        break;
                    default:
                        // Setting.   
                        countries = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? countries.OrderByDescending(p => p.Id) : countries.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return countries;
            }
            return countries;
        }

        [HttpGet]
        public ActionResult SaveCountry(int id)
        {
            var country = _db.Countries.Find(id);
            return View(country);
        }

        [HttpPost]
        public ActionResult SaveCountry(Country country)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (country.Id > 0)
                {
                    //Edit
                    var oldcountry = _db.Countries.Find(country.Id);
                    if (oldcountry != null)
                    {
                        oldcountry.CountryName = country.CountryName;
                        message = " تم تعديل بيانات دولة " + country.CountryName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { country.Id = _db.Countries.Max(a => a.Id) + 1; } catch { country.Id = 1; }
                    _db.Countries.Add(country);
                    message = " تم اضافة دولة " + country.CountryName + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteCountry(int id)
        {
            var country = _db.Countries.Find(id);
            if (country != null)
            {
                return View(country);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteCountry")]
        public ActionResult ConfirmDeleteCountry(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var country = _db.Countries.Find(id);
            if (country != null)
            {
                var cityList = _db.Cities.Where(a => a.CountryId == country.Id);
                _db.Cities.RemoveRange(cityList);
                _db.Countries.Remove(country);
                _db.SaveChanges();
                status = true;
                message = " تم حذف دولة " + country.CountryName + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        /*******************************************City**************************************************/
        public ActionResult CityIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetCitiesPost(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var cities = _db.Cities.Select(a => new CityDTO { Id = a.Id, CityName = a.CityName, CountryName = a.Country.CountryName }).AsQueryable();
            // Total record count.
            int totalRecords = cities.Count();
            // Apply search
            if (id != null)
                cities = cities.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                cities = cities.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.CityName.ToLower().Contains(search.ToLower()) ||
                p.CountryName.ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            cities = SortCitiesByColumnWithOrder(order, orderDir, cities);
            int recFilter = cities.Count();
            // Apply pagination.
            cities = cities.Skip(startRec).Take(pageSize);
            return Json(new { data = cities.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCities(int? id)
        {
            IQueryable<City> cities = null;
            if (id == null)
                cities = _db.Cities;
            else
                cities = _db.Cities.Where(a => a.CountryId == id);
            return Json(new { data = cities.Select(a => new { Id = a.Id, CityName = a.CityName, CountryName = a.Country.CountryName }).OrderBy(a => a.Id).ToList() }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<CityDTO> SortCitiesByColumnWithOrder(string order, string orderDir, IQueryable<CityDTO> cities)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        cities = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? cities.OrderByDescending(p => p.Id) : cities.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        cities = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? cities.OrderByDescending(p => p.CityName) : cities.OrderBy(p => p.CityName);
                        break;
                    case "2":
                        // Setting.   
                        cities = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? cities.OrderByDescending(p => p.CountryName) : cities.OrderBy(p => p.CountryName);
                        break;
                    default:
                        // Setting.   
                        cities = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? cities.OrderByDescending(p => p.Id) : cities.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return cities;
            }
            return cities;
        }

        [HttpGet]
        public ActionResult SaveCity(int id)
        {
            var city = _db.Cities.Find(id);
            if (id > 0)
                PopulateCityDropDownList(city.CountryId);
            else
                PopulateCityDropDownList();
            return View(city);
        }

        [HttpPost]
        public ActionResult SaveCity(City city)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (city.Id > 0)
                {
                    //Edit
                    var oldcity = _db.Cities.Find(city.Id);
                    if (oldcity != null)
                    {
                        oldcity.CityName = city.CityName; oldcity.CountryId = city.CountryId;
                        message = " تم تعديل بيانات مدينة " + city.CityName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { city.Id = _db.Cities.Max(a => a.Id) + 1; } catch { city.Id = 1; }
                    _db.Cities.Add(city);
                    message = " تم اضافة مدينة " + city.CityName + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteCity(int id)
        {
            var city = _db.Cities.Find(id);
            if (city != null)
            {
                return View(city);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteCity")]
        public ActionResult ConfirmDeleteCity(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var city = _db.Cities.Find(id);
            if (city != null)
            {
                var districtList = _db.Districts.Where(a => a.CityId == city.Id);
                _db.Districts.RemoveRange(districtList);
                _db.Cities.Remove(city);
                _db.SaveChanges();
                status = true;
                message = " تم حذف مدينة " + city.CityName + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        private void PopulateCityDropDownList(object selectedCountry = null)
        {
            ViewBag.Countries = new SelectList(_db.Countries.ToList(), "Id", "CountryName", selectedCountry);
        }
        /******************************************District***********************************************/
        public ActionResult DistrictIndex(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetDistrictsPost(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var districts = _db.Districts.Select(a => new DistrictDTO { Id = a.Id, DistrictName = a.DistrictName, CityName = a.City.CityName, CountryName = a.City.Country.CountryName }).AsQueryable();
            // Total record count.
            int totalRecords = districts.Count();
            // Apply search
            if (id != null)
                districts = districts.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                districts = districts.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.DistrictName.ToLower().Contains(search.ToLower()) ||
                p.CityName.ToLower().Contains(search.ToLower()) ||
                p.CountryName.ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            districts = SortDistrictsByColumnWithOrder(order, orderDir, districts);
            int recFilter = districts.Count();
            // Apply pagination.
            districts = districts.Skip(startRec).Take(pageSize);
            return Json(new { data = districts.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistricts(int? id)
        {
            IQueryable<District> districts = null;
            if (id == null)
                districts = _db.Districts;
            else
                districts = _db.Districts.Where(a => a.CityId == id);
            return Json(new { data = districts.Include(a => a.City).Select(a => new { Id = a.Id, DistrictName = a.DistrictName, CityName = a.City.CityName, CountryName = a.City.Country.CountryName }).OrderBy(a => a.Id).ToList() }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<DistrictDTO> SortDistrictsByColumnWithOrder(string order, string orderDir, IQueryable<DistrictDTO> districts)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        districts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? districts.OrderByDescending(p => p.Id) : districts.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        districts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? districts.OrderByDescending(p => p.DistrictName) : districts.OrderBy(p => p.DistrictName);
                        break;
                    case "2":
                        // Setting.   
                        districts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? districts.OrderByDescending(p => p.CityName) : districts.OrderBy(p => p.CityName);
                        break;
                    case "3":
                        // Setting.   
                        districts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? districts.OrderByDescending(p => p.CountryName) : districts.OrderBy(p => p.CountryName);
                        break;
                    default:
                        // Setting.   
                        districts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? districts.OrderByDescending(p => p.Id) : districts.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return districts;
            }
            return districts;
        }

        [HttpGet]
        public ActionResult SaveDistrict(int id)
        {
            var district = _db.Districts.Find(id);
            if (id > 0)
            {
                district.CountryId = district.City.CountryId;
                PopulateDistrictDropDownList(district.CountryId, district.CityId);
            }
            else
            {
                PopulateDistrictDropDownList();
            }
            return View(district);
        }

        [HttpPost]
        public ActionResult SaveDistrict(District district)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (district.Id > 0)
                {
                    //Edit
                    var olddistrict = _db.Districts.Find(district.Id);
                    if (olddistrict != null)
                    {
                        olddistrict.DistrictName = district.DistrictName; olddistrict.CityId = district.CityId;
                        message = " تم تعديل بيانات مركز " + district.DistrictName + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { district.Id = _db.Districts.Max(a => a.Id) + 1; } catch { district.Id = 1; }
                    _db.Districts.Add(district);
                    message = " تم اضافة مركز " + district.DistrictName + " بنجاح ";
                    className = "success";
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        [HttpGet]
        public ActionResult DeleteDistrict(int id)
        {
            var district = _db.Districts.Find(id);
            if (district != null)
            {
                return View(district);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeleteDistrict")]
        public ActionResult ConfirmDeleteDistrict(int id)
        {
            bool status = false;
            string message = null;
            string className = null;
            var district = _db.Districts.Find(id);
            if (district != null)
            {
                _db.Districts.Remove(district);
                _db.SaveChanges();
                status = true;
                message = " تم حذف مركز " + district.DistrictName + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        private void PopulateDistrictDropDownList(object selectedCountry = null, object selectedCity = null)
        {
            ViewBag.Countries = new SelectList(_db.Countries.ToList(), "Id", "CountryName", selectedCountry);
            if (selectedCountry != null)
                ViewBag.Cities = new SelectList(_db.Cities.Where(a => a.CountryId == (int)selectedCountry).ToList(), "Id", "CityName", selectedCity);
            else
                ViewBag.Cities = new SelectList(new List<City> { }, "Id", "CityName");
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
