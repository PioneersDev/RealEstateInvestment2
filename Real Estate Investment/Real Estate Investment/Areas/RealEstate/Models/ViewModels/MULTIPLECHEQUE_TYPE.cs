using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class MULTIPLECHEQUE_TYPE
    {
        public int InstallmentId { get; set; }
        public decimal SysAccount { get; set; }
        public DateTime ticketdate { get; set; }
        public Decimal accountid { get; set; }
        public string chequeno { get; set; }
        public string bankname { get; set; }
        public string bankbranch { get; set; }
        public DateTime duedate { get; set; }
        public decimal chequevalue { get; set; }
        public int currid { get; set; }
        public decimal currrate { get; set; }
        public string remarksa { get; set; }
        public string remarkse { get; set; }
        public string USERNAME { get; set; }
        public string MACHINEIP { get; set; }
        public string MACHINENAME { get; set; }
        public string LOGINUSER { get; set; }
        public string ACTIONTYPE { get; set; }
        public string COMPANYNAME { get; set; }
    }
}