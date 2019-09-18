namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRECEIVINGJOURNALID : DbMigration
    {
        public override void Up()
        {
            AddColumn("con.Installment", "RECEIVINGJOURNALID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("con.Installment", "RECEIVINGJOURNALID");
        }
    }
}
