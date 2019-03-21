using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("UnitType")]
    public class UnitType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="كود النوع")]
        public int Id { get; set; }

        [Required(ErrorMessage ="يجب ادخال النوع")]
        [Display(Name = "النوع")]
        public string UnitTypeName { get; set; }

        [Display(Name = "له وحدات تابعة؟")]
        public bool IsParent { get; set; }

        [Display(Name = "الوحدة الفرعية")]
        public int? SubUnitId { get; set; }

        [ForeignKey("SubUnitId")]
        public UnitType SubUnit { get; set; }
    }
}