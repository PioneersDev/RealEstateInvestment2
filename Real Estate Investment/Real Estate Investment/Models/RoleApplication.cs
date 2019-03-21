using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("RoleApplication")]
    public class RoleApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int RoleId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public int ApplicationId { get; set; }

        [ForeignKey("RoleId")]
        public ApplicationRole Role { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }
    }
}