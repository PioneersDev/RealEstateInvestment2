using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("PaymentType")]//الدفعات
    public class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="كود النوع")]
        public int Id { get; set; }

        [Required(ErrorMessage ="يجب عليك ادخال اسم النوع ")]
        [Display(Name = " النوع")]
        public string Name { get; set; }

        [Display(Name ="طبيعة النوع")]
        public byte? PaymentTypePropertyId { get; set; }

        [ForeignKey("PaymentTypePropertyId")]
        public PaymentTypeProperty PaymentTypeProperty { get; set; }
    }
}