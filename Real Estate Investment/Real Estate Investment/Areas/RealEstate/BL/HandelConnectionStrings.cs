using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public class HandelConnectionStrings
    {
        public static string GetConnectionString(string CompanyName)
        {
            var confg = WebConfigurationManager.OpenWebConfiguration("~");
            var section = (ConnectionStringsSection)confg.GetSection("connectionStrings");
            return section.ConnectionStrings[CompanyName].ConnectionString;
        }
    }
}