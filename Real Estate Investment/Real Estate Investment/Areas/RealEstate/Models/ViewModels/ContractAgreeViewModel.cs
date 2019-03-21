using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class ContractAgreeViewModel
    {
        public int Id { get; set; }
        public bool IsApprove { get; set; }

        [Display(Name ="ملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}