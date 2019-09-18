namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMarketingCompanyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("con.MarketingCompany", "MarketingCompanyDelegateName", c => c.String());
            DropColumn("con.MarketingCompany", "ProjectOwnerDelegateName");
        }
        
        public override void Down()
        {
            AddColumn("con.MarketingCompany", "ProjectOwnerDelegateName", c => c.String());
            DropColumn("con.MarketingCompany", "MarketingCompanyDelegateName");
        }
    }
}
