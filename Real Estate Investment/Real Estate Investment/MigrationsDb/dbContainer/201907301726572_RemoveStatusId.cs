namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStatusId : DbMigration
    {
        public override void Up()
        {
            DropColumn("con.Installment", "STATUSID");
        }
        
        public override void Down()
        {
            AddColumn("con.Installment", "STATUSID", c => c.Int());
        }
    }
}
