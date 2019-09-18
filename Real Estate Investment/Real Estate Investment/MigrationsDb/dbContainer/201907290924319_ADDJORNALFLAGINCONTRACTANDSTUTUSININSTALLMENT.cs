namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDJORNALFLAGINCONTRACTANDSTUTUSININSTALLMENT : DbMigration
    {
        public override void Up()
        {
            AddColumn("con.Installment", "STATUSID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("con.Installment", "STATUSID");
        }
    }
}
