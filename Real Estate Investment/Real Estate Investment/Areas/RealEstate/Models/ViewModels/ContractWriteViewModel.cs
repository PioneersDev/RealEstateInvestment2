using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class ContractWriteViewModel
    {
        public int Id { get; set; }
        public List<ContractSys> Variables { get; set; }
        public ContractRequestViewModel ContractRequest { get; set; }
        public List<ContractItem> ContractItemsTranslated { get; set; }
        public Project project { get; set; }
        public Unit unit { get; set; }
        public Customer customer { get; set; }
        public ProjectOwner projectOwner { get; set; }
    }
}