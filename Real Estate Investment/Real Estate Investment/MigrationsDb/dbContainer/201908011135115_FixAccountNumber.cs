namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAccountNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("con.Project", "MintananceAccount", c => c.Int(nullable: false));
            AlterColumn("con.Project", "InstallmentAccount", c => c.Int(nullable: false));
            AlterColumn("con.MarketingCompany", "AccountNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("con.MarketingCompany", "AccountNumber", c => c.Decimal(nullable: false, precision: 19, scale: 0));
            AlterColumn("con.Project", "InstallmentAccount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("con.Project", "MintananceAccount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
