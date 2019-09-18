using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Contract")]
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="الكود")]
        public int Id { get; set; }

        [Required(ErrorMessage ="يجب عليك اختيار المشروع")]
        [Display(Name = "المشروع")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار الوحدة")]
        [Display(Name = "الوحدة")]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار العميل")]
        [Display(Name = "العميل")]
        public int CustomerId { get; set; }

        public string SubCustomerId { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال التاريخ")]
        [Display(Name = "تاريخ العقد")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار نظام الدفع")]
        [Display(Name = "نظام الدفع")]
        public int PaymentMethodHeaderId { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اجمالي القيمة")]
        [Display(Name = "اجمالي قيمة الوحدة")]
        public int UnitTotalValue { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال مفتاح المستندات")]
        [Display(Name = "مفتاح المستندات")]
        public int DocHeaderId { get; set; }

        [Display(Name = "نوع العقد")]
        public int ContractTypeId { get; set; }

        [Display(Name = "نوع نموذج العقد")]
        public int ContractModelId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FirstInstallmentDate { get; set; }

        [Display(Name = "شركة التسويق")]
        [Required(ErrorMessage = "يجب عليك تحديد شركة التسويق")]
        public int? MarketingCompanyId { get; set; }

        [Display(Name = " نسبة شركة التسويق ")]
        [Required(ErrorMessage = "يجب عليك تحديد نسبة شركة التسويق")]
        public decimal? MarketingCompanyPayValue { get; set; }

        public int? JOURNALID { get; set; }

        public int? TICKETID { get; set; }

        public DateTime? TICKETDATE { get; set; }

        [Display(Name = "رقم الطلب")]
        public long RequestId { get; set; }

        public bool JournalDone { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("PaymentMethodHeaderId")]
        public PaymentMethodHeader PaymentMethodHeader { get; set; }

        [ForeignKey("DocHeaderId")]
        public DocHeader DocHeader { get; set; }

        [ForeignKey("ContractTypeId")]
        public ContractType ContractType { get; set; }

        [ForeignKey("ContractModelId")]
        public ContractModel ContractModel { get; set; }

        [ForeignKey("MarketingCompanyId")]
        public MarketingCompany MarketingCompany { get; set; }
    }
}