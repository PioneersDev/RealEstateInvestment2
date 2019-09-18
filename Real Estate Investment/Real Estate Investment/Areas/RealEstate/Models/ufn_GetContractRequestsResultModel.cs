using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class ufn_GetRequestsResultModel
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public int Step { get; set; }
        public string StepName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string Remarks { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int? MainUnitId { get; set; }
        public string MainUnitName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SubCustomerId { get; set; }
        public DateTime ContractDate { get; set; }
        public int PaymentMethodHeaderId { get; set; }
        public string PaymentMethodHeaderName { get; set; }
        public string InstallmentData { get; set; }
        public string DeliverySpecificationData { get; set; }
        public int ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public int ContractModelId { get; set; }
        public string ContractModelName { get; set; }
        public int UnitTotalValue { get; set; }
        public int? DocHeaderId { get; set; }
        public string DocHeaderName { get; set; }
        public int? ContractId { get; set; }
        public DateTime? FirstInstallmentDate { get; set; }
        public int? MarketingCompanyId { get; set; }
        public string MarketingCompanyName { get; set; }
        public decimal? MarketingCompanyPayValue { get; set; }
    }
}