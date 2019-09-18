namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketingCompanyAndPaymentTypePropertyTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "con.PaymentTypeProperty",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.MarketingCompany",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        ProjectOwnerDelegateName = c.String(),
                        Address = c.String(),
                        CompanyPhones = c.String(),
                        AccountNumber = c.Decimal(precision: 19, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("con.Customer", "AccountNumber", c => c.Decimal(precision: 19, scale: 0));
            AddColumn("con.PaymentType", "PaymentTypePropertyId", c => c.Byte());
            CreateIndex("con.PaymentType", "PaymentTypePropertyId");
            AddForeignKey("con.PaymentType", "PaymentTypePropertyId", "con.PaymentTypeProperty", "Id");
            DropColumn("con.Customer", "CustomerAccount");
            DropColumn("con.PaymentType", "PayAddition");
        }
        
        public override void Down()
        {
            AddColumn("con.PaymentType", "PayAddition", c => c.Boolean(nullable: false));
            AddColumn("con.Customer", "CustomerAccount", c => c.Decimal(precision: 19, scale: 0));
            DropForeignKey("con.PaymentType", "PaymentTypePropertyId", "con.PaymentTypeProperty");
            DropIndex("con.PaymentType", new[] { "PaymentTypePropertyId" });
            DropColumn("con.PaymentType", "PaymentTypePropertyId");
            DropColumn("con.Customer", "AccountNumber");
            DropTable("con.MarketingCompany");
            DropTable("con.PaymentTypeProperty");
        }
    }
}
