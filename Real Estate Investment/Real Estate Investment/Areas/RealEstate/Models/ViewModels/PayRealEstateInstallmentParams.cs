using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class PayRealEstateInstallmentParams
    {
        public int InstallmentId { get; set; }
        public int TicketId { get; set; }
        public List<MULTIPLECHEQUE_TYPE> mULTIPLECHEQUE_TYPE { get; set; }
        public string CompanyName { get; set; }
    }
}