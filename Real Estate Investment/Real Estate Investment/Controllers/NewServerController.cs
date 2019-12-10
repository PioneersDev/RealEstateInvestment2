using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateInvestment.Models;
using System.Web.Configuration;
using System.Configuration;

namespace RealEstateInvestment.Controllers
{
    public class NewServerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(FirstUseViewModel model)
        {
            if(ModelState.IsValid)
            {
                var confg = WebConfigurationManager.OpenWebConfiguration("~");
                var sec = (ConnectionStringsSection)confg.GetSection("connectionStrings");
                sec.ConnectionStrings["DefaultConnection"].ConnectionString =
                    "Data Source="+model.Ip+ "; Initial Catalog=RealEstateDbMashareq; User ID=" + model.Name+"; Password="+model.dbPassword+"";
                sec.ConnectionStrings["dbconn"].ConnectionString =
                    "Data Source=" + model.Ip + "; Initial Catalog=RealEstateDbMashareq; User ID=" + model.Name + "; Password=" + model.dbPassword + "";
                confg.Save();
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index",model);
        }
    }
}