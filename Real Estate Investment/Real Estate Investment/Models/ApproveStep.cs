using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("ApproveStep")]
    public class ApproveStep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ApproveDefinitionId { get; set; }
        public string ApproveName { get; set; }
        public string MenueName { get; set; }
        public int ApproveOrder { get; set; }
        public Nullable<int> MenuId { get; set; }
        public string ApproveSystemName { get; set; }
        public int ApproveCount { get; set; }

        [ForeignKey("ApproveDefinitionId")]
        public ApproveDefinition ApproveDefinition { get; set; }

        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }

        public ICollection<StepStatusDefinition> StepStatuses { get; set; }
        public ICollection<ApproveUser> ApproveUsers { get; set; }
    }
}