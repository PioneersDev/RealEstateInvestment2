using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="كود الدولة")]
        public int Id { get; set; }
        [Required(ErrorMessage ="يجب عليك ادخال اسم الدولة")]
        [Display(Name = "اسم الدولة")]
        public string CountryName { get; set; }
        public virtual ICollection<City> Cities { get; set; }

    }
}