using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class PaymentMethodHeaderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalMonthPeriod { get; set; }
    }
}