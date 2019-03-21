using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public string MenuText { get; set; }

        public Nullable<int> MainMenu { get; set; }

        public Nullable<int> Section { get; set; }

        public Nullable<bool> Show { get; set; }

        public Nullable<int> ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }
    }
}