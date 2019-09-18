namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTotalMetersToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("con.Unit", "TotalMeters", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("con.Unit", "TotalMeters", c => c.Int(nullable: false));
        }
    }
}
