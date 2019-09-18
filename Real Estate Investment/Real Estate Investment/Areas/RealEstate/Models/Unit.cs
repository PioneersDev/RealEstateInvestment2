using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Unit")]
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد النموذج الخاص بالوحدة")]
        [Display(Name = "نموذج الوحدة")]
        public int ProjectUnitTypeId { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد اسم الوحدة")]
        [Display(Name = "اسم الوحدة")]
        public string UnitName { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد مساحة الوحدة")]
        [Display(Name = "المساحة بالمتر")]
        public decimal TotalMeters { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد اجمالي قيمةالوحدة")]
        [Display(Name = "اجمالي القيمة")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد صافي قيمةالوحدة")]
        [Display(Name = "صافي القيمة")]
        public decimal NetPrice { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد سعر المتر")]
        [Display(Name = "سعر المتر")]
        public decimal MeterPrice { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "وصف الوحدة")]
        public string Description { get; set; }

        [Display(Name = "تحتوي على جراج؟")]
        public bool Garage { get; set; }

        [Display(Name = "مساحة الجراج")]
        public decimal? GarageMetes { get; set; }

        [Display(Name = "سعر الجراج")]
        public decimal? GaragePrice { get; set; }

        [Display(Name = "الصيانة نسبة؟")]
        public bool? Perecent { get; set; }

        [Display(Name = "اجمالي الصيانة")]
        public decimal? MaintenanceDeposit { get; set; }

        [Display(Name = "الوحدة الاساسية")]
        public int? MainUnitId { get; set; }

        public int ProjectId { get; set; }

        [Display(Name = "رقم الوحدة")]
        public string UnitNo { get; set; }

        [Display(Name = "موقع الوحدة في العقد")]
        public string UnitContractAddress { get; set; }

        [Display(Name = "رقم الطابق")]
        public int? FloorNumber { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار الحالة")]
        [Display(Name = "الحالة")]
        public int StatusId { get; set; }

        //[Required(ErrorMessage = "يجب عليك تحديد مفتاح المستندات")]
        [Display(Name = "مفتاح المستندات")]
        public int? DocHeaderId { get; set; }

        [ForeignKey("ProjectUnitTypeId")]
        public ProjectUnitType ProjectUnitType { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [ForeignKey("DocHeaderId")]
        public DocHeader DocHeader { get; set; }

        public ICollection<UnitContent> UnitContents { get; set; }

        public ICollection<UnitDocument> UnitDocuments { get; set; }
    }


}