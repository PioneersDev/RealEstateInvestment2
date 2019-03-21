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

        public DateTime? TransactionDate { get; set; }

        public bool IsPaid { get; set; }

        public int? RefId { get; set; }//ده هيبقى فيه الكود المحاسبي بتاع برنامج الgl

        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("PaymentMethodDetailId")]
        public PaymentMethodDetail PaymentMethodDetail { get; set; }
    }
}