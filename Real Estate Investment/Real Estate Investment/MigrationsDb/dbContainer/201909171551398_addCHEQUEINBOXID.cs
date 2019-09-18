namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCHEQUEINBOXID : DbMigration
    {
        public override void Up()
        {
            AddColumn("con.Installment", "CHEQUEINBOXID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("con.Installment", "CHEQUEINBOXID");
        }
    }
}
