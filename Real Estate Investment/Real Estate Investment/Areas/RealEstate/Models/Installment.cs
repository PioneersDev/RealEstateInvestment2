using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Installment")]
    public class Installment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public int ContractId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int PaymentMethodDetailId { get; set; }

        [Required]
        public int Serial { get; set; }

        [Required]
        public DateTime PayDate { get; set; }

        [Required]
        public decimal PayValue { get; set; }

        public string PayNote { get; set; }

        public byte? PayProperty { get; set; }

        public DateTime? TransactionDate { get; set; }

        public bool IsPaid { get; set; }

        public int? RefId { get; set; }//ده هيبقى فيه الكود المحاسبي بتاع برنامج الgl

        public int? CHEQUENO { get; set; }

        public string BANKNAME { get; set; }

        public string BANKBRANCH { get; set; }

        public int? JOURNALID { get; set; }

        public int? TICKETID { get; set; }

        public int? JOURNALTYPEID { get; set; }

        public bool DELETED { get; set; }

        public int? REVERSED { get; set; }

        public DateTime? TICKETDATE { get; set; }

        public int? RECEIVINGJOURNALID { get; set; }

        public int? CHEQUEINBOXID { get; set; }

        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("PaymentMethodDetailId")]
        public PaymentMethodDetail PaymentMethodDetail { get; set; }
    }
}