using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("ContractModel")]
    public class ContractModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الكود")]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال الاسم")]
        [Display(Name = "الاسم")]
        public string Name { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار نوع العقد")]
        [Display(Name = "نوع العقد")]
        public int ContractTypeId { get; set; }

        [ForeignKey("ContractTypeId")]
        public ContractType ContractType { get; set; }

        public ICollection<ContractItem> ContractItems { get; set; }
    }
}