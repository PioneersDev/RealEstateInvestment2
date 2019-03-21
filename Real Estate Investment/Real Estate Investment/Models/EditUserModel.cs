using RealEstateInvestment.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    public class EditUserModel
    {
        public ApplicationUser user { get; set; }
        public string userRole { get; set; }
        public int userApplicationId { get; set; }
     
        public string DomainUser { get; set; }
        public string MachineName { get; set; }
        public string Machine_Ip { get; set; }
    }
}