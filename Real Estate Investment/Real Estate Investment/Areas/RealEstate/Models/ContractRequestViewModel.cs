using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.Areas.RealEstate.Models.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class ContractRequestViewModel
    {
        public ContractRequests Request { get; set; }
        public List<InstallmentDataSerializer> InstallmentData { get; set; }
        public List<DeliverySpecificationSerializer> DeliverySpecificationData { get; set; }
        public string UserName { get; set; }
    }
}