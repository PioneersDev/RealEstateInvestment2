using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    [CustomAuthorize("RegisterdContracts")]
    public class RegisterdContractsController : Controller
    {

        private dbContainer _db = new dbContainer();

        /******************************************Registerd Contracts***********************************************/

        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetRegisterdContracts(int? id)
        {
            // Initialization.
            string search = Request.Form.GetValues("search[value]")[0];
            string draw = Request.Form.GetValues("draw")[0];
            string order = Request.Form.GetValues("order[0][column]")[0];
            string orderDir = Request.Form.GetValues("order[0][dir]")[0];
            int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
            int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
            // Loading.
            var contracts = _db.Database.SqlQuery<ufn_GetContractsResultModel>("SELECT * FROM [con].[ufn_GetContracts] (null)").AsQueryable();
            // Total record count.
            int totalRecords = contracts.Count();
            // Apply search
            if (id != null)
                contracts = contracts.Where(a => a.Id == id);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                contracts = contracts.Where(p => p.Id.ToString().ToLower().Contains(search.ToLower()) ||
                p.ProjectName.ToLower().Contains(search.ToLower()) ||
                p.MainUnitName.ToLower().Contains(search.ToLower()) ||
                p.UnitName.ToLower().Contains(search.ToLower()) ||
                p.CustomerName.ToLower().Contains(search.ToLower())||
                p.ContractDate.ToString().ToLower().Contains(search.ToLower()));
            }
            // Sorting.
            contracts = SortByColumnWithOrder(order, orderDir, contracts);
            int recFilter = contracts.Count();
            // Apply pagination.
            contracts = contracts.Skip(startRec).Take(pageSize);
            return Json(new { data = contracts.ToList(), draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<ufn_GetContractsResultModel> SortByColumnWithOrder(string order, string orderDir, IQueryable<ufn_GetContractsResultModel> contracts)
        {
            // Initialization.   
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.Id) : contracts.OrderBy(p => p.Id);
                        break;
                    case "1":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.ProjectName) : contracts.OrderBy(p => p.ProjectName);
                        break;
                    case "2":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.UnitName) : contracts.OrderBy(p => p.UnitName);
                        break;
                    case "3":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.MainUnitName) : contracts.OrderBy(p => p.MainUnitName);
                        break;
                    case "4":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.CustomerName) : contracts.OrderBy(p => p.CustomerName);
                        break;
                    case "5":
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.ContractDate) : contracts.OrderBy(p => p.ContractDate);
                        break;
                    default:
                        // Setting.   
                        contracts = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? contracts.OrderByDescending(p => p.Id) : contracts.OrderBy(p => p.Id);
                        break;
                }
            }
            catch
            {
                return contracts;
            }
            return contracts;
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