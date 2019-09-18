namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarktingCompanyToContractAndAddTicketIdAndTiketDateAndJornalIdToContractAndInstallment : DbMigration
    {
        public override void Up()
        {
            AddColumn("con.Contract", "MarketingCompanyId", c => c.Int(nullable: false));
            AddColumn("con.Contract", "MarketingCompanyPayValue", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("con.Contract", "JOURNALID", c => c.Int());
            AddColumn("con.Contract", "TICKETID", c => c.Int());
            AddColumn("con.Contract", "TICKETDATE", c => c.DateTime());
            AddColumn("con.Installment", "PayProperty", c => c.Int(nullable: false));
            AddColumn("con.Installment", "JOURNALID", c => c.Int());
            AddColumn("con.Installment", "TICKETID", c => c.Int());
            AddColumn("con.Installment", "TICKETDATE", c => c.DateTime());
            CreateIndex("con.Contract", "MarketingCompanyId");
            AddForeignKey("con.Contract", "MarketingCompanyId", "con.MarketingCompany", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("con.Contract", "MarketingCompanyId", "con.MarketingCompany");
            DropIndex("con.Contract", new[] { "MarketingCompanyId" });
            DropColumn("con.Installment", "TICKETDATE");
            DropColumn("con.Installment", "TICKETID");
            DropColumn("con.Installment", "JOURNALID");
            DropColumn("con.Installment", "PayProperty");
            DropColumn("con.Contract", "TICKETDATE");
            DropColumn("con.Contract", "TICKETID");
            DropColumn("con.Contract", "JOURNALID");
            DropColumn("con.Contract", "MarketingCompanyPayValue");
            DropColumn("con.Contract", "MarketingCompanyId");
        }
    }
}
