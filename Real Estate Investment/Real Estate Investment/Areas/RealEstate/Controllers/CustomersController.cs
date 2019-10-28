using Microsoft.AspNet.Identity;
using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.Areas.RealEstate.Models.ViewModels;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("Customers")]
    public class CustomersController : Controller
    {
        private dbContainer _db = new dbContainer();

        /******************************************Customer***********************************************/

        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetCustomersPost(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var customers = _db.Customers.Select(a => new CustomerDTO { Id = a.Id, NameArab = a.NameArab, Address = a.Address, Email = a.Email, Nationality = a.Nationality.NationalityName, Country = a.Country.CountryName, City = a.City.CityName, District = a.District.DistrictName,AccountNumber=a.AccountNumber }).AsQueryable();
            // Total record count.
            int totalRecords = customers.Count();
            // Apply search
            if (id != null)
                customers = customers.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                customers = customers.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.NameArab.ToLower().Contains(search.ToLower()) ||
                p.Email.ToLower().Contains(search.ToLower()) ||
                p.Country.ToLower().Contains(search.ToLower()) ||
                p.City.ToLower().Contains(search.ToLower()) ||
                p.District.ToLower().Contains(search.ToLower())||
                p.AccountNumber.ToString().ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            customers = SortCustomersByColumnWithOrder(order, orderDir, customers);
            int recFilter = customers.Count();
            // Apply pagination.
            customers = customers.Skip(startRec).Take(pageSize);
            return Json(new { data = customers.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomers()
        {
            var customers = _db.Customers.Select(a => new { Id = a.Id, NameArab = a.NameArab, Address = a.Address, Email = a.Email, Nationality = a.Nationality.NationalityName, Country = a.Country.CountryName, City = a.City.CityName, District = a.District.DistrictName }).OrderBy(a => a.Id).ToList();
            return Json(new { data = customers }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<CustomerDTO> SortCustomersByColumnWithOrder(string order, string orderDir, IQueryable<CustomerDTO> customers)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        customers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? customers.OrderByDescending(p => p.Id) : customers.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        customers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? customers.OrderByDescending(p => p.NameArab) : customers.OrderBy(p => p.NameArab);
                        break;
                    case "2":
                        // Setting.   
                        customers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? customers.OrderByDescending(p => p.Email) : customers.OrderBy(p => p.Email);
                        break;
                    case "3":
                        // Setting.   
                        customers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? customers.OrderByDescending(p => p.AccountNumber) : customers.OrderBy(p => p.AccountNumber);
                        break;
                    default:
                        // Setting.   
                        customers = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? customers.OrderByDescending(p => p.Id) : customers.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return customers;
            }
            return customers;
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var customer = _db.Customers.Find(id);
            if (id > 0)
            {
                PopulateDropDownList(customer.CountryId, customer.CityId, customer.DistrictId, customer.IDTypeId, customer.ReligionId, customer.NationalityId);
            }
            else
            {
                PopulateDropDownList();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            bool status = false;
            string message = null;
            string className = null;
            if (ModelState.IsValid)
            {
                if (customer.Id > 0)
                {
                    //Edit
                    var oldcustomer = _db.Customers.Find(customer.Id);
                    if (oldcustomer != null)
                    {
                        try
                        {
                            oldcustomer.NameArab = customer.NameArab; oldcustomer.NameEng = customer.NameEng; oldcustomer.Address = customer.Address; oldcustomer.CountryId = customer.CountryId; oldcustomer.CityId = customer.CityId; oldcustomer.DistrictId = customer.DistrictId; oldcustomer.Email = customer.Email; oldcustomer.IdExpiryDate = customer.IdExpiryDate; oldcustomer.IdissuePlace = customer.IdissuePlace; oldcustomer.IdNumber = customer.IdNumber;
                            oldcustomer.IdNumberForAgent = customer.IdNumberForAgent; oldcustomer.IDTypeId = customer.IDTypeId; oldcustomer.NationalityId = customer.NationalityId; oldcustomer.Occupation = customer.Occupation; oldcustomer.ReligionId = customer.ReligionId; oldcustomer.TypeId = customer.TypeId;
                            AccountOperationParams paramModel = new AccountOperationParams
                            {
                                CustomerId = oldcustomer.Id,
                                CustomerNameA = oldcustomer.NameArab,
                                CustomerNameE = oldcustomer.NameEng,
                                UserName = User.Identity.GetUserName(),
                                MachineIp = Request.UserHostAddress,
                                MachineName = User.Identity.GetUserName(),
                                LoginUser = User.Identity.GetUserId(),
                                Operation = "Update",
                                CompanyName = "GL_SQUER",
                                CustomerAccount = oldcustomer.AccountNumber.Value
                            };
                            CustomerQaed custq = new CustomerQaed();

                            var response = custq.CustomerAccountOperation(paramModel);
                            if (response != null)
                            {
                                
                                if (response.Status)
                                {
                                    oldcustomer.AccountNumber = response.AccountId;
                                }
                                else
                                {
                                    throw new Exception(" Customer Account Not Added Correctly " + response.Message);
                                }
                            }
                            else
                            {
                                //throw new Exception("Error in Calling API");
                                message = "Error in Calling API";
                                className = "error";
                                status = true;
                                return new JsonResult { Data = new { status = status, message = message, className = className } };
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        message = " تم تعديل بيانات العميل " + customer.NameArab + " بنجاح ";
                        className = "info";
                    }
                }
                else
                {
                    //Create
                    try { customer.Id = _db.Customers.Max(a => a.Id) + 1; } catch { customer.Id = 1; }
                    try
                    {
                        AccountOperationParams paramModel = new AccountOperationParams
                        {
                            CustomerId = customer.Id,
                            CustomerNameA = customer.NameArab,
                            CustomerNameE = customer.NameEng,
                            UserName = User.Identity.GetUserName(),
                            MachineIp = Request.UserHostAddress,
                            MachineName = User.Identity.GetUserName(),
                            LoginUser = User.Identity.GetUserId(),
                            Operation = "Insert",
                            CompanyName = "GL_SQUER",
                            CustomerAccount = null
                        };

                        CustomerQaed custq = new CustomerQaed();

                        var response = custq.CustomerAccountOperation(paramModel);

                        //HttpResponseMessage response = GlobalApiVariables.WebApiClient.PostAsJsonAsync("CustomerAccountOperation", paramModel).Result;

                        //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        //{
                         
                            if (response.Status)
                            {
                                customer.AccountNumber = response.AccountId;
                                _db.Customers.Add(customer);
                            }
                            else
                            {
                                //throw new Exception(" Customer Account Not Added Correctly " + CustomerAccountOperationResult.Message);
                                message = " Customer Account Not Added Correctly " + response.Message;
                                className = "error";
                                status = true;
                                return new JsonResult { Data = new { status = status, message = message, className = className } };
                            }
                     
                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                        message = "Error in Calling API";
                        className = "error";
                        status = true;
                        return new JsonResult { Data = new { status = status, message = message, className = className } };
                    }
                    message = " تم اضافة العميل " + customer.NameArab + " بنجاح ";
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
            var customer = _db.Customers.Find(id);
            _db.Entry(customer).Reference(s => s.Country).Load(); _db.Entry(customer).Reference(s => s.City).Load(); _db.Entry(customer).Reference(s => s.District).Load(); _db.Entry(customer).Reference(s => s.Religion).Load(); _db.Entry(customer).Reference(s => s.Nationality).Load(); _db.Entry(customer).Reference(s => s.TypeId).Load();
            if (customer != null)
            {
                return View(customer);
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
            var customer = _db.Customers.Find(id);
            if (customer != null)
            {
                //dont forget remove childs----->done
                var Childs = _db.CustomerPhones.Where(a => a.CustomerId == id).ToList();
                _db.CustomerPhones.RemoveRange(Childs);
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                status = true;
                message = " تم حذف العميل " + customer.NameArab + " بنجاح ";
                className = "error";
            }
            return new JsonResult { Data = new { status = status, message = message, className = className } };
        }

        public ActionResult GetCustomerList(string searchTearm)
        {
            var customerList = _db.Customers.Select(a => new { Id = a.Id, NameArab = a.Id + " " + a.NameArab }).ToList();
            if (!string.IsNullOrEmpty(searchTearm))
            {
                customerList = customerList.Where(a => a.NameArab.Contains(searchTearm)).ToList();
            }
            var data = customerList.Select(a => new { id = a.Id, text = a.NameArab }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private void PopulateDropDownList(object selectedCountry = null, object selectedCity = null, object selectedDistrict = null, object selectedIDType = null, object selectedReligion = null, object selectedNationality = null)
        {
            ViewBag.Countries = new SelectList(_db.Countries.ToList(), "Id", "CountryName", selectedCountry);
            if (selectedCountry != null)
                ViewBag.Cities = new SelectList(_db.Cities.Where(a => a.CountryId == (int)selectedCountry).ToList(), "Id", "CityName", selectedCity);
            else
                ViewBag.Cities = new SelectList(_db.Cities.ToList(), "Id", "CityName", selectedCity);
            if (selectedCity != null)
                ViewBag.Districts = new SelectList(_db.Districts.Where(a => a.CityId == (int)selectedCity).ToList(), "Id", "DistrictName", selectedDistrict);
            else
                ViewBag.Districts = new SelectList(_db.Districts.ToList(), "Id", "DistrictName", selectedDistrict);
            ViewBag.Ids = new SelectList(_db.TypeIds.ToList(), "Id", "IdName", selectedIDType);
            ViewBag.Religions = new SelectList(_db.Religions.ToList(), "Id", "ReligionName", selectedReligion);
            ViewBag.Nationalities = new SelectList(_db.Nationalities.ToList(), "Id", "NationalityName", selectedNationality);
        }
        /************************************Customer Phones***************************************************/
        public ActionResult GetPhones(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetCustomerPhones(int id)
        {
            var phones = _db.CustomerPhones.Where(a => a.CustomerId == id).Select(a => new { Id = a.Id, PhoneTypeName = a.PhoneType.PhoneTypeName, PhoneNo = a.PhoneNo, CustomerId = a.CustomerId }).OrderBy(a => a.Id).ToList();
            return Json(new { data = phones }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SavePhone(int id, int CustomerId)
        {
            var customerPhone = _db.CustomerPhones.Where(a => a.Id == id && a.CustomerId == CustomerId).FirstOrDefault();
            if (id > 0 && CustomerId > 0)
            {
                ViewBag.PhoneTypes = new SelectList(_db.PhoneTypes.ToList(), "Id", "PhoneTypeName", customerPhone.PhoneTypeId);
            }
            else
            {
                customerPhone = new CustomerPhone() { CustomerId = CustomerId };
                ViewBag.PhoneTypes = new SelectList(_db.PhoneTypes.ToList(), "Id", "PhoneTypeName");
            }
            return View(customerPhone);
        }

        [HttpPost]
        public ActionResult SavePhone(CustomerPhone customerPhone)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (customerPhone.Id > 0)
                {
                    //Edit
                    var oldcustomerPhone = _db.CustomerPhones.Find(customerPhone.Id);
                    if (oldcustomerPhone != null)
                    {
                        oldcustomerPhone.PhoneTypeId = customerPhone.PhoneTypeId; oldcustomerPhone.PhoneNo = customerPhone.PhoneNo;
                    }
                }
                else
                {
                    //Create
                    try { customerPhone.Id = _db.CustomerPhones.Max(a => a.Id) + 1; } catch { customerPhone.Id = 1; }
                    _db.CustomerPhones.Add(customerPhone);
                }
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult DeletePhone(int id)
        {
            var customerPhone = _db.CustomerPhones.Find(id);
            _db.Entry(customerPhone).Reference(s => s.PhoneType).Load();
            if (customerPhone != null)
            {
                return View(customerPhone);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("DeletePhone")]
        public ActionResult ConfirmDeletePhone(int id)
        {
            bool status = false;
            var customerPhone = _db.CustomerPhones.Find(id);
            if (customerPhone != null)
            {
                _db.CustomerPhones.Remove(customerPhone);
                _db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
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