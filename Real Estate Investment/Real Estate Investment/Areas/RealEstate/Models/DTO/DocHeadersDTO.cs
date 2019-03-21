using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class DocHeadersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DocTypeId { get; set; }
        public string DocTypeName { get; set; }
        public string Notes { get; set; }
    }
}