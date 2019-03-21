using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("District")]
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود المركز")]
        public int Id { get; set; }
        [Required(ErrorMessage ="يجب عليك ادخال اسم المركز")]
        [Display(Name = "اسم المركز")]
        public string DistrictName { get; set; }
        [ForeignKey("City")]
        [Required(ErrorMessage = "يجب عليك اختيار اسم المدينة")]
        [Display(Name = "اسم المدينة")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        [NotMapped]
        public int CountryId { get; set; }
    }
}