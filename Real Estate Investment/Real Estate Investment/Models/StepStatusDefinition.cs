using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("StepStatusDefinition")]
    public class StepStatusDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ApproveStepId { get; set; }
        public string StatusName { get; set; }
        public bool Approved { get; set; }
        public int Value { get; set; }
        public bool Binding { get; set; }
        public bool Reject { get; set; }

        [ForeignKey("ApproveStepId")]
        public virtual ApproveStep ApproveStep { get; set; }
    }
}