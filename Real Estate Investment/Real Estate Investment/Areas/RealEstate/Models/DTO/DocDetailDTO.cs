using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class DocDetailDTO
    {
        [Display(Name = "الكود")]
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخال اسم الصفحة")]
        [Display(Name = "اسم الصفحة")]
        public string Name { get; set; }

        [Required(ErrorMessage = "يجب عليك اختيار الصفحة")]
        [Display(Name = "الصفحة")]
        public byte[] Doc { get; set; }

        public int DocHeaderId { get; set; }
    }
}