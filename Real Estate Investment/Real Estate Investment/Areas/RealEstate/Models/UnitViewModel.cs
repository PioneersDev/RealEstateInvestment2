using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class UnitViewModel
    {
        public Unit unit { get; set; }
        public bool isParent { get; set; }
    }
}