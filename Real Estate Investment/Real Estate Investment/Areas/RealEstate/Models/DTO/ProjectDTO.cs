using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class ProjectDTO
    {
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
        public int CountryId { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد المدينة")]
        [Display(Name = "المدينة")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد المركز/الحي")]
        [Display(Name = "المركز/الحي")]
        public int DistrictId { get; set; }

        //[Required(ErrorMessage = "يجب عليك تحديد مفتاح المستندات")]
        [Display(Name = "مفتاح المستندات")]
        public int? DocHeaderId { get; set; }

        [Display(Name = "حساب الصيانة")]
        [Required(ErrorMessage = "يجب عليك ادخال رقم حساب الصيانة")]
        public int? MintananceAccount { get; set; }

        [Display(Name = "حساب الدفعات")]
        [Required(ErrorMessage = "يجب عليك ادخال رقم حساب الدفعات")]
        public int? InstallmentAccount { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public int ProjectId { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد مالك المشروع")]
        [Display(Name = "مالك المشروع")]
        public int ProjectOwnerId { get; set; }

        public string ProjectOwnerName { get; set; }

        [Display(Name = " ممثل مالك المشروع")]
        public string ProjectOwnerDelegateName { get; set; }

        [Display(Name = "صفة ممثل مالك المشروع ")]
        public string ProjectOwnerDelegateRepresent { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال تفاصيل ملكية مالك المشروع ")]
        [Display(Name = "تفاصيل ملكية مالك المشروع ")]
        [DataType(DataType.MultilineText)]
        public string ProjectOwnerDetails { get; set; }

        [Display(Name = "مالك المشروع هو مالك الأرض؟")]
        public bool IsMainOwner { get; set; }

        [Display(Name = "مالك الأرض")]
        public int? MainOwnerId { get; set; }
        public string MainOwnerName { get; set; }
    }
}