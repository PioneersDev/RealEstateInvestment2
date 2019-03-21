using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class RealEstateAutoComplete
    {
        public string label { get; set; }
        public string value { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}