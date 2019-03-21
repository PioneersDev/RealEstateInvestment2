using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("ApproveDetail")]
    public class ApproveDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ApproveDefId { get; set; }
        public int ApproveStepId { get; set; }
        public int StatusId { get; set; }
        public int AppDetailOrder { get; set; }
        public string UserDesc { get; set; }
        public DateTime ActionTme { get; set; }

        [ForeignKey("ApproveDefId")]
        public ApproveDefinition ApproveDefinition { get; set; }
    }
}