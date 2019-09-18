using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("MarketingCompany")]
    public class MarketingCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود الشركة")]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم الشركة ")]
        [Display(Name = "الشركة")]
        public string Name { get; set; }

        [Display(Name = "المسؤول")]
        public string MarketingCompanyDelegateName { get; set; }

        [Display(Name = "العنوان")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "أرقام الهاتف")]
        [DataType(DataType.MultilineText)]
        public string CompanyPhones { get; set; }

        [Display(Name = "حساب الشركة")]
        [Required(ErrorMessage = "يجب عليك ادخال حساب الشركة ")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب ادخال رقم")]
        public int? AccountNumber { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}