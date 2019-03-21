using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string ComponyConnectionString { get; set; }

        public byte[] ComponyLogo { get; set; }

        public ICollection<UserCompany> CompanyUsers { get; set; }
    }
}