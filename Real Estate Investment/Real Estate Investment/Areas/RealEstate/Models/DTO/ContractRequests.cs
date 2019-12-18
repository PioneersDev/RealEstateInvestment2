using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class ContractRequests
    {
        [Display(Name = "كود الطلب")]
        public long Id { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int RequestTypeId { get; set; }

        public string RequestTypeName { get; set; }

        public int Step { get; set; }

        public string StepName { get; set; }

        public string Remarks { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار المشروع")]
        [Display(Name = "المشروع")]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار الوحدة")]
        [Display(Name = "الوحدة")]
        public int UnitId { get; set; }

        public string UnitName { get; set; }

        [Display(Name = " الوحدة الرئيسية")]
        public int? MainUnitId { get; set; }

        public string MainUnitName { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار العميل")]
        [Display(Name = "العميل")]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string SubCustomerId { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال التاريخ")]
        [Display(Name = "تاريخ العقد")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار نظام الدفع")]
        [Display(Name = "نظام الدفع")]
        public int PaymentMethodHeaderId { get; set; }

        public string PaymentMethodHeaderName { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اجمالي القيمة")]
        [Display(Name = "اجمالي قيمة الوحدة")]
        public int UnitTotalValue { get; set; }

        [Display(Name = "مفتاح المستندات")]
        public int? DocHeaderId { get; set; }

        public string DocHeaderName { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار نوع العقد")]
        [Display(Name = "نوع العقد")]
        public int ContractTypeId { get; set; }

        public string ContractTypeName { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار نوع النموذج")]
        [Display(Name = "نوع نموذج العقد")]
        public int ContractModelId { get; set; }

        public string ContractModelName { get; set; }

        [Display(Name = "كود العقد")]
        public long? ContractId { get; set; }

        [Display(Name = "تاريخ أول قسط")]
        public DateTime? FirstInstallmentDate { get; set; }

        [Display(Name = "شركة التسويق")]
        [Required(ErrorMessage = "يجب عليك اختيار شركة التسويق")]
        public int? MarketingCompanyId { get; set; }

        public string MarketingCompanyName { get; set; }

        [Display(Name = "حصة شركة التسويق")]
        public decimal? MarketingCompanyPayValue { get; set; }

        [Display(Name = "عدد الأقساط")]
        public int? InstallmentNumber { get; set; }

    }
}