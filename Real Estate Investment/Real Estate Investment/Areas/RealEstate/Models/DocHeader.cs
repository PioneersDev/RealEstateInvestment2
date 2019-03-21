using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    [Table("DocHeader")]
    public class DocHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الكود")]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم المستند")]
        [StringLength(200)]
        [Display(Name = "اسم المستند")]
        public string Name { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار نوع المستند")]
        [Display(Name = "نوع المستند")]
        public int DocTypeId { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "ملاحظات")]
        public string Notes { get; set; }

        [ForeignKey("DocTypeId")]
        public DocType DocType { get; set; }

        public ICollection<DocDetail> DocDetails { get; set; }

        public ICollection<UnitDocument> UnitDocuments { get; set; }
    }
}