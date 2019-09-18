using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("PaymentTypeProperty")]
    public class PaymentTypeProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود الخاصية")]
        public byte Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم الخاصية ")]
        [Display(Name = " الخاصية")]
        public string Name { get; set; }

        public ICollection<PaymentType> PaymentTypes { get; set; }
    }
}