using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class ProjectUnitType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Display(Name = "اسم النموذج")]
        [Required(ErrorMessage = "يجب عليك تحديد اسم النموذج")]
        public string ProjectUnitTypeName { get; set; }

        [Display(Name ="نوع النموذج")]
        [Required(ErrorMessage ="يجب عليك تحديد نوع النموذج")]
        public int UnitTypeId { get; set; }

        [Display(Name = "عدد وحدات النموذج")]
        [Required(ErrorMessage = "يجب عليك تحديد عدد الوحدات")]
        public int Count { get; set; }

        [Display(Name = "الأسم يحتوي على")]
        [Required(ErrorMessage = "يجب عليك تحديد مكونات الاسم")]
        public int NameContain { get; set; }//{1=numbers,2=chars,3=numbers&chars}

        [Display(Name = "الأرقام تبدأ من")]
        public int? NumStartFrom { get; set; }

        [Display(Name = "الحروف تبدأ من")]
        public string CharStartFrom { get; set; }

        [Display(Name = "الزيادة في")]
        [Required(ErrorMessage = "يجب عليك تحديد محل الزيادة")]
        public int NameIncrementIn { get; set; }

        [Display(Name = "معدل الزيادة")]
        [Required(ErrorMessage = "يجب عليك تحديد معدل الزيادة")]
        public int NameIncrement { get; set; }

        [Display(Name = "عدد الوحدات الفرعية في التقسيمة")]
        public int? MainUnitSubUnitsNum { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "وصف النموذج")]
        public string ProjectUnitTypeDescription { get; set; }

        //[Required(ErrorMessage = "يجب عليك تحديد مفتاح المستندات")]
        [Display(Name = "مفتاح المستندات")]
        public int? DocHeaderId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [ForeignKey("UnitTypeId")]
        public UnitType UnitType { get; set; }

        [ForeignKey("DocHeaderId")]
        public DocHeader DocHeader { get; set; }

    }
}