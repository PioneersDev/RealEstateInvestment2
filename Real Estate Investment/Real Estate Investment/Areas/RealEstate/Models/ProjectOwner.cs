using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("ProjectOwner")]
    public class ProjectOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int ProjectOwnerId { get; set; }

        public string ProjectOwnerDelegateName { get; set; }

        public string ProjectOwnerDelegateRepresent { get; set; }

        [Required]
        public string ProjectOwnerDetails { get; set; }

        public bool IsMainOwner { get; set; }

        public int? MainOwnerId { get; set; }//---->this is land owner

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [ForeignKey("ProjectOwnerId")]
        public Owner ProjectOwnerObj { get; set; }

        [ForeignKey("MainOwnerId")]
        public Owner ProjectMainOwnerObj { get; set; }
    }
}