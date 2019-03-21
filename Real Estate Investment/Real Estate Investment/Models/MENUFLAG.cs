using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("MenuFlag")]
    public class MenuFlag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlagId { get; set; }

        public string FlagName { get; set; }

        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
    }
}