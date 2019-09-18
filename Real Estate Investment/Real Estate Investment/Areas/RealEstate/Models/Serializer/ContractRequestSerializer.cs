using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace RealEstateInvestment.Areas.RealEstate.Models.Serializer
{
    public class ContractRequestSerializer
    {
        public int? Id { get; set; }

        public int ProjectId { get; set; }

        public int UnitId { get; set; }

        public int CustomerId { get; set; }

        public string SubCustomerId { get; set; }

        public string ContractDate { get; set; }

        public int PaymentMethodHeaderId { get; set; }

        public List<InstallmentDataSerializerDTO> InstallmentData { get; set; }

        public List<DeliverySpecificationSerializer> DeliverySpecificationData { get; set; }

        public int ContractTypeId { get; set; }

        public int ContractModelId { get; set; }

        public int UnitTotalValue { get; set; }

        public int? DocHeaderId { get; set; }

        public string FirstInstallmentDate { get; set; }

        public int? MarketingCompanyId { get; set; }

        public decimal? MarketingCompanyPayValue { get; set; }
    }
}