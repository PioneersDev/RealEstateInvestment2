namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "con.City",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                        Id = c.Int(nullable: false),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.District",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                        Id = c.Int(nullable: false),
                        ContentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.ContractDeliverySpecification",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                        DeliverySpecificationString = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.Contract", t => t.ContractId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "con.Contract",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        SubCustomerId = c.String(),
                        ContractDate = c.DateTime(nullable: false),
                        PaymentMethodHeaderId = c.Int(nullable: false),
                        UnitTotalValue = c.Int(nullable: false),
                        DocHeaderId = c.Int(nullable: false),
                        ContractTypeId = c.Int(nullable: false),
                        ContractModelId = c.Int(nullable: false),
                        RequestId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.ContractModel", t => t.ContractModelId)
                .ForeignKey("con.ContractType", t => t.ContractTypeId)
                .ForeignKey("con.Customer", t => t.CustomerId)
                .ForeignKey("con.DocHeader", t => t.DocHeaderId)
                .ForeignKey("con.PaymentMethodHeader", t => t.PaymentMethodHeaderId)
                .ForeignKey("con.Project", t => t.ProjectId)
                .ForeignKey("con.Unit", t => t.UnitId)
                .Index(t => t.ProjectId)
                .Index(t => t.UnitId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentMethodHeaderId)
                .Index(t => t.DocHeaderId)
                .Index(t => t.ContractTypeId)
                .Index(t => t.ContractModelId);
            
            CreateTable(
                "con.ContractModel",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        ContractTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.ContractType", t => t.ContractTypeId)
                .Index(t => t.ContractTypeId);
            
            CreateTable(
                "con.ContractItem",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ContractItemName = c.String(nullable: false),
                        ContractItemString = c.String(nullable: false),
                        ContractModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.ContractModel", t => t.ContractModelId)
                .Index(t => t.ContractModelId);
            
            CreateTable(
                "con.ContractType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                "con.CustomerPhone",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                "con.PhoneType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PhoneTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.Nationality",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NationalityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.Religion",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.TypeId",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.DocHeader",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DocTypeId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.DocType", t => t.DocTypeId)
                .Index(t => t.DocTypeId);
            
            CreateTable(
                "con.DocDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Doc = c.Binary(nullable: false),
                        DocHeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.DocHeader", t => t.DocHeaderId)
                .Index(t => t.DocHeaderId);
            
            CreateTable(
                "con.DocType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.UnitDocument",
                c => new
                    {
                        UnitId = c.Int(nullable: false),
                        DocHeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UnitId, t.DocHeaderId })
                .ForeignKey("con.DocHeader", t => t.DocHeaderId)
                .ForeignKey("con.Unit", t => t.UnitId)
                .Index(t => t.UnitId)
                .Index(t => t.DocHeaderId);
            
            CreateTable(
                "con.Unit",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProjectUnitTypeId = c.Int(nullable: false),
                        UnitName = c.String(nullable: false),
                        TotalMeters = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeterPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Garage = c.Boolean(nullable: false),
                        GarageMetes = c.Decimal(precision: 18, scale: 2),
                        GaragePrice = c.Decimal(precision: 18, scale: 2),
                        Perecent = c.Boolean(),
                        MaintenanceDeposit = c.Decimal(precision: 18, scale: 2),
                        MainUnitId = c.Int(),
                        ProjectId = c.Int(nullable: false),
                        UnitNo = c.String(),
                        UnitContractAddress = c.String(),
                        FloorNumber = c.Int(),
                        StatusId = c.Int(nullable: false),
                        DocHeaderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.DocHeader", t => t.DocHeaderId)
                .ForeignKey("con.Project", t => t.ProjectId)
                .ForeignKey("con.ProjectUnitType", t => t.ProjectUnitTypeId)
                .ForeignKey("con.Status", t => t.StatusId)
                .Index(t => t.ProjectUnitTypeId)
                .Index(t => t.ProjectId)
                .Index(t => t.StatusId)
                .Index(t => t.DocHeaderId);
            
            CreateTable(
                "con.Project",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProjectName = c.String(nullable: false),
                        TransmissionDate = c.DateTime(),
                        ProjectDescription = c.String(nullable: false),
                        ProjectContentDetails = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        DocHeaderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.City", t => t.CityId)
                .ForeignKey("con.Country", t => t.CountryId)
                .ForeignKey("con.District", t => t.DistrictId)
                .ForeignKey("con.DocHeader", t => t.DocHeaderId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.DistrictId)
                .Index(t => t.DocHeaderId);
            
            CreateTable(
                "con.ProjectUnitType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ProjectUnitTypeName = c.String(nullable: false),
                        UnitTypeId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        NameContain = c.Int(nullable: false),
                        NumStartFrom = c.Int(),
                        CharStartFrom = c.String(),
                        NameIncrementIn = c.Int(nullable: false),
                        NameIncrement = c.Int(nullable: false),
                        MainUnitSubUnitsNum = c.Int(),
                        ProjectUnitTypeDescription = c.String(),
                        DocHeaderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.DocHeader", t => t.DocHeaderId)
                .ForeignKey("con.Project", t => t.ProjectId)
                .ForeignKey("con.UnitType", t => t.UnitTypeId)
                .Index(t => t.ProjectId)
                .Index(t => t.UnitTypeId)
                .Index(t => t.DocHeaderId);
            
            CreateTable(
                "con.UnitType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UnitTypeName = c.String(nullable: false),
                        IsParent = c.Boolean(nullable: false),
                        SubUnitId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.UnitType", t => t.SubUnitId)
                .Index(t => t.SubUnitId);
            
            CreateTable(
                "con.Status",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.UnitContent",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                "con.PaymentMethodHeader",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        TotalYearPeriod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.PaymentMethodDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PaymentMethodHeaderId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        IsRatioNotAmount = c.Boolean(nullable: false),
                        Ratio = c.Decimal(precision: 18, scale: 2),
                        MinimumAmount = c.Int(),
                        StartFrom = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                        PaymentsCounts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.PaymentMethodHeader", t => t.PaymentMethodHeaderId)
                .ForeignKey("con.PaymentType", t => t.PaymentTypeId)
                .Index(t => t.PaymentMethodHeaderId)
                .Index(t => t.PaymentTypeId);
            
            CreateTable(
                "con.PaymentType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        PayAddition = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.ContractSys",
                c => new
                    {
                        VarId = c.Int(nullable: false),
                        VarName = c.String(),
                        VarDescription = c.String(nullable: false),
                        VarValue = c.String(nullable: false),
                        VarType = c.String(nullable: false),
                        IsTafqet = c.Boolean(nullable: false),
                        IsMoney = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VarId);
            
            CreateTable(
                "con.Installment",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        PaymentMethodDetailId = c.Int(nullable: false),
                        Serial = c.Int(nullable: false),
                        PayDate = c.DateTime(nullable: false),
                        PayValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayNote = c.String(),
                        TransactionDate = c.DateTime(),
                        IsPaid = c.Boolean(nullable: false),
                        RefId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.Contract", t => t.ContractId)
                .ForeignKey("con.Customer", t => t.CustomerId)
                .ForeignKey("con.PaymentMethodDetail", t => t.PaymentMethodDetailId)
                .Index(t => t.ContractId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentMethodDetailId);
            
            CreateTable(
                "con.Owner",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "con.ProjectOwner",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ProjectOwnerId = c.Int(nullable: false),
                        ProjectOwnerDelegateName = c.String(),
                        ProjectOwnerDelegateRepresent = c.String(),
                        ProjectOwnerDetails = c.String(nullable: false),
                        IsMainOwner = c.Boolean(nullable: false),
                        MainOwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("con.Project", t => t.ProjectId)
                .ForeignKey("con.Owner", t => t.MainOwnerId)
                .ForeignKey("con.Owner", t => t.ProjectOwnerId)
                .Index(t => t.ProjectId)
                .Index(t => t.ProjectOwnerId)
                .Index(t => t.MainOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("con.ProjectOwner", "ProjectOwnerId", "con.Owner");
            DropForeignKey("con.ProjectOwner", "MainOwnerId", "con.Owner");
            DropForeignKey("con.ProjectOwner", "ProjectId", "con.Project");
            DropForeignKey("con.Installment", "PaymentMethodDetailId", "con.PaymentMethodDetail");
            DropForeignKey("con.Installment", "CustomerId", "con.Customer");
            DropForeignKey("con.Installment", "ContractId", "con.Contract");
            DropForeignKey("con.ContractDeliverySpecification", "ContractId", "con.Contract");
            DropForeignKey("con.Contract", "UnitId", "con.Unit");
            DropForeignKey("con.Contract", "ProjectId", "con.Project");
            DropForeignKey("con.Contract", "PaymentMethodHeaderId", "con.PaymentMethodHeader");
            DropForeignKey("con.PaymentMethodDetail", "PaymentTypeId", "con.PaymentType");
            DropForeignKey("con.PaymentMethodDetail", "PaymentMethodHeaderId", "con.PaymentMethodHeader");
            DropForeignKey("con.Contract", "DocHeaderId", "con.DocHeader");
            DropForeignKey("con.UnitDocument", "UnitId", "con.Unit");
            DropForeignKey("con.UnitContent", "UnitId", "con.Unit");
            DropForeignKey("con.UnitContent", "ContentTypeId", "con.ContentType");
            DropForeignKey("con.Unit", "StatusId", "con.Status");
            DropForeignKey("con.Unit", "ProjectUnitTypeId", "con.ProjectUnitType");
            DropForeignKey("con.ProjectUnitType", "UnitTypeId", "con.UnitType");
            DropForeignKey("con.UnitType", "SubUnitId", "con.UnitType");
            DropForeignKey("con.ProjectUnitType", "ProjectId", "con.Project");
            DropForeignKey("con.ProjectUnitType", "DocHeaderId", "con.DocHeader");
            DropForeignKey("con.Unit", "ProjectId", "con.Project");
            DropForeignKey("con.Project", "DocHeaderId", "con.DocHeader");
            DropForeignKey("con.Project", "DistrictId", "con.District");
            DropForeignKey("con.Project", "CountryId", "con.Country");
            DropForeignKey("con.Project", "CityId", "con.City");
            DropForeignKey("con.Unit", "DocHeaderId", "con.DocHeader");
            DropForeignKey("con.UnitDocument", "DocHeaderId", "con.DocHeader");
            DropForeignKey("con.DocHeader", "DocTypeId", "con.DocType");
            DropForeignKey("con.DocDetail", "DocHeaderId", "con.DocHeader");
            DropForeignKey("con.Contract", "CustomerId", "con.Customer");
            DropForeignKey("con.Customer", "IDTypeId", "con.TypeId");
            DropForeignKey("con.Customer", "ReligionId", "con.Religion");
            DropForeignKey("con.Customer", "NationalityId", "con.Nationality");
            DropForeignKey("con.Customer", "DistrictId", "con.District");
            DropForeignKey("con.CustomerPhone", "PhoneTypeId", "con.PhoneType");
            DropForeignKey("con.CustomerPhone", "CustomerId", "con.Customer");
            DropForeignKey("con.Customer", "CountryId", "con.Country");
            DropForeignKey("con.Customer", "CityId", "con.City");
            DropForeignKey("con.Contract", "ContractTypeId", "con.ContractType");
            DropForeignKey("con.Contract", "ContractModelId", "con.ContractModel");
            DropForeignKey("con.ContractModel", "ContractTypeId", "con.ContractType");
            DropForeignKey("con.ContractItem", "ContractModelId", "con.ContractModel");
            DropForeignKey("con.District", "CityId", "con.City");
            DropForeignKey("con.City", "CountryId", "con.Country");
            DropIndex("con.ProjectOwner", new[] { "MainOwnerId" });
            DropIndex("con.ProjectOwner", new[] { "ProjectOwnerId" });
            DropIndex("con.ProjectOwner", new[] { "ProjectId" });
            DropIndex("con.Installment", new[] { "PaymentMethodDetailId" });
            DropIndex("con.Installment", new[] { "CustomerId" });
            DropIndex("con.Installment", new[] { "ContractId" });
            DropIndex("con.PaymentMethodDetail", new[] { "PaymentTypeId" });
            DropIndex("con.PaymentMethodDetail", new[] { "PaymentMethodHeaderId" });
            DropIndex("con.UnitContent", new[] { "UnitId" });
            DropIndex("con.UnitContent", new[] { "ContentTypeId" });
            DropIndex("con.UnitType", new[] { "SubUnitId" });
            DropIndex("con.ProjectUnitType", new[] { "DocHeaderId" });
            DropIndex("con.ProjectUnitType", new[] { "UnitTypeId" });
            DropIndex("con.ProjectUnitType", new[] { "ProjectId" });
            DropIndex("con.Project", new[] { "DocHeaderId" });
            DropIndex("con.Project", new[] { "DistrictId" });
            DropIndex("con.Project", new[] { "CityId" });
            DropIndex("con.Project", new[] { "CountryId" });
            DropIndex("con.Unit", new[] { "DocHeaderId" });
            DropIndex("con.Unit", new[] { "StatusId" });
            DropIndex("con.Unit", new[] { "ProjectId" });
            DropIndex("con.Unit", new[] { "ProjectUnitTypeId" });
            DropIndex("con.UnitDocument", new[] { "DocHeaderId" });
            DropIndex("con.UnitDocument", new[] { "UnitId" });
            DropIndex("con.DocDetail", new[] { "DocHeaderId" });
            DropIndex("con.DocHeader", new[] { "DocTypeId" });
            DropIndex("con.CustomerPhone", new[] { "PhoneTypeId" });
            DropIndex("con.CustomerPhone", new[] { "CustomerId" });
            DropIndex("con.Customer", new[] { "DistrictId" });
            DropIndex("con.Customer", new[] { "CityId" });
            DropIndex("con.Customer", new[] { "CountryId" });
            DropIndex("con.Customer", new[] { "IDTypeId" });
            DropIndex("con.Customer", new[] { "ReligionId" });
            DropIndex("con.Customer", new[] { "NationalityId" });
            DropIndex("con.ContractItem", new[] { "ContractModelId" });
            DropIndex("con.ContractModel", new[] { "ContractTypeId" });
            DropIndex("con.Contract", new[] { "ContractModelId" });
            DropIndex("con.Contract", new[] { "ContractTypeId" });
            DropIndex("con.Contract", new[] { "DocHeaderId" });
            DropIndex("con.Contract", new[] { "PaymentMethodHeaderId" });
            DropIndex("con.Contract", new[] { "CustomerId" });
            DropIndex("con.Contract", new[] { "UnitId" });
            DropIndex("con.Contract", new[] { "ProjectId" });
            DropIndex("con.ContractDeliverySpecification", new[] { "ContractId" });
            DropIndex("con.District", new[] { "CityId" });
            DropIndex("con.City", new[] { "CountryId" });
            DropTable("con.ProjectOwner");
            DropTable("con.Owner");
            DropTable("con.Installment");
            DropTable("con.ContractSys");
            DropTable("con.PaymentType");
            DropTable("con.PaymentMethodDetail");
            DropTable("con.PaymentMethodHeader");
            DropTable("con.UnitContent");
            DropTable("con.Status");
            DropTable("con.UnitType");
            DropTable("con.ProjectUnitType");
            DropTable("con.Project");
            DropTable("con.Unit");
            DropTable("con.UnitDocument");
            DropTable("con.DocType");
            DropTable("con.DocDetail");
            DropTable("con.DocHeader");
            DropTable("con.TypeId");
            DropTable("con.Religion");
            DropTable("con.Nationality");
            DropTable("con.PhoneType");
            DropTable("con.CustomerPhone");
            DropTable("con.Customer");
            DropTable("con.ContractType");
            DropTable("con.ContractItem");
            DropTable("con.ContractModel");
            DropTable("con.Contract");
            DropTable("con.ContractDeliverySpecification");
            DropTable("con.ContentType");
            DropTable("con.District");
            DropTable("con.Country");
            DropTable("con.City");
        }
    }
}
