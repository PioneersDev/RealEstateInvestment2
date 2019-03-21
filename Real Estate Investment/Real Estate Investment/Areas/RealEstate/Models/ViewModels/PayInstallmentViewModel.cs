using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class PayInstallmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "الكود المرجعي")]
        [Required(ErrorMessage ="عفوا يجب ادخال الكود المرجعي")]
        public int RefId { get; set; }

        [Display(Name = "ملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}