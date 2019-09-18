namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("con.Customer", "CustomerAccount", c => c.Decimal(precision: 19, scale: 0));
        }
        
        public override void Down()
        {
            DropColumn("con.Customer", "CustomerAccount");
        }
    }
}
