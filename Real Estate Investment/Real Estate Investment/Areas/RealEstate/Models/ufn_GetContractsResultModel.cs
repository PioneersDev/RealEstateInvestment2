using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class ufn_GetContractsResultModel
    {
        public int Id { get; set; }
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
        public int ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public int ContractModelId { get; set; }
        public string ContractModelName { get; set; }
        public int UnitTotalValue { get; set; }
        public int? DocHeaderId { get; set; }
        public string DocHeaderName { get; set; }
        public long RequestId { get; set; }
        public bool JournalDone { get; set; }
    }
}