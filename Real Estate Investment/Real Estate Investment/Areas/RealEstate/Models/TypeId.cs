using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("TypeId")]
    public class TypeId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الكود")]
        public int Id { get; set; }

        [Display(Name = "نوع الهوية")]
        [Required(ErrorMessage ="يجب ادخال نوع الهوية")]
        public string IdName { get; set; }

    }
}