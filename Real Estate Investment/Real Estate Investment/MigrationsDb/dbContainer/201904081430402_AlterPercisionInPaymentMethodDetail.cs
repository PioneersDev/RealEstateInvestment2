namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPercisionInPaymentMethodDetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("con.PaymentMethodDetail", "Ratio", c => c.Decimal(precision: 12, scale: 10));
        }
        
        public override void Down()
        {
            AlterColumn("con.PaymentMethodDetail", "Ratio", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
