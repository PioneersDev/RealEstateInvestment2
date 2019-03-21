using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("ContractItem")]
    public class ContractItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الكود")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب عليك ادخال اسم البند")]
        [Display(Name = "اسم البند")]
        public string ContractItemName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب عليك ادخال البند")]
        [Display(Name = "البند")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string ContractItemString { get; set; }

        [Display(Name = "نوع نموذج العقد")]
        public int ContractModelId { get; set; }

        [ForeignKey("ContractModelId")]
        public ContractModel ContractModel { get; set; }
    }
}