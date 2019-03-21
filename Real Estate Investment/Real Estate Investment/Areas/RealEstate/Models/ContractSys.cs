using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("ContractSys")]
    public class ContractSys
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الكود")]
        public int VarId { get; set; }

        [Display(Name = "اسم المتغير")]
        public string VarName { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage ="يجب عليك كتابة وصف المتغير")]
        [Display(Name = "وصف المتغير")]
        public string VarDescription { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب عليك كتابة قيمة المتغير")]
        [Display(Name = "قيمة المتغير الافتراضية")]
        public string VarValue { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب عليك اختيار نوع المتغير")]
        [Display(Name = "نوع المتغير")]
        public string VarType { get; set; }

        [Display(Name = "هل له تفقيط؟")]
        public bool IsTafqet { get; set; }

        public bool IsMoney { get; set; }
    }
}