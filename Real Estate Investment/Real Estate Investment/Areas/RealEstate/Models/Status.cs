using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="الكود")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "الحالة")]
        public string Name { get; set; }
    }
}