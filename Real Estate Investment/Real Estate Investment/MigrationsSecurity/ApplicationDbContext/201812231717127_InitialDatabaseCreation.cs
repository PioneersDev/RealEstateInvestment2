namespace RealEstateInvestment.MigrationsSecurity.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "au.Application",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApplicationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "au.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false),
                        MenuName = c.String(),
                        MenuText = c.String(),
                        MainMenu = c.Int(),
                        Section = c.Int(),
                        Show = c.Boolean(),
                        ApplicationId = c.Int(),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("au.Application", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "au.ApproveDefinition",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApprovName = c.String(),
                        TableName = c.String(),
                        SystemName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "au.ApproveDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApproveDefId = c.Int(nullable: false),
                        ApproveStepId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        AppDetailOrder = c.Int(nullable: false),
                        UserDesc = c.String(),
                        ActionTme = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("au.ApproveDefinition", t => t.ApproveDefId, cascadeDelete: true)
                .Index(t => t.ApproveDefId);
            
            CreateTable(
                "au.ApproveStep",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApproveDefinitionId = c.Int(nullable: false),
                        ApproveName = c.String(),
                        MenueName = c.String(),
                        ApproveOrder = c.Int(nullable: false),
                        MenuId = c.Int(),
                        ApproveSystemName = c.String(),
                        ApproveCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("au.ApproveDefinition", t => t.ApproveDefinitionId, cascadeDelete: true)
                .ForeignKey("au.Menu", t => t.MenuId)
                .Index(t => t.ApproveDefinitionId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "au.ApproveUser",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApproveStepId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("au.ApproveStep", t => t.ApproveStepId, cascadeDelete: true)
                .Index(t => t.ApproveStepId);
            
            CreateTable(
                "au.StepStatusDefinition",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApproveStepId = c.Int(nullable: false),
                        StatusName = c.String(),
                        Approved = c.Boolean(nullable: false),
                        Value = c.Int(nullable: false),
                        Binding = c.Boolean(nullable: false),
                        Reject = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("au.ApproveStep", t => t.ApproveStepId, cascadeDelete: true)
                .Index(t => t.ApproveStepId);
            
            CreateTable(
                "au.Company",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        CompanyName = c.String(),
                        ComponyConnectionString = c.String(),
                        ComponyLogo = c.Binary(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "au.UserCompany",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CompanyId })
                .ForeignKey("au.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "au.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "au.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "au.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "au.Request",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        UserId = c.Int(nullable: false),
                        RequestTypeId = c.Int(nullable: false),
                        RequestContent = c.String(nullable: false),
                        Step = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("au.RequestType", t => t.RequestTypeId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RequestTypeId);
            
            CreateTable(
                "au.RequestType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "au.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("au.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "au.UserApplication",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ApplicationId })
                .ForeignKey("au.Application", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "au.UserMenu",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.MenuId })
                .ForeignKey("au.Menu", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "au.UserNotification",
                c => new
                    {
                        NotificationId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        SeenAt = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.NotificationId, t.UserId })
                .ForeignKey("au.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("au.Notification", t => t.NotificationId, cascadeDelete: true)
                .Index(t => t.NotificationId)
                .Index(t => t.UserId);
            
            CreateTable(
                "au.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        MessageText = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        ActorId = c.Int(nullable: false),
                        ActorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "au.MenuFlag",
                c => new
                    {
                        FlagId = c.Int(nullable: false),
                        FlagName = c.String(),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlagId)
                .ForeignKey("au.Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "au.RoleApplication",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ApplicationId })
                .ForeignKey("au.Application", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("au.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "au.Role",
                c => new
                    {
                        Description = c.String(),
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "RoleNameIndex");
            
            CreateTable(
                "au.RoleMenu",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.MenuId })
                .ForeignKey("au.Menu", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("au.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("au.UserRole", "RoleId", "au.Role");
            DropForeignKey("au.RoleMenu", "RoleId", "au.Role");
            DropForeignKey("au.RoleMenu", "MenuId", "au.Menu");
            DropForeignKey("au.RoleApplication", "RoleId", "au.Role");
            DropForeignKey("au.RoleApplication", "ApplicationId", "au.Application");
            DropForeignKey("au.MenuFlag", "MenuId", "au.Menu");
            DropForeignKey("au.UserNotification", "NotificationId", "au.Notification");
            DropForeignKey("au.UserNotification", "UserId", "au.User");
            DropForeignKey("au.UserMenu", "UserId", "au.User");
            DropForeignKey("au.UserMenu", "MenuId", "au.Menu");
            DropForeignKey("au.UserCompany", "UserId", "au.User");
            DropForeignKey("au.UserApplication", "UserId", "au.User");
            DropForeignKey("au.UserApplication", "ApplicationId", "au.Application");
            DropForeignKey("au.UserRole", "UserId", "au.User");
            DropForeignKey("au.Request", "RequestTypeId", "au.RequestType");
            DropForeignKey("au.Request", "UserId", "au.User");
            DropForeignKey("au.UserLogin", "UserId", "au.User");
            DropForeignKey("au.UserClaim", "UserId", "au.User");
            DropForeignKey("au.UserCompany", "CompanyId", "au.Company");
            DropForeignKey("au.StepStatusDefinition", "ApproveStepId", "au.ApproveStep");
            DropForeignKey("au.ApproveStep", "MenuId", "au.Menu");
            DropForeignKey("au.ApproveUser", "ApproveStepId", "au.ApproveStep");
            DropForeignKey("au.ApproveStep", "ApproveDefinitionId", "au.ApproveDefinition");
            DropForeignKey("au.ApproveDetail", "ApproveDefId", "au.ApproveDefinition");
            DropForeignKey("au.Menu", "ApplicationId", "au.Application");
            DropIndex("au.RoleMenu", new[] { "MenuId" });
            DropIndex("au.RoleMenu", new[] { "RoleId" });
            DropIndex("au.Role", "RoleNameIndex");
            DropIndex("au.RoleApplication", new[] { "ApplicationId" });
            DropIndex("au.RoleApplication", new[] { "RoleId" });
            DropIndex("au.MenuFlag", new[] { "MenuId" });
            DropIndex("au.UserNotification", new[] { "UserId" });
            DropIndex("au.UserNotification", new[] { "NotificationId" });
            DropIndex("au.UserMenu", new[] { "MenuId" });
            DropIndex("au.UserMenu", new[] { "UserId" });
            DropIndex("au.UserApplication", new[] { "ApplicationId" });
            DropIndex("au.UserApplication", new[] { "UserId" });
            DropIndex("au.UserRole", new[] { "RoleId" });
            DropIndex("au.UserRole", new[] { "UserId" });
            DropIndex("au.Request", new[] { "RequestTypeId" });
            DropIndex("au.Request", new[] { "UserId" });
            DropIndex("au.UserLogin", new[] { "UserId" });
            DropIndex("au.UserClaim", new[] { "UserId" });
            DropIndex("au.User", "UserNameIndex");
            DropIndex("au.UserCompany", new[] { "CompanyId" });
            DropIndex("au.UserCompany", new[] { "UserId" });
            DropIndex("au.StepStatusDefinition", new[] { "ApproveStepId" });
            DropIndex("au.ApproveUser", new[] { "ApproveStepId" });
            DropIndex("au.ApproveStep", new[] { "MenuId" });
            DropIndex("au.ApproveStep", new[] { "ApproveDefinitionId" });
            DropIndex("au.ApproveDetail", new[] { "ApproveDefId" });
            DropIndex("au.Menu", new[] { "ApplicationId" });
            DropTable("au.RoleMenu");
            DropTable("au.Role");
            DropTable("au.RoleApplication");
            DropTable("au.MenuFlag");
            DropTable("au.Notification");
            DropTable("au.UserNotification");
            DropTable("au.UserMenu");
            DropTable("au.UserApplication");
            DropTable("au.UserRole");
            DropTable("au.RequestType");
            DropTable("au.Request");
            DropTable("au.UserLogin");
            DropTable("au.UserClaim");
            DropTable("au.User");
            DropTable("au.UserCompany");
            DropTable("au.Company");
            DropTable("au.StepStatusDefinition");
            DropTable("au.ApproveUser");
            DropTable("au.ApproveStep");
            DropTable("au.ApproveDetail");
            DropTable("au.ApproveDefinition");
            DropTable("au.Menu");
            DropTable("au.Application");
        }
    }
}
