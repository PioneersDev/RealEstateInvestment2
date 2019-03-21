using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}