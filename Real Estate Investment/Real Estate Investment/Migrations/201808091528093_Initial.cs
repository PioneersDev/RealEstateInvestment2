namespace RealEstateInvestment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "au.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "au.Menus",
                c => new
                    {
                        MENUID = c.Int(nullable: false, identity: true),
                        MENUNAME = c.String(),
                        MENUTEXT = c.String(),
                        MAINMENU = c.Int(),
                        SECTION = c.Int(),
                        SHOW = c.Boolean(),
                        ApplicationId = c.Int(),
                    })
                .PrimaryKey(t => t.MENUID)
                .ForeignKey("au.Applications", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "au.MENUFLAGs",
                c => new
                    {
                        FLAGID = c.Int(nullable: false, identity: true),
                        FLAGNAME = c.String(),
                        MENUID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FLAGID)
                .ForeignKey("au.Menus", t => t.MENUID, cascadeDelete: true)
                .Index(t => t.MENUID);
            
            CreateTable(
                "au.RoleApplications",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ApplicationId });
            
            CreateTable(
                "au.RoleMenus",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.MenuId });
            
            CreateTable(
                "au.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "au.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("au.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("au.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "au.UserApplications",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ApplicationId });
            
            CreateTable(
                "au.UserMenus",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.MenuId });
            
            CreateTable(
                "au.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "au.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("au.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "au.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("au.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("au.AspNetUserRoles", "UserId", "au.AspNetUsers");
            DropForeignKey("au.AspNetUserLogins", "UserId", "au.AspNetUsers");
            DropForeignKey("au.AspNetUserClaims", "UserId", "au.AspNetUsers");
            DropForeignKey("au.AspNetUserRoles", "RoleId", "au.AspNetRoles");
            DropForeignKey("au.MENUFLAGs", "MENUID", "au.Menus");
            DropForeignKey("au.Menus", "ApplicationId", "au.Applications");
            DropIndex("au.AspNetUserLogins", new[] { "UserId" });
            DropIndex("au.AspNetUserClaims", new[] { "UserId" });
            DropIndex("au.AspNetUsers", "UserNameIndex");
            DropIndex("au.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("au.AspNetUserRoles", new[] { "UserId" });
            DropIndex("au.AspNetRoles", "RoleNameIndex");
            DropIndex("au.MENUFLAGs", new[] { "MENUID" });
            DropIndex("au.Menus", new[] { "ApplicationId" });
            DropTable("au.AspNetUserLogins");
            DropTable("au.AspNetUserClaims");
            DropTable("au.AspNetUsers");
            DropTable("au.UserMenus");
            DropTable("au.UserApplications");
            DropTable("au.AspNetUserRoles");
            DropTable("au.AspNetRoles");
            DropTable("au.RoleMenus");
            DropTable("au.RoleApplications");
            DropTable("au.MENUFLAGs");
            DropTable("au.Menus");
            DropTable("au.Applications");
        }
    }
}
