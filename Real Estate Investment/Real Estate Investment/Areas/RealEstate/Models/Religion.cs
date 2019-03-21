using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Religion")]
    public class Religion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود الديانة")]
        public int Id { get; set; }

        [Display(Name = "الديانة")]
        public string ReligionName { get; set; }
    }
}