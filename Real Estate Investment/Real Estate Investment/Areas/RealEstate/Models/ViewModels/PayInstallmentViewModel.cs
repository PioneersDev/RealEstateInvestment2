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

        [Display(Name = "رقم حساب البنك")]
        [Required(ErrorMessage =" يجب عليك ادخال رقم حساب البنك")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب ادخال رقم")]
        public decimal BankAccount { get; set; }

        [Display(Name = "ملاحظات")]
        [Required(ErrorMessage = " يجب عليك ادخال ملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}