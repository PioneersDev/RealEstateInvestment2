using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string NameArab { get; set; }
        public string NameEng { get; set; }
        public string Address { get; set; }
        public string IdNumber { get; set; }
        public string IdNumberForAgent { get; set; }
        public string IdissuePlace { get; set; }
        public DateTime?  IdExpiryDate { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public int? NationalityId { get; set; }
        public string Nationality { get; set; }
        public int? ReligionId { get; set; }
        public string Religion { get; set; }
        public int? IDTypeId { get; set; }
        public string IdName { get; set; }
        public int? CountryId { get; set; }
        public string Country { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public int? DistrictId { get; set; }
        public string District { get; set; }
        public decimal? AccountNumber { get; set; }
    }
}