using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("ApproveDefinition")]
    public class ApproveDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string ApprovName { get; set; }

        public string TableName { get; set; }

        public string SystemName { get; set; }

        public ICollection<ApproveDetail> ApproveDetails { get; set; }
        public ICollection<ApproveStep> ApproveSteps { get; set; }
    }
}