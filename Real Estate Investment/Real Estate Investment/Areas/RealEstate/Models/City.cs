using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("City")]
    public  class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="كود المدينة")]
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخال اسم المدينة")]
        [Display(Name = "اسم المدينة")]
        public string CityName { get; set; }

        [ForeignKey("Country")]
        [Required(ErrorMessage = "يجب عليك اختيار اسم الدولة")]
        [Display(Name = "اسم الدولة")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
    public class nullableDropDownList
    {
        public bool? Value { get; set; }
        public string Text { get; set; }
    }
}