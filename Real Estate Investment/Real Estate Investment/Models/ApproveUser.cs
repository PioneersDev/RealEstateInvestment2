using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("ApproveUser")]
    public class ApproveUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ApproveStepId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("ApproveStepId")]
        public ApproveStep ApproveStep { get; set; }

    }
}