using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ViewModels
{
    public class CreateJournalEntriesParams
    {
        public int ContractId { get; set; }
        public int BRANCHID { get; set; }
        public DateTime TICKETDATE { get; set; }
        public string REMARKSA { get; set; }
        public string REMARKSE { get; set; }
        public string userdesc { get; set; }
        public int isallokupdate { get; set; }
        public List<DETAIL_TYPE> dETAIL_TYPEs { get; set; }
        public List<MULTIPLECHEQUE_TYPE> mULTIPLECHEQUE_TYPEs { get; set; }
        public string CompanyName { get; set; }
    }
    public class CreateJournalEntriesResult
    {
        public bool STATUS { get; set; }
        public string MESSAGE { get; set; }
    }
}