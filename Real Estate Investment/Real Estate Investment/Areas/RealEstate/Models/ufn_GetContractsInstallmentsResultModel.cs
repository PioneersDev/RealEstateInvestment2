using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class ufn_GetContractsInstallmentsResultModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PaymentMethodDetailId { get; set; }
        public string PaymentMethodDetailName { get; set; }
        public int Serial { get; set; }
        public DateTime PayDate { get; set; }
        public decimal PayValue { get; set; }
        public string PayNote { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsPaid { get; set; }
        public int? RefId { get; set; }
        public int? STATUSID { get; set; }
        public string STATUSNAME { get; set; }
        public int JOURNALTYPEID { get; set; }
        public string GroupColumn { get; set; }
        public int? TICKETID { get; set; }
        public DateTime? TICKETDATE { get; set; }
        public int? CHEQUEINBOXID { get; set; }
    }
}