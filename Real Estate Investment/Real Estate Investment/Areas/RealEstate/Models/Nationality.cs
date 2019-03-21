using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Nationality")]
    public class Nationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="الكود")]
        public int Id { get; set; }

        [Display(Name = "الجنسية")]
        [Required(ErrorMessage = "يجب عليك ادخال الجنسية")]
        public string NationalityName { get; set; }

    }
}