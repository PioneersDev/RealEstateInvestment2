namespace RealEstateInvestment.MigrationsSecurity.ApplicationDbContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RealEstateInvestment.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"MigrationsSecurity\ApplicationDbContext";

        }

        protected override void Seed(ApplicationDbContext context)
        {
              //This method will be called after migrating to the latest version.
              //You can use the DbSet<T>.AddOrUpdate() helper extension method 
              //to avoid creating duplicate seed data.
            //context.Applications.AddOrUpdate(p => p.Id, new Application { Id = 1, ApplicationName = "RealEstate" });
            //context.Menus.AddOrUpdate(p => p.MenuId
            //, new Menu { MenuId = 1, ApplicationId = 1, MenuName = "", MenuText = "���������", MainMenu = -1, Section = null, Show = true }
            //, new Menu { MenuId = 2, ApplicationId = 1, MenuName = "/User/Index", MenuText = "����������", MainMenu = 1, Section = null, Show = true }
            //, new Menu { MenuId = 3, ApplicationId = 1, MenuName = "/Roles/Index", MenuText = "���������", MainMenu = 1, Section = null, Show = true }
            //, new Menu { MenuId = 4, ApplicationId = 1, MenuName = "", MenuText = "������ ��������� ��������", MainMenu = -1, Section = null, Show = true }
            //, new Menu { MenuId = 5, ApplicationId = 1, MenuName = "", MenuText = "�����", MainMenu = 4, Section = null, Show = true }
            //, new Menu { MenuId = 6, ApplicationId = 1, MenuName = "/RealEstate/Owners/Index", MenuText = "������", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 7, ApplicationId = 1, MenuName = "/RealEstate/Customers/Index", MenuText = "�����", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 8, ApplicationId = 1, MenuName = "/RealEstate/Projects/ProjectsIndex", MenuText = "������", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 9, ApplicationId = 1, MenuName = "/RealEstate/Units/Index", MenuText = "�����", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 10, ApplicationId = 1, MenuName = "/RealEstate/Types/UnitTypeIndex", MenuText = "����� �����", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 11, ApplicationId = 1, MenuName = "/RealEstate/Types/ContentTypeIndex", MenuText = "������� �������", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 12, ApplicationId = 1, MenuName = "/RealEstate/Nationalties/Index", MenuText = "������", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 13, ApplicationId = 1, MenuName = "/RealEstate/IdsTypes/Index", MenuText = "�����", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 14, ApplicationId = 1, MenuName = "/RealEstate/Status/Index", MenuText = "����� ������", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 15, ApplicationId = 1, MenuName = "", MenuText = "�����", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 16, ApplicationId = 1, MenuName = "/RealEstate/Locations/CountryIndex", MenuText = "����", MainMenu = 15, Section = null, Show = true }
            //, new Menu { MenuId = 17, ApplicationId = 1, MenuName = "/RealEstate/Locations/CityIndex", MenuText = "�����", MainMenu = 15, Section = null, Show = true }
            //, new Menu { MenuId = 18, ApplicationId = 1, MenuName = "/RealEstate/Locations/DistrictIndex", MenuText = "���� / ��", MainMenu = 15, Section = null, Show = true }
            //, new Menu { MenuId = 19, ApplicationId = 1, MenuName = "", MenuText = "����� �����", MainMenu = 5, Section = null, Show = true }
            //, new Menu { MenuId = 20, ApplicationId = 1, MenuName = "/RealEstate/Payments/PaymentTypeIndex", MenuText = "����� �������", MainMenu = 19, Section = null, Show = true }
            //, new Menu { MenuId = 21, ApplicationId = 1, MenuName = "/RealEstate/Payments/PaymentMethodHeaderIndex", MenuText = "����� �����", MainMenu = 19, Section = null, Show = true }
            //, new Menu { MenuId = 22, ApplicationId = 1, MenuName = "", MenuText = "������", MainMenu = 4, Section = null, Show = true }
            //, new Menu { MenuId = 23, ApplicationId = 1, MenuName = "/RealEstate/Contracts/ContractTypesIndex", MenuText = "����� ������", MainMenu = 22, Section = null, Show = true }
            //, new Menu { MenuId = 24, ApplicationId = 1, MenuName = "/RealEstate/Contracts/ContractSysIndex", MenuText = "������� ������", MainMenu = 22, Section = null, Show = true }
            //, new Menu { MenuId = 25, ApplicationId = 1, MenuName = "/RealEstate/Contracts/ContractModelIndex", MenuText = "����� ������", MainMenu = 22, Section = null, Show = true }
            //, new Menu { MenuId = 26, ApplicationId = 1, MenuName = "/RealEstate/Contracts/ContractRequestIndex", MenuText = "������� ��� ����", MainMenu = 22, Section = null, Show = true }
            //, new Menu { MenuId = 27, ApplicationId = 1, MenuName = "/RealEstate/Contracts/ContractAgreeIndex", MenuText = "�������� ��� ������", MainMenu = 22, Section = null, Show = true }
            //, new Menu { MenuId = 28, ApplicationId = 1, MenuName = "/RealEstate/RegisterdContracts/Index", MenuText = "������ �������", MainMenu = 22, Section = null, Show = true }
            //, new Menu { MenuId = 29, ApplicationId = 1, MenuName = "/RealEstate/RegisterdInstallments/Index", MenuText = "������� �������", MainMenu = 22, Section = null, Show = true }
            //, new Menu { MenuId = 30, ApplicationId = 1, MenuName = "", MenuText = "�������", MainMenu = 4, Section = null, Show = true }
            //, new Menu { MenuId = 31, ApplicationId = 1, MenuName = "/RealEstate/Documents/Index", MenuText = "��� �������� ���������", MainMenu = 30, Section = null, Show = true }
            //, new Menu { MenuId = 32, ApplicationId = 1, MenuName = "/RealEstate/MarketingCompany/Index", MenuText = "����� �������", MainMenu = 5, Section = null, Show = true });

            //context.Roles.AddOrUpdate(p => p.Id, new ApplicationRole { Name = "Owner", Description = "Basic Owner Role" });

            //context.RoleApplications.AddOrUpdate(p => new { p.RoleId, p.ApplicationId }, new RoleApplication { RoleId = 1, ApplicationId = 1 });

            //if (!context.Users.Any(u => u.UserName == "superadmin"))
            //{
            //    var passwordHash = new PasswordHasher();
            //    string password = passwordHash.HashPassword("1AdminAdmin*");
            //    context.Users.AddOrUpdate(u => u.UserName,
            //                                    new ApplicationUser
            //                                    {
            //                                        UserName = "superadmin",
            //                                        PasswordHash = password,
            //                                        PhoneNumber = "01118863234",
            //                                        Email = "superadmin@Pioneers.com",
            //                                        SecurityStamp = "AbbasMohamed"
            //                                    });
            //}

            //context.RoleMenus.AddOrUpdate(p => new { p.RoleId, p.MenuId }
            //, new RoleMenu { RoleId = 1, MenuId = 2 }
            //, new RoleMenu { RoleId = 1, MenuId = 3 }
            //, new RoleMenu { RoleId = 1, MenuId = 5 }
            //, new RoleMenu { RoleId = 1, MenuId = 6 }
            //, new RoleMenu { RoleId = 1, MenuId = 7 }
            //, new RoleMenu { RoleId = 1, MenuId = 8 }
            //, new RoleMenu { RoleId = 1, MenuId = 9 }
            //, new RoleMenu { RoleId = 1, MenuId = 10 }
            //, new RoleMenu { RoleId = 1, MenuId = 11 }
            //, new RoleMenu { RoleId = 1, MenuId = 12 }
            //, new RoleMenu { RoleId = 1, MenuId = 13 }
            //, new RoleMenu { RoleId = 1, MenuId = 14 }
            //, new RoleMenu { RoleId = 1, MenuId = 15 }
            //, new RoleMenu { RoleId = 1, MenuId = 16 }
            //, new RoleMenu { RoleId = 1, MenuId = 17 }
            //, new RoleMenu { RoleId = 1, MenuId = 18 }
            //, new RoleMenu { RoleId = 1, MenuId = 19 }
            //, new RoleMenu { RoleId = 1, MenuId = 20 }
            //, new RoleMenu { RoleId = 1, MenuId = 21 }
            //, new RoleMenu { RoleId = 1, MenuId = 22 }
            //, new RoleMenu { RoleId = 1, MenuId = 23 }
            //, new RoleMenu { RoleId = 1, MenuId = 24 }
            //, new RoleMenu { RoleId = 1, MenuId = 25 }
            //, new RoleMenu { RoleId = 1, MenuId = 26 }
            //, new RoleMenu { RoleId = 1, MenuId = 27 }
            //, new RoleMenu { RoleId = 1, MenuId = 28 }
            //, new RoleMenu { RoleId = 1, MenuId = 29 }
            //, new RoleMenu { RoleId = 1, MenuId = 30 }
            //, new RoleMenu { RoleId = 1, MenuId = 31 });


            //context.RequestTypes.AddOrUpdate(p => p.Id, new RequestType { Id = 1, Name = "���" });

            //context.ApproveDefinitions.AddOrUpdate(p => p.Id
            //, new ApproveDefinition { Id = 1, ApprovName = "��� ������ ��� ���", TableName = "Contract", SystemName = "RealEstate" });

            //context.ApproveSteps.AddOrUpdate(p => p.Id
            //, new ApproveStep { Id = 1, ApproveDefinitionId = 1, ApproveName = "���� �������", MenueName = "�������� ��� ������", ApproveOrder = 1, MenuId = 26, ApproveSystemName = "Contracts", ApproveCount = 0 }
            //, new ApproveStep { Id = 2, ApproveDefinitionId = 1, ApproveName = "������� ���������", MenueName = "�������� ��� ������", ApproveOrder = 2, MenuId = 27, ApproveSystemName = "Contracts", ApproveCount = 1 }
            //, new ApproveStep { Id = 3, ApproveDefinitionId = 1, ApproveName = "���� �������- ����� �����", MenueName = "�������� ��� ������", ApproveOrder = 3, MenuId = 27, ApproveSystemName = "Contracts", ApproveCount = 1 });

            //context.StepStatusDefinitions.AddOrUpdate(p => p.Id
            //, new StepStatusDefinition { Id = 1, ApproveStepId = 1, StatusName = "�����", Approved = false, Binding = true, Reject = false, Value = 0 }
            //, new StepStatusDefinition { Id = 2, ApproveStepId = 2, StatusName = "�����", Approved = false, Binding = true, Reject = false, Value = 0 }
            //, new StepStatusDefinition { Id = 3, ApproveStepId = 2, StatusName = "������", Approved = true, Binding = false, Reject = false, Value = 0 }
            //, new StepStatusDefinition { Id = 4, ApproveStepId = 2, StatusName = "���", Approved = false, Binding = false, Reject = true, Value = 0 }
            //, new StepStatusDefinition { Id = 5, ApproveStepId = 3, StatusName = "�� ��� ������", Approved = false, Binding = true, Reject =false , Value = 0 }
            //, new StepStatusDefinition { Id = 6, ApproveStepId = 3, StatusName = "�� �������", Approved = true, Binding = false, Reject = false, Value = 0 });
        }
    }
}
