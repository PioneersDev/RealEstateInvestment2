using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class AccountOperationResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public decimal AccountId { get; set; }
    }
    public class AccountOperationParams
    {
        public long? CustomerId { get; set; }
        public string CustomerNameA { get; set; }
        public string CustomerNameE { get; set; }
        public string Operation { get; set; }
        public string UserName { get; set; }
        public string MachineIp { get; set; }
        public string MachineName { get; set; }
        public string LoginUser { get; set; }
        public decimal? CustomerAccount { get; set; }
        public string CompanyName { get; set; }
    }
}