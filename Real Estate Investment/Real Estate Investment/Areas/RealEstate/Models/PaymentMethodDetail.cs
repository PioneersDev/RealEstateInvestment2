using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("PaymentMethodDetail")]
    public class PaymentMethodDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="الكود")]
        public int Id { get; set; }

        [Required]
        public int PaymentMethodHeaderId { get; set; }

        [Required(ErrorMessage ="يجب عليك اختيار نوع الدفعة")]
        [Display(Name = "نوع الدفعة")]
        public int PaymentTypeId { get; set; }

        [Display(Name = " نسبة وليس مبلغ؟")]
        public bool IsRatioNotAmount { get; set; }

        [Display(Name = " النسبة ")]
        public decimal? Ratio { get; set; }

        [Display(Name = " المبلغ ")]
        public int? MinimumAmount { get; set; }

        [Required(ErrorMessage ="يجب تحديد عدد الشهور من تاريخ العقد حتى فترة الاستحقاق")]
        [Display(Name ="الشهور من تاريخ العقد حتى الاستحقاق")]
        public int StartFrom { get; set; }

        [Required(ErrorMessage = "يجب تحديد الفترة بين الاقساط")]
        [Display(Name = "الفترة بين الاقساط")]
        public int Period { get; set; }

        [Required(ErrorMessage = "يجب تحديد عدد الاقساط")]
        [Display(Name = "عدد الاقساط")]
        public int PaymentsCounts { get; set; }

        [ForeignKey("PaymentMethodHeaderId")]
        public PaymentMethodHeader PaymentMethodHeader { get; set; }

        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }
    }
}