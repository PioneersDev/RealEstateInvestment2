using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class ContractDeliverySpecification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الكود")]
        public int Id { get; set; }

        public int ContractId { get; set; }

        [Required]
        public string DeliverySpecificationString { get; set; }

        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
    }
}