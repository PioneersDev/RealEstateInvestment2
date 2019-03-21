using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("UnitDocument")]
    public class UnitDocument
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DocHeaderId { get; set; }

        [ForeignKey("DocHeaderId")]
        public DocHeader DocHeader { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
    }
}