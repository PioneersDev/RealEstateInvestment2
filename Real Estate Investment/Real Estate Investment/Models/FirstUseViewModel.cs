using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    public class FirstUseViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        [RegularExpression("^(?!1AdminAdmin*$).*$", ErrorMessage = " كلمة المرور غير صحيحة")]
        public string Password { get; set; }
        [Display(Name = "عنوان السرفر")]
        [RegularExpression(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b",ErrorMessage = " تأكد من ادخال عنوان السرفر ")]
        [Required(ErrorMessage = "يجب عليك ادخال عنوان الملقم")]
        public string Ip { get; set; }
        [Display(Name = "اسم المستخدم")]
        [Required(ErrorMessage = "يجب عليك ادخال اسم المستخدم")]
        public string Name { get; set; }
        [Display(Name = " كلمة مرور الداتابيز")]
        [Required(ErrorMessage = "يجب عليك ادخال كلمة مرور الداتابيز")]
        public string dbPassword { get; set; }
    }
}