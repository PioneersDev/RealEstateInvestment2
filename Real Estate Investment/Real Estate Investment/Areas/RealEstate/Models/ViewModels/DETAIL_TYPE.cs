using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class DETAIL_TYPE
    {
        public byte TRANSTYPE { get; set; }
        public decimal ACCOUNTID { get; set; }
        public decimal TRANSVALUE { get; set; }
        public string REMARKSA { get; set; }
        public string REMARKSE { get; set; }
        public int CURRID { get; set; }
        public decimal CURRRATE { get; set; }
    }
}