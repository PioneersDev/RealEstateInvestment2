using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class UnitContent
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود المحتوى")]
        public int Id { get; set; }

        [Required(ErrorMessage ="يجب عليك تحديد نوع المحتوى ")]
        [Display(Name ="نوع المحتوى")]
        public int ContentTypeId { get; set; }

        [Display(Name = "الوحدة")]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد مساحة المحتوى ")]
        [Display(Name = "مساحة المحتوى")]
        public decimal ContentMeters { get; set; }

        [Required(ErrorMessage = "يجب عليك تحديد عدد المحتوى ")]
        [Display(Name = "عدد المحتوى")]
        public decimal ContentCount { get; set; }

        [Display(Name = "تفاصيل المحتوى")]
        public string ContentDetail { get; set; }

        [ForeignKey("ContentTypeId")]
        public ContentType ContentType { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }


    }
}