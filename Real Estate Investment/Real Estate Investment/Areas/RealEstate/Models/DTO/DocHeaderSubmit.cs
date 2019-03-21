using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate.Models.DTO
{
    public class DocHeaderSubmit
    {
        public long Id { get; set; }

        [Display(Name = "مفتاح المستندات")]
        [Required(ErrorMessage = "يجب عليك تحديد مفتاح المستندات")]
        [Remote("IsDocHeaderIdAvailable", "Documents", ErrorMessage = "مفتاح المستندات غير موجود أوأنه لا يحتوي على مستندات")]
        public int DocHeaderId { get; set; }

        public string DocHeaderName { get; set; }
    }
}