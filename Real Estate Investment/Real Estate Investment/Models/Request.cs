using RealEstateInvestment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("Request")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RequestTypeId { get; set; }

        [Required]
        public string RequestContent { get; set; }

        [Required]
        public int Step { get; set; }

        [Required]
        public int Status { get; set; }

        public String Remarks { get; set; }

        [ForeignKey("RequestTypeId")]
        public RequestType RequestType { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}