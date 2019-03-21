using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("DocDetail")]
    public class DocDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الكود")]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم الصفحة")]
        [Display(Name = "اسم الصفحة")]
        public string Name { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار الصفحة")]
        [Display(Name = "الصفحة")]
        public byte[] Doc { get; set; }

        [Required]
        public int DocHeaderId { get; set; }

        [ForeignKey("DocHeaderId")]
        public DocHeader DocHeader { get; set; }
    }
}