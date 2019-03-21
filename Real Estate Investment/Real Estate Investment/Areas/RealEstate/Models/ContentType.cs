using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("ContentType")]
    public class ContentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "كود المحتوى")]
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال نوع المحتوى")]
        [Display(Name = "نوع المحتوى")]
        public string ContentName { get; set; }
        //public string ContentDetail { get; set; }

    }
}