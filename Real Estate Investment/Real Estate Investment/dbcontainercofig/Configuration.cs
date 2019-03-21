using RealEstateInvestment.Areas.RealEstate.Models;

namespace RealEstateInvestment.dbcontainercofig
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class dbonDbConfig : DbMigrationsConfiguration<RealEstateInvestment.Areas.RealEstate.Models.dbContainer>
    {
        public dbonDbConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"dbcontainercofig";
        }

        protected override void Seed(RealEstateInvestment.Areas.RealEstate.Models.dbContainer context)
        {


            context.Religions.AddOrUpdate(p => p.Id, new Religion { Id = 1, ReligionName = "«·«”·«„" },
                new Religion { Id = 2, ReligionName = "«·„”ÌÕÌ…" });
            context.PhoneTypes.AddOrUpdate(p => p.Id, new PhoneType { Id = 1, PhoneTypeName = "„Ê»«Ì·" },
                new PhoneType { Id = 2, PhoneTypeName = "√—÷Ì" });
            context.Nationalitys.AddOrUpdate(p => p.Id, new Nationality { Id = 1, NationalityName = "„’—Ì/„’—Ì…" });
            context.TypeIds.AddOrUpdate(p => p.Id, new TypeId { Id = 1, IdName = "»ÿ«ﬁ…" },
                new TypeId { Id = 2, IdName = "ÃÊ«“ ”›—" });


            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }
}
