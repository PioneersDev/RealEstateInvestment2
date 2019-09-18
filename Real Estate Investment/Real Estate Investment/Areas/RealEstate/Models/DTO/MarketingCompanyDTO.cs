using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class MarketingCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MarketingCompanyDelegateName { get; set; }
        public string Address { get; set; }
        public string CompanyPhones { get; set; }
        public decimal? AccountNumber { get; set; }
    }
}