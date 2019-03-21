namespace RealEstateInvestment.dbcontainercofig
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "con.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "con.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.City", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "con.ContentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.CustomerPhone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PhoneTypeId = c.Int(nullable: false),
                        PhoneNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.Customer", t => t.CustomerId)
                .ForeignKey("con.PhoneType", t => t.PhoneTypeId)
                .Index(t => t.CustomerId)
                .Index(t => t.PhoneTypeId);
            
            CreateTable(
                "con.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameArab = c.String(nullable: false),
                        NameEng = c.String(nullable: false),
                        Address = c.String(),
                        IdNumber = c.String(),
                        IdissuePlace = c.String(),
                        IdExpiryDate = c.DateTime(),
                        Occupation = c.String(),
                        Email = c.String(),
                        NationalityId = c.Int(),
                        ReligionId = c.Int(),
                        IDTypeId = c.Int(),
                        CountryId = c.Int(),
                        CityId = c.Int(),
                        DistrictId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.City", t => t.CityId)
                .ForeignKey("con.Country", t => t.CountryId)
                .ForeignKey("con.District", t => t.DistrictId)
                .ForeignKey("con.Nationality", t => t.NationalityId)
                .ForeignKey("con.Religion", t => t.ReligionId)
                .ForeignKey("con.TypeId", t => t.IDTypeId)
                .Index(t => t.NationalityId)
                .Index(t => t.ReligionId)
                .Index(t => t.IDTypeId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "con.Nationality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.Religion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.TypeId",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.PhoneType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        ProjectOwner = c.String(nullable: false),
                        TransmissionDate = c.DateTime(),
                        Location = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.City", t => t.CityId)
                .ForeignKey("con.Country", t => t.CountryId)
                .ForeignKey("con.District", t => t.DistrictId)
                .Index(t => t.CountryId)
                .Index(t => t.DistrictId)
                .Index(t => t.CityId);
            
            CreateTable(
                "con.ProjectUnitType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ProjectUnitTypeName = c.String(nullable: false),
                        UnitTypeId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        FromNo = c.String(),
                        ToNo = c.String(),
                        ProjectUnitTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.Project", t => t.ProjectId)
                .ForeignKey("con.UnitType", t => t.UnitTypeId)
                .Index(t => t.ProjectId)
                .Index(t => t.UnitTypeId);
            
            CreateTable(
                "con.UnitType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitTypeName = c.String(nullable: false),
                        IsParent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.UnitContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentTypeId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        ContentMeters = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContentCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContentDetail = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.ContentType", t => t.ContentTypeId)
                .ForeignKey("con.Unit", t => t.UnitId)
                .Index(t => t.ContentTypeId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "con.Unit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectUnitTypeId = c.Int(nullable: false),
                        UnitName = c.String(nullable: false),
                        TotalMeters = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Garage = c.Boolean(nullable: false),
                        GarageMetes = c.Decimal(precision: 18, scale: 2),
                        GaragePrice = c.Decimal(precision: 18, scale: 2),
                        Perecent = c.Boolean(),
                        MaintenanceDeposit = c.Decimal(precision: 18, scale: 2),
                        MainUnitId = c.Int(),
                        ProjectId = c.Int(nullable: false),
                        UnitNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.Project", t => t.ProjectId)
                .ForeignKey("con.ProjectUnitType", t => t.ProjectUnitTypeId)
                .Index(t => t.ProjectUnitTypeId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("con.UnitContent", "UnitId", "con.Unit");
            DropForeignKey("con.Unit", "ProjectUnitTypeId", "con.ProjectUnitType");
            DropForeignKey("con.Unit", "ProjectId", "con.Project");
            DropForeignKey("con.UnitContent", "ContentTypeId", "con.ContentType");
            DropForeignKey("con.ProjectUnitType", "UnitTypeId", "con.UnitType");
            DropForeignKey("con.ProjectUnitType", "ProjectId", "con.Project");
            DropForeignKey("con.Project", "DistrictId", "con.District");
            DropForeignKey("con.Project", "CountryId", "con.Country");
            DropForeignKey("con.Project", "CityId", "con.City");
            DropForeignKey("con.CustomerPhone", "PhoneTypeId", "con.PhoneType");
            DropForeignKey("con.CustomerPhone", "CustomerId", "con.Customer");
            DropForeignKey("con.Customer", "IDTypeId", "con.TypeId");
            DropForeignKey("con.Customer", "ReligionId", "con.Religion");
            DropForeignKey("con.Customer", "NationalityId", "con.Nationality");
            DropForeignKey("con.Customer", "DistrictId", "con.District");
            DropForeignKey("con.Customer", "CountryId", "con.Country");
            DropForeignKey("con.Customer", "CityId", "con.City");
            DropForeignKey("con.District", "CityId", "con.City");
            DropForeignKey("con.City", "CountryId", "con.Country");
            DropIndex("con.Unit", new[] { "ProjectId" });
            DropIndex("con.Unit", new[] { "ProjectUnitTypeId" });
            DropIndex("con.UnitContent", new[] { "UnitId" });
            DropIndex("con.UnitContent", new[] { "ContentTypeId" });
            DropIndex("con.ProjectUnitType", new[] { "UnitTypeId" });
            DropIndex("con.ProjectUnitType", new[] { "ProjectId" });
            DropIndex("con.Project", new[] { "CityId" });
            DropIndex("con.Project", new[] { "DistrictId" });
            DropIndex("con.Project", new[] { "CountryId" });
            DropIndex("con.Customer", new[] { "DistrictId" });
            DropIndex("con.Customer", new[] { "CityId" });
            DropIndex("con.Customer", new[] { "CountryId" });
            DropIndex("con.Customer", new[] { "IDTypeId" });
            DropIndex("con.Customer", new[] { "ReligionId" });
            DropIndex("con.Customer", new[] { "NationalityId" });
            DropIndex("con.CustomerPhone", new[] { "PhoneTypeId" });
            DropIndex("con.CustomerPhone", new[] { "CustomerId" });
            DropIndex("con.District", new[] { "CityId" });
            DropIndex("con.City", new[] { "CountryId" });
            DropTable("con.Unit");
            DropTable("con.UnitContent");
            DropTable("con.UnitType");
            DropTable("con.ProjectUnitType");
            DropTable("con.Project");
            DropTable("con.PhoneType");
            DropTable("con.TypeId");
            DropTable("con.Religion");
            DropTable("con.Nationality");
            DropTable("con.Customer");
            DropTable("con.CustomerPhone");
            DropTable("con.ContentType");
            DropTable("con.District");
            DropTable("con.Country");
            DropTable("con.City");
        }
    }
}
