using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public class GlobalApiVariables
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalApiVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:56145/api/CustomerAPI/");
            //WebApiClient.BaseAddress = new Uri("http://192.168.0.131:8081/api/CustomerAPI/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}