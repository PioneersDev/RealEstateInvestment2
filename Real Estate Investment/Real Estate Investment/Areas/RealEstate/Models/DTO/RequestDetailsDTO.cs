using RealEstateInvestment.Areas.RealEstate.Models.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class RequestDetailsDTO
    {
        public ContractRequests Request { get; set; }
        public List<InstallmentDataSerializer> Installments { get; set; }
        public List<DeliverySpecificationSerializer> DeliverySpecificationData { get; set; }
    }
}