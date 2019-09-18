using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.Serializer
{
    public class InstallmentDataSerializer
    {
        public int? Id { get; set; }

        public int? ContractId { get; set; }

        public int CustomerId { get; set; }

        public int PaymentMethodDetailId { get; set; }

        public string payName { get; set; }

        public int Serial { get; set; }

        public DateTime PayDate { get; set; }

        public decimal PayValue { get; set; }

        public byte? PayProperty { get; set; }

        public string PayNote { get; set; }

        public DateTime? TransactionDate { get; set; }

        public bool IsPaid { get; set; }

        public int? RefId { get; set; }

        public int? PayCount { get; set; }

        public int? CHEQUENO { get; set; }

        public string BANKNAME { get; set; }

        public string BANKBRANCH { get; set; }

        public int? JOURNALID { get; set; }

        public int? TICKETID { get; set; }

        public DateTime? TICKETDATE { get; set; }

        public int? JOURNALTYPEID { get; set; }

        public bool DELETED { get; set; }

        public int? REVERSED { get; set; }
    }

    public class InstallmentDataSerializerDTO
    {
        public int? Id { get; set; }

        public int? ContractId { get; set; }

        public int CustomerId { get; set; }

        public int PaymentMethodDetailId { get; set; }

        public int Serial { get; set; }

        public string PayDate { get; set; }

        public decimal PayValue { get; set; }

        public string PayNote { get; set; }

        public string TransactionDate { get; set; }

        public bool IsPaid { get; set; }

        public int? RefId { get; set; }

        public int? CHEQUENO { get; set; }

        public string BANKNAME { get; set; }

        public string BANKBRANCH { get; set; }

        public byte? PayProperty { get; set; }

        public int? JOURNALTYPEID { get; set; }
    }
}