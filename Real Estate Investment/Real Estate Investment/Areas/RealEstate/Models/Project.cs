using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود المشروع")]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم المشروع")]
        [Display(Name = "اسم المشروع")]
        public string ProjectName { get; set; }

        [Display(Name = "موعد التسليم")]
        public DateTime? TransmissionDate { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال وصف المشروع")]
        [Display(Name = "وصف المشروع")]
        [DataType(DataType.MultilineText)]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال تفاصيل محنويات المشروع")]
        [Display(Name = "تفاصيل محنويات المشروع")]
        [DataType(DataType.MultilineText)]
        public string ProjectContentDetails { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد موقع المشروع")]
        [Display(Name = "موقع المشروع")]
        [DataType(DataType.MultilineText)]
        public string Location { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد الدولة")]
        [Display(Name = "الدولة")]
        public int CountryId  { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد المدينة")]
        [Display(Name = "المدينة")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد المركز/الحي")]
        [Display(Name = "المركز/الحي")]
        public int DistrictId { get; set; }

        //[Required(ErrorMessage = "يجب عليك تحديد مفتاح المستندات")]
        [Display(Name = "مفتاح المستندات")]
        public int? DocHeaderId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country  { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("DistrictId")]
        public District District {get; set; }

        [ForeignKey("DocHeaderId")]
        public DocHeader DocHeader { get; set; }
    }
}