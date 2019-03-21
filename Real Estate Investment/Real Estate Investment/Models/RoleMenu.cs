using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("RoleMenu")]
    public class RoleMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int RoleId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public int MenuId { get; set; }

        [ForeignKey("RoleId")]
        public ApplicationRole Role { get; set; }

        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
    }
}