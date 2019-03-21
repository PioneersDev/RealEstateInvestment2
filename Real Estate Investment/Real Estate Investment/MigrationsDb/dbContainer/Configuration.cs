using RealEstateInvestment.Areas.RealEstate.Models;

namespace RealEstateInvestment.MigrationsDb.dbContainer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RealEstateInvestment.Areas.RealEstate.Models.dbContainer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"MigrationsDb\dbContainer";
        }

        protected override void Seed(RealEstateInvestment.Areas.RealEstate.Models.dbContainer context)
        {
            //  This method will be called after migD:\TFS\RealEstate\Real Estate Investment\Real Estate Investment\MigrationsDb\dbContainer\Configuration.csrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

//            context.Database.ExecuteSqlCommand("INSERT INTO [au].[UserRole]([UserId],[RoleId])VALUES(1,1)");

//            context.Religions.AddOrUpdate(p => p.Id
//            , new Religion { Id = 1, ReligionName = "�������" }
//            , new Religion { Id = 2, ReligionName = "��������" });

//            context.PhoneTypes.AddOrUpdate(p => p.Id
//            , new PhoneType { Id = 1, PhoneTypeName = "������" }
//            , new PhoneType { Id = 2, PhoneTypeName = "����" });

//            context.Nationalities.AddOrUpdate(p => p.Id
//            , new Nationality { Id = 1, NationalityName = "����/�" });

//            context.TypeIds.AddOrUpdate(p => p.Id
//            , new TypeId { Id = 1, IdName = " ����� ��� ����" }
//            , new TypeId { Id = 2, IdName = "���� ���" });

//            context.Statuses.AddOrUpdate(p => p.Id
//            , new Status { Id = 1, Name = "��� ������" }
//            , new Status { Id = 2, Name = "������" }
//            , new Status { Id = 3, Name = "�� �������" }
//            , new Status { Id = 4, Name = "�� �����" });

//            context.Owners.AddOrUpdate(p => p.Id
//            , new Owner { Id = 1, Name = "���� ������� ����������", Address = "1 ���� ��� ������� - ������ ������� -�������" }
//            , new Owner { Id = 2, Name = "���� ���� ��������� �������", Address = "" });

//            context.DocTypes.AddOrUpdate(p => p.Id
//            , new DocType { Id = 1, Name = "�����" }
//            , new DocType { Id = 2, Name = "���" });

//            context.PaymentTypes.AddOrUpdate(p => p.Id
//            , new PaymentType { Id = 1, Name = "���� �����", PayAddition = false }
//            , new PaymentType { Id = 2, Name = "���� ����", PayAddition = false }
//            , new PaymentType { Id = 3, Name = "���� ������", PayAddition = false }
//            , new PaymentType { Id = 4, Name = "���� �����", PayAddition = true }
//            , new PaymentType { Id = 5, Name = "����� ��� �����", PayAddition = false });

//            context.ContractSyses.AddOrUpdate(p => p.VarId
//            , new ContractSys { VarId = 1, VarName = "@1", VarDescription = "����� ������� �� ���� �� ��� (���� �� �����)", VarValue = "2.5", VarType = "decimal", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 2, VarName = "@2", VarDescription = "������ ���� ��� ����� �� ���� ������� ����� ������ (���� �� ���� ������)", VarValue = "10", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 3, VarName = "@3", VarDescription = "����� ����� ������ ����� (���� �� ���� ������)", VarValue = "5", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 4, VarName = "@4", VarDescription = "����� ����� ������ ������", VarValue = "1/1/2019", VarType = "datetime", IsTafqet = false, IsMoney = false }
//            , new ContractSys { VarId = 5, VarName = "@5", VarDescription = "��� ������ ��� ����� ������ ������ �������", VarValue = "6", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 6, VarName = "@6", VarDescription = "����� ����� ������� (���� �� ��� ������ ������� �� �� ��� �����)", VarValue = "0.5", VarType = "decimal", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 7, VarName = "@7", VarDescription = "���� ������ ������ ����� ������� (���� �� ��� ������)", VarValue = "5", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 8, VarName = "@8", VarDescription = "����� ������� �� �� ���", VarValue = "600", VarType = "int", IsTafqet = false, IsMoney = true }
//            , new ContractSys { VarId = 9, VarName = "@9", VarDescription = "������ ����� �������", VarValue = "100000", VarType = "int", IsTafqet = true, IsMoney = true }
//            , new ContractSys { VarId = 10, VarName = "@10", VarDescription = "���� ���� ������� ����� �������", VarValue = "1/1/2019", VarType = "datetime", IsTafqet = false, IsMoney = false });

//            context.UnitTypes.AddOrUpdate(p => p.Id
//            , new UnitType { Id = 1, UnitTypeName = "���", IsParent = false, SubUnitId = null }
//            , new UnitType { Id = 2, UnitTypeName = "���", IsParent = false, SubUnitId = null }
//            , new UnitType { Id = 3, UnitTypeName = "����", IsParent = false, SubUnitId = null }
//            , new UnitType { Id = 4, UnitTypeName = "�����", IsParent = true, SubUnitId = 1 }
//            , new UnitType { Id = 5, UnitTypeName = "���", IsParent = true, SubUnitId = 2 });


//            context.ContractTypes.AddOrUpdate(p => p.Id
//            , new ContractType { Id = 1, Name = "�����" }
//            , new ContractType { Id = 2, Name = "�����" }
//            , new ContractType { Id = 3, Name = "�����" });

//            context.Countries.AddOrUpdate(p => p.Id, new Country { Id = 1, CountryName = "���" });
//            context.Cities.AddOrUpdate(p => p.Id, new City { Id = 1, CountryId = 1, CityName = "�������" });
//            context.Districts.AddOrUpdate(p => p.Id, new District { Id = 1, CityId = 1, DistrictName = "������" }, new District { Id = 2, CityId = 1, DistrictName = "������ ������" });

//            context.Customers.AddOrUpdate(p => p.Id, new Customer { Id = 1, NameArab = "���� ���� ���� ������", NameEng = "Abbas Mohamed Abbas Soliman", Email = "eng.abbasmohamed14@gmail.com", ReligionId = 1, NationalityId = 1, CountryId = 1, CityId = 1, DistrictId = 1, IDTypeId = 1, IdNumber = "29212148801254", IdissuePlace = "� ������ ���� ��� - �����", IdExpiryDate = DateTime.ParseExact("04/07/2025", "dd/MM/yyyy", null), Address = "6 ���� ����� - ���� ��� ������ ������ ����� ���� ������� " });

//            context.CustomerPhones.AddOrUpdate(p => p.Id, new CustomerPhone { Id = 1, CustomerId = 1, PhoneTypeId = 1, PhoneNo = "01118863234" });

//            context.Projects.AddOrUpdate(p => p.Id
//            , new Project { Id = 1, CountryId = 1, CityId = 1, DistrictId = 2, ProjectName = "���� ������", ProjectContentDetails = "����� ������� ������ ������ ������� �������� ������ ������ �����", Location = "���� ����� ��� (4) ������� �������- ������ ������- ����� ������� �������", ProjectDescription = "����� ����� ������ ������" });
//            context.ProjectOwners.AddOrUpdate(p => p.Id
//            , new ProjectOwner { Id = 1, ProjectId = 1, ProjectOwnerId = 1, IsMainOwner = false, MainOwnerId = 2, ProjectOwnerDelegateName = "���� ���� ��� ������ ������", ProjectOwnerDelegateRepresent = "���� ���� �������", ProjectOwnerDetails = "����� ��� �� �������� �������" });
//            context.PaymentMethodHeaders.AddOrUpdate(p => p.Id, new PaymentMethodHeader { Id = 1, Name = "6 �����", TotalYearPeriod = 6 });
//            context.PaymentMethodDetails.AddOrUpdate(p => p.Id
//            , new PaymentMethodDetail { Id = 1, PaymentMethodHeaderId = 1, PaymentTypeId = 1, IsRatioNotAmount = true, Ratio = 10, MinimumAmount = null, StartFrom = 0, Period = 0, PaymentsCounts = 0 }
//            , new PaymentMethodDetail { Id = 2, PaymentMethodHeaderId = 1, PaymentTypeId = 2, IsRatioNotAmount = true, Ratio = 6.665m, MinimumAmount = null, StartFrom = 3, Period = 0, PaymentsCounts = 0 }
//            , new PaymentMethodDetail { Id = 3, PaymentMethodHeaderId = 1, PaymentTypeId = 5, IsRatioNotAmount = true, Ratio = 0.03125m, MinimumAmount = null, StartFrom = 6, Period = 3, PaymentsCounts = 24 });

//            context.ContractModels.AddOrUpdate(p => p.Id
//            , new ContractModel { Id = 1, ContractTypeId = 1, Name = "��� ����� ��� ���� ������" });

//            context.ContractItems.AddOrUpdate(p => p.Id
//                , new ContractItem { Id = 1, ContractModelId = 1, ContractItemName = "����� �����", ContractItemString = "������������ ������ �������� ������� ������ �� ���� ��� ���� �� ���� ��� �������� ����� ������� ������ ���� ���� ������ ������� ������� ���������� ������� ���� ����� �� ���� ��� ���� �� ����� �� ����� �� ��� ����� ������� ������� ����� ����� ������� ���� ��� ����� ������� �������� ���� ����� ������ ��� �����" }

//                , new ContractItem { Id = 2, ContractModelId = 1, ContractItemName = " ����� ������ (���� ������)", ContractItemString = "��� ����� ����� ��� ����� ������ ������ ���� ������ ������� @103 �� @104 ������ @101 ������ ��� @102 ����� ������ ���� ������ ������� ��� ��� �����  (@105)�2 ��� @106 ��� ����  \"��� ����� ��������\" ��� ���� ���� ������� ������ ������ ������� ������ ������� ��� ��� ����� ��������� ���� ���� ����� ����� ����� � ��� ���� ������� ��� �� ��� ����� ������ ����� ��� ��� ���� ��� ���� ���� ����� �� ������ ������ ���� �������� ���� � ������ ��� ����� ��� ���� ������� ���� ���� ���� ���� ����� ����� ������� �� ����� ��� ����� ��� ������� ��� ��� ���� ����� ������ ����� ����� �� ������ ������ ������ ��� ����� ��� ����� ������ ������ ����� ������ ������ �� ������ ������� ��� ��� ����� �������� �������� ����� ���� ���� ������ ������� ��� ���� ����� ����� ������ ��� ��� ����� ������ �������� ������� �� ��� ����� ��� � ��� �� �� ��� �� ������� �������� ���� ����� ����� �������� ��� ����� ��� ����� ����� ��� ���� �� ������ ���� ���������� � ��� �� ������ ���� ��� ������� �� ��� ����� �� ���� �� ���� ���� ��� ������� ������ ������ �������� �������� �������� ��������� �������� ������� ������� ������ �������� ������ �������� ������� ����� ���� ������ �� ������� ���� ������ ����� ����� � ��� �� ��� ������� ��� ����� ����� �����." }

//                , new ContractItem { Id = 3, ContractModelId = 1, ContractItemName = "����� ������ (����� ������ �����)", ContractItemString = "�� ��� ����� ����� ��� ������ ����� (@107) (��� @108 ��� �� ���) � ���� ������� ��� �� ��� ������ ��� �� ���� �� ���� ������" }

//                //                , new ContractItem { Id = 4, ContractItemName = "����� ������ (�������� �������)", ContractItemString = @"1-����� ����� ������ ����� ���� ��� ����� ������� �� �������� ������ �����
//                //2-����� �� ����� ������ ������ �� �������� �� ������ ��� ��� �� ������� ��� ���  � ������ ����� ����� ������ ��� ��� ����� ������� ��� ���� ������ ����� �� ����� ������ �� �� �� �� �� ����� �� ����� ���� ������� � ������ ����� ����� ������ ���� ����� ����� ����� ����� ���� ����� ����� ����� ����� ������ ������ ������ ������ ������ �� ��� �����
//                //" }
//                //                , new ContractItem { Id = 5, ContractItemName = "����� ������ (������� �� ������)", ContractItemString = @"1-��� ���� �� ���� �� ����� ����� ������ �� ���� ���� �� ��� �� ������ ������ �� ��� ��� �� ������� ���� �� ��� ���� ���� �� ����� ��������� ���� ����� ����� ����� ����� �����  @������������ (@����������������� �� ���) �� ���� ����� �� �� ��� ����� �� ����� ����� ��� �� ����� ����� �� ����� ����� ������� ���� ����� ������  � ��� ��� ����� ����� ���� �� ��� ������ ��� ������ ��� ������� ����� �� 60 ���� �� ����� ��������� ������ ��� ����� ������ �� ����� ���� ��� ���� ��� ����� �� ����� �� ���� ��� ����� ���� �� ����� ��� ������� ������ �������� ������ ������� �� ��� �� ����� ������ �� �� �� ���� �� ��� �� ������� ���� �� �� �� ����� �� ����� ��� ��� ���� (@������������) (��� @�����������������) �� ������ ���� ������ ������� ��� ��� ����� ����� ��������� �������� �������� �������� ������ �� ��������� ���� ������ ����� ����� �� ���� ����� ��� �����  ����� ��� ��� ����� ������ ����� ���� ��� ����� ������ ������ ���� ��� ��� ��� ����� ���� ��� ����� ������  � ���� �� ��� �� ������� ��� ����� ���� ��� ������ ������� ������ ���� �� ��� ������ �� ��� ����� ������ ���� �� ���� ������� ����� ������ ���� ������� ��� ����� ��� ����� ����� ������ �������� ������ ����� ���� �� �������� ��� �� ��� �� ���
//                //2-��� ����� ����� �� ���� ��� ����� ������ �� ������ ������� ��� ��� ����� ����� ��� �� ���� ����� ������ �� �� �� �������� ��� ���
//                //3-��� ����� ���� ����� ����� (������) ������ ������ ������ ������� ��� ��� ������� ������ ��� �� ������ �� ������� ��� ���� �� �������
//                //" }
//                //                , new ContractItem { Id = 6, ContractItemName = "����� ������ (���� ����� ������ �� �����)", ContractItemString = @"�� ���� ���� ����� ������ �� ������ �� ����� ����� ���� ����� �������� �� ��� ����� �� ����� ������ ����� ��� ���� ���� ��� �������  � ����� ������ ���� ���� ��� ����� ����� ���� ��� ����� ��� � ���� ���� ������ ��������� ������� �� ��� ������ ��� �� ����� ������ ��� ���� �������� ��� ������ �� ����� ������ ��� ��� ����� ������ ���� ��� ���� ����� @������������ (��� @����������������� �����) �� ������ ���� ������ ������� ����� �������� �������� �� ��� ����� ������ ������ �� ��� ������ �� ���� ������ ������ � ������ ����� ������ ��� ������ ������� ��� ��� ����� �� ��� �� ������� � �� ���� ����� ����� ��� ����� ������� ��� ��� ��� ������ ��� �� ��� ���� ���� ����� ���� ������� ����� ��� ������ ������� ������ ���� �� ��� ������ �� ��� ����� ������ � ��� �� ���� ����� ����� �� �� ������� ��� ����� ��� ����� ����� ������ �������ɡ ��� ���� ������� ��� ����� ����� ������� �������� ��� �������� ��� ��� ������ �� ����� ���� ���" }

//                //                , new ContractItem { Id = 7, ContractItemName = "����� ������ (��� ����� ������ ������ �������)", ContractItemString = @"�� ��� ������� ��� �� ������� ���� ������ ������ ����� ���� ����� ���� �� ���� ��� �� ������ �� �� �� ����� �� ����� ��� ����� ��� ��� �� ������� ��� ��� � ������ ����� ������ ��� ������ ������ ������� ��� ��� ����� �� ���� �������� � ����� ����� �� ������� �� ������� �������� ���� ���� ����� ��� ����� ����� � ��� �� ��� ��� ���� ��� ���� �� ����� �� ����� �� ���� ��� ����� � ��� ���� �� �� ����� ����� �� ����� �� ���� �� �� ���� �� �������� ���� �� ���� ����� ������ �� ������ �� ��� ������ ������� ��� ����� �� �� �� �� ������ ���� ���� �� ����� ����� ���� ���� ���� ����� �� ����� �� ����� �� �� ���� �� ������ ��� ����� ��� ��� ����� ���� ���� ����� ����� ������ ��� ����� �������� ������ ��� �� �� �� �� ���� �� ����� ���� ����� ����� ������ ��� ������ �������� ������ ������ ������� ��������� ������ ������ ��� ������ ���� ������ ���� ��� ���� ����� ������ �� ���� �� ����� �� ��������� ������� � ����� ��� ��� ���� ��� ����� �� ����� �� ���� ��� ����� " }

//                //                  , new ContractItem { Id = 8, ContractItemName = "����� ������ (������ �� ������ �������)", ContractItemString = @"1-�� ������ ���� �� ��� ����� �� ��� ���� ��� ��� ���� ��� ���� ���� ����� ����� �� �������� ��� ��� ���� ������� ��� ��� ���� ���� ����� ���� ��� �� ������� ���� � ��� ����� ����� ����� �� �������� ������ ����� ������ ����� ����� ������ ������ ������� ������� ����� �� �� ������ ����� ��� ������ ����� ����� 
//                //2-��� ������ ���� ��� ������� �� ��� ��� ����� ������ �� ���� ����� �� ����� ������ ��� ���� ���� ����� ����� (����� �����) �� ���� ����� ������ ���� ���� ����� ���� �� ����� ������ -�� ��� ����- �� ����� ������� ���� �������� ����� ���������� ������� �� ��� ����� ��� ������ ����� ������ ������� ��� ���� ����� ������ �� ���� ����� �� ����� ���� ����� �� ��� ���� ��� ������ ����� ��� �� ����� ������ �� ��� ����� 
//                //��� ���� ����� ������ ������� �� ���� ����� ���� ��� �� ��� ������ ������ ������� ����� �� ����� �� ����� �� ��� �� ������ �� ������ ��� ��� ����� ��� ��� �� ���� �������� �� ����� �� ���� ����� ����� �� ����� �� ���� ����� �� ������ ��� �� ���� �� ������ �� ��� �� ������� ���� ������ ��� ��� ����� � ����� ���� �� ��� ���� ����� �� �������� ��� ������ ������� ��� ��� ���� ���� ����� ��� ������ ������ �� ����� ����� ����� 
//                //3-��� ���� ���� ����� ������ �� ���� ����� �� ������ ������� �� �� ��� ���� ��� ���� ���� ����� ����� ������� �������� �� ����� ����� �����  ����� ��� ����� ������ �� ����� ���� ��� ������ ��� ����� �� ����� �� ������� ��� ����� �� ����� �� ������� ����� ����� ����� ������� ����� ��� ��� ����� �� ��� �� �� ���� �� �������� ��� ��� ����� ������ �� ���� ����� ������ �� ��� ������ ������ �� ������� ���� �������� ��� ���� ������ ������� ����� ��� ��� ���� ��� ����� �� ����� �� ���� ��� ����� 
//                //4-��� ��� ��� ������� ������ ������� ������� ���� ����� ����� ����� ������ �� ���� ����� �� ������� �� ������ ��� ��� ����� ����� �� ����� ���� ����� ����� ���� ��� ����� ��� � ����� ����� ����� ���� ������ �� ������ �� ����� � ��� ���� ������ ����� ����� ��� ���� ����� ������ �� ������� ����� �� ��� ������� ������ ������� ����� ����� ��� ������� ��� ���� ������� ��� ������� ����� ����� � ��� �� ��� ������� ��� ���� ����� ������ ����� ����� @������������ (��� @����������������� �� ���) �� ���� ������ ������� ����� �������� �������� ������ɡ ������� �� ��� �������� ������� ����� ������� �� ������ ������ ����� ����� ���
//                //" }

//                //                  , new ContractItem { Id = 9, ContractItemName = "����� ������ (������ ������ ������� �������)", ContractItemString = @"��� ����� ������ ��� ���� ��� ������� ����� ������� ������ ������� ���� ����� ���� ������ ��� ��� ����� ��������� �������� ������ ������ ������ ������ ������ ���� ����� ���� �� ����� ����� ��� ������ ������� ������ ������ ������ ����� ��� ����� � ���� �������� ����� ����� ������ ������� ����� ��� ����� ���� �������� ������ ������� ������� ���� ������� ���� ��� ���� ���� ������� �� ������� ���� ������ ������ ��� ��� ��� ��� ���� �� ���� �� ��� ��� �� ���� ����� ������ ����� �� ����� ������� �� ����� ����� ���� ����� ����� ������ �������� ���� ��� ������� ����� ����� ��� ��� ����� ��� ���� ����� ������ �� ���� ����� ������ �� ����� ������� ������� ������� ������� ��� ����� ���� ��� �� ���� ��� ����� ��� ���� �� �� ����� ����� �� ����� ����� ��� ����� ��������� �� ���� ��� �� ������� ��� ������� ��� ���� ������ ��� ������ ����� �� ����� ��� ����� � ��� ��� ����� ������ ��� �� ���� �� ������ ��� ����� ����� �� ��� ��� �� ������ �� �� �� ����� �� ����� ����� �� �������� ��� ���� ���� ��� ��� ��� �� �������" }
//                );

//            context.Database.ExecuteSqlCommand(@"create function [con].[ufn_GetRequests](@Id bigint,@UserId int,@RequestTypeId int) 
//RETURNS @rtnTable TABLE
//(
//    --columns returned by the function
//    Id bigint,
//    UserId int,
//    UserName nvarchar(256),
//    RequestTypeId int,
//    RequestTypeName nvarchar(50),
//    Step int,
//    StepName nvarchar(MAX),
//    [Status] int,
//    StatusName nvarchar(MAX),
//	Remarks nvarchar(MAX),
//    ProjectId int,
//    ProjectName nvarchar(MAX),
//    UnitId int,
//    UnitName nvarchar(MAX),
//	MainUnitId int,
//	MainUnitName nvarchar(MAX),
//    CustomerId int,
//    CustomerName nvarchar(MAX),
//    ContractDate datetime,
//    PaymentMethodHeaderId int,
//    PaymentMethodHeaderName nvarchar(MAX),
//	ContractTypeId int,
//	ContractTypeName nvarchar(max),
//	ContractModelId int,
//	ContractModelName nvarchar(MAX),
//    UnitTotalValue int,
//    InstallmentData nvarchar(MAX),
//	DeliverySpecificationData nvarchar(MAX),
//    DocHeaderId int,
//    DocHeaderName nvarchar(200),
//	ContractId int
//)
//AS
//BEGIN

//    DECLARE @RequestTempTable table([Id][bigint] NOT NULL, UserId int NOT NULL, UserName nvarchar(256) not null, RequestTypeId int NOT NULL, RequestTypeName nvarchar(50) NOT NULL, RequestContent[nvarchar](max) NOT NULL,[Step][int] NOT NULL, StepName NVARCHAR(max),[Status][int] NOT NULL, StatusName NVARCHAR(max),Remarks NVARCHAR(max))


//    insert into @RequestTempTable
//    select req.Id,req.UserId,us.UserName,req.RequestTypeId,reqtype.Name,req.RequestContent,req.Step,step.ApproveName,req.Status,stat.StatusName,req.Remarks
//    from RealEstateDb.au.Request as req
//    inner join RealEstateDb.au.RequestType as reqtype on reqtype.Id = req.RequestTypeId
//    inner join RealEstateDb.au.[User] as us on us.Id = req.UserId
//    inner join RealEstateDb.au.ApproveStep as step on step.Id = req.Step
//    inner join RealEstateDb.au.StepStatusDefinition as stat on stat.Id = req.Status
//    where(@Id is not null and req.Id = @Id) or(@UserId is not null and req.UserId = @UserId)or(@RequestTypeId is not null and req.RequestTypeId = @RequestTypeId)


//    declare @cursorTable table(Id bigint, UserId int, UserName nvarchar(256), RequestTypeId int, RequestTypeName nvarchar(50), Step int, StepName nvarchar(MAX),[Status] int, StatusName nvarchar(MAX),Remarks nvarchar(MAX), ProjectId int, ProjectName nvarchar(MAX), UnitId int, UnitName nvarchar(MAX), MainUnitId int, MainUnitName nvarchar(MAX), CustomerId int, CustomerName nvarchar(MAX), ContractDate datetime, PaymentMethodHeaderId int, PaymentMethodHeaderName nvarchar(MAX), ContractTypeId int, ContractTypeName nvarchar(max), ContractModelId int, ContractModelName nvarchar(MAX), UnitTotalValue int, InstallmentData nvarchar(MAX), DeliverySpecificationData nvarchar(MAX), DocHeaderId int, DocHeaderName nvarchar(200),ContractId int)
//    declare @Idx bigint;
//    declare @UserIdx int;
//    declare @UserName nvarchar(256);
//    declare @RequestTypeIdx int;
//    declare @RequestTypeName nvarchar(50);
//    declare @RequestContent nvarchar(max);
//    declare @Step int;
//    declare @StepName NVARCHAR(max);
//    declare @Status int;
//    declare @StatusName NVARCHAR(max);
//	declare @Remarks NVARCHAR(max);
//    declare reqcur cursor for
        
//    select Id, UserId, UserName, RequestTypeId, RequestTypeName, RequestContent, Step, StepName, Status, StatusName, Remarks from @RequestTempTable;
//    open reqcur;
//    fetch next from reqcur into @Idx,@UserIdx,@UserName,@RequestTypeIdx,@RequestTypeName,@RequestContent,@Step,@StepName,@Status,@StatusName,@Remarks;
//    while @@FETCH_STATUS = 0
//    begin
//        insert into @cursorTable(Id, UserId, UserName, RequestTypeId, RequestTypeName, Step, StepName, Status, StatusName, Remarks, ProjectId, ProjectName, UnitId, UnitName, MainUnitId, MainUnitName, CustomerId, CustomerName, ContractDate, PaymentMethodHeaderId, PaymentMethodHeaderName,ContractTypeId,ContractTypeName,ContractModelId,ContractModelName, UnitTotalValue, InstallmentData,DeliverySpecificationData, DocHeaderId, DocHeaderName, ContractId)
//        SELECT @Idx, @UserIdx, @UserName, @RequestTypeIdx, @RequestTypeName, @Step, @StepName, @Status, @StatusName, @Remarks, js.ProjectId,project.ProjectName,js.UnitId,unit.UnitName,MainUnit.Id,MainUnit.UnitName,js.CustomerId,cust.NameArab,js.ContractDate,js.PaymentMethodHeaderId,payHed.Name,js.ContractTypeId,conType.Name,js.ContractModelId,conModel.Name,js.UnitTotalValue,js.InstallmentData,js.DeliverySpecificationData,js.DocHeaderId,DocHed.Name,con.Id FROM
//        OPENJSON(@RequestContent)
//        WITH(
//                ProjectId int '$.ProjectId',
//                UnitId int '$.UnitId',
//                CustomerId int '$.CustomerId',
//                ContractDate date '$.ContractDate',
//                PaymentMethodHeaderId int '$.PaymentMethodHeaderId',
//				ContractTypeId int '$.ContractTypeId',
//				ContractModelId int '$.ContractModelId',
//                UnitTotalValue int '$.UnitTotalValue',
//                InstallmentData nvarchar(max) AS JSON ,
//                DeliverySpecificationData nvarchar(max) AS JSON ,
//                DocHeaderId int '$.DocHeaderId'
//                ) as js

//        left outer join RealEstateDb.con.Project as project on(project.Id = js.ProjectId and js.ProjectId is not null)
//        left outer join RealEstateDb.con.Unit as unit on(unit.Id = js.UnitId and js.UnitId is not null)
//		left outer join RealEstateDb.con.Unit as MainUnit on(unit.Id = js.UnitId and js.UnitId is not null and unit.MainUnitId is not null and MainUnit.Id=unit.MainUnitId)
//        left outer join RealEstateDb.con.Customer as cust on(cust.Id = js.CustomerId and js.CustomerId is not null)
//        left outer join RealEstateDb.con.PaymentMethodHeader as payHed on(payHed.Id = js.PaymentMethodHeaderId and js.PaymentMethodHeaderId is not null)
//        left outer join RealEstateDb.con.DocHeader as DocHed on(DocHed.Id = js.DocHeaderId and js.DocHeaderId is not null)
//		left outer join RealEstateDb.con.Contract as con on (con.RequestId=@Idx)
//		left outer join RealEstateDb.con.ContractType as conType on (conType.Id=js.ContractTypeId and js.ContractTypeId is not null)
//		left outer join RealEstateDb.con.ContractModel as conModel on (conModel.Id=js.ContractModelId and js.ContractModelId is not null)

//        fetch next from reqcur into @Idx,@UserIdx,@UserName,@RequestTypeIdx,@RequestTypeName,@RequestContent,@Step,@StepName,@Status,@StatusName,@Remarks;
//    end
//    close reqcur;
//    deallocate reqcur;
//    --This select returns data
//    insert into @rtnTable
//    SELECT* FROM @cursorTable
//RETURN
//END");
//            context.Database.ExecuteSqlCommand(@"create function [con].[ufn_GetRequestInstallmentData](@Id bigint) 
//RETURNS @rtnTable TABLE
//(
//    --columns returned by the function
//    Id int,
//    ContractId int,
//    CustomerId int,
//    PaymentMethodDetailId int,
//    payName nvarchar(50),
//    Serial int,
//    PayDate datetime,
//    PayValue decimal(18,2),
//    PayNote nvarchar(MAX),
//    TransactionDate datetime,
//    IsPaid bit,
//    RefId int,
//    PayCount int
//)
//AS
//BEGIN

//    DECLARE @RequestContent nvarchar(max);

//    select @RequestContent=Request.RequestContent
//    from RealEstateDb.au.Request
//    where(@Id is not null and Request.Id = @Id)

//    DECLARE @JSON VARCHAR(MAX);

//    insert into @rtnTable
//    SELECT js.Id,js.ContractId,js.CustomerId,js.PaymentMethodDetailId,pay.Name,js.Serial,js.PayDate,js.PayValue,js.PayNote,js.TransactionDate,js.IsPaid,js.RefId,det.PaymentsCounts from
//    openjson(@RequestContent)
//    WITH(InstallmentData nvarchar(max) AS JSON)
//    CROSS APPLY OPENJSON (InstallmentData) WITH(
//            Id int '$.Id',
//            ContractId int '$.ContractId',
//            CustomerId int '$.CustomerId',
//            PaymentMethodDetailId int '$.PaymentMethodDetailId',
//            Serial int '$.Serial',
//            PayDate datetime '$.PayDate',
//            PayValue decimal(18,2) '$.PayValue' ,
//            PayNote nvarchar(MAX) '$.PayNote',
//            TransactionDate nvarchar(MAX) '$.TransactionDate',
//            IsPaid nvarchar(MAX) '$.IsPaid',
//            RefId nvarchar(MAX) '$.RefId'
//    ) as js
//    left outer join RealEstateDb.con.PaymentMethodDetail as det on(det.Id=js.PaymentMethodDetailId and js.PaymentMethodDetailId is not null)
//    inner join RealEstateDb.con.PaymentType as pay on(pay.Id=det.PaymentTypeId and js.PaymentMethodDetailId is not null)
//RETURN
//END");

//            context.Database.ExecuteSqlCommand(@"Create function [con].[ufn_GetRequestDeliverySpecificationData](@Id bigint) 
//RETURNS @rtnTable TABLE
//(
//    --columns returned by the function
//    Id int,
//    [Name] nvarchar(max)
//)
//AS
//BEGIN

//    DECLARE @RequestContent nvarchar(max);

//    select @RequestContent = Request.RequestContent
//    from RealEstateDb.au.Request
//    where (@Id is not null and Request.Id = @Id)

//    DECLARE @JSON VARCHAR(MAX);

//    insert into @rtnTable
//    SELECT js.Id,js.Name from
//    openjson(@RequestContent)
//    WITH(DeliverySpecificationData nvarchar(max) AS JSON)
//    CROSS APPLY OPENJSON(DeliverySpecificationData) WITH(
//            Id int '$.Id',
//            [Name] nvarchar(max) '$.Name'
//    ) as js
//RETURN
//END");

//            context.Database.ExecuteSqlCommand(@"CREATE function [con].[ufn_GetContracts](@Id int) 
//RETURNS @rtnTable TABLE
//(
//    --columns returned by the function
//    Id int,
//    ProjectId int,
//    ProjectName nvarchar(MAX),
//    UnitId int,
//    UnitName nvarchar(MAX),
//	MainUnitId int,
//	MainUnitName nvarchar(MAX),
//    CustomerId int,
//    CustomerName nvarchar(MAX),
//    ContractDate datetime,
//    PaymentMethodHeaderId int,
//    PaymentMethodHeaderName nvarchar(MAX),
//	ContractTypeId int,
//	ContractTypeName nvarchar(max),
//	ContractModelId int,
//	ContractModelName nvarchar(MAX),
//    UnitTotalValue int,
//    DocHeaderId int,
//    DocHeaderName nvarchar(200),
//	RequestId bigint
//)
//AS
//BEGIN

//    insert into @rtnTable
//    select con.Id,con.ProjectId,project.ProjectName,con.UnitId,unit.UnitName,MainUnit.Id,MainUnit.UnitName,con.CustomerId,cust.NameArab,con.ContractDate
//	,con.PaymentMethodHeaderId,payHed.[Name],con.ContractTypeId,conType.[Name],con.ContractModelId,conModel.[Name],con.UnitTotalValue,con.DocHeaderId,DocHed.[Name]
//	,con.RequestId
//    from [RealEstateDb].[con].[Contract] as con
//	left outer join [RealEstateDb].[con].[Project] as project on(project.Id = con.ProjectId and con.ProjectId is not null)
//	left outer join [RealEstateDb].[con].[Unit] as unit on(unit.Id = con.UnitId and con.UnitId is not null)
//	left outer join [RealEstateDb].[con].[Unit] as MainUnit on(unit.MainUnitId = MainUnit.Id and con.UnitId is not null and unit.MainUnitId is not null)
//	left outer join [RealEstateDb].[con].[Customer] as cust on(cust.Id = con.CustomerId and con.CustomerId is not null)
//	left outer join [RealEstateDb].[con].[PaymentMethodHeader] as payHed on(payHed.Id = con.PaymentMethodHeaderId and con.PaymentMethodHeaderId is not null)
//	left outer join [RealEstateDb].[con].[DocHeader] as DocHed on(DocHed.Id = con.DocHeaderId and con.DocHeaderId is not null)
//	left outer join [RealEstateDb].[con].[ContractType] as conType on (conType.Id=con.ContractTypeId and con.ContractTypeId is not null)
//	left outer join [RealEstateDb].[con].[ContractModel] as conModel on (conModel.Id=con.ContractModelId and con.ContractModelId is not null)
//    where(@Id is not null and con.Id = @Id) or @Id  is null

//RETURN
//END");
//            context.Database.ExecuteSqlCommand(@"Create function [con].[ufn_GetContractsInstallments](@Id int) 
//RETURNS @rtnTable TABLE
//(
//    --columns returned by the function
//    [Id] [int],
//	[ContractId] [int],
//	[CustomerId] [int],
//	[CustomerName] [nvarchar](max),
//	[PaymentMethodDetailId] [int],
//	[PaymentMethodDetailName] [nvarchar](max),
//	[Serial] [int],
//	[PayDate] [datetime],
//	[PayValue] [decimal](18, 2) ,
//	[PayNote] [nvarchar](max),
//	[TransactionDate] [datetime] ,
//	[IsPaid] [bit],
//	[RefId] [int],
//	[GroupColumn] [nvarchar](max) 
//)
//AS
//BEGIN

//    insert into @rtnTable
//    select ins.Id,ins.ContractId,ins.CustomerId,cust.NameArab,ins.PaymentMethodDetailId,payType.[Name],ins.Serial,ins.PayDate,ins.PayValue,ins.PayNote,ins.TransactionDate
//	,ins.IsPaid,ins.RefId,contbl.groupcol
//    from [RealEstateDb].[con].[Installment] as ins
//	left outer join [RealEstateDb].[con].[Customer] as cust on(cust.Id = ins.CustomerId and ins.CustomerId is not null)
//	left outer join [RealEstateDb].[con].[PaymentMethodDetail] as payDet on(payDet.Id = ins.PaymentMethodDetailId and ins.PaymentMethodDetailId is not null)
//	inner join [RealEstateDb].[con].[PaymentType] as payType on(payDet.PaymentTypeId=payType.Id)
//	inner join (select N''+CustomerName+' '+UnitName+' '+MainUnitName+' '+ProjectName as groupcol,* from [RealEstateDb].[con].[ufn_GetContracts](null)) as contbl on  contbl.Id=ins.ContractId
//    where(@Id is not null and ins.ContractId = @Id) or @Id  is null

//RETURN
//END");
//            context.Database.ExecuteSqlCommand(@"CREATE procedure [con].[usp_insertInstallmentNotification]
//as
//begin
//	set nocount on;
//	declare @CurrentDate date=CONVERT(date, GETDATE());

//	DECLARE @TempTable table([Id] [int] NOT NULL,[ContractId] [int] NOT NULL,[CustomerId] [int] NOT NULL,[PaymentMethodDetailId] [int] NOT NULL,[Serial] [int] NOT NULL,[PayDate] [datetime] NOT NULL,[PayValue] [decimal](18, 2) NOT NULL,[PayNote] [nvarchar](max) NULL,[TransactionDate] [datetime] NULL,[IsPaid] [bit] NOT NULL,[RefId] [int] NULL)
//	insert @TempTable
//	select * 
//	from [RealEstateDb].[con].[Installment]
//	where [RealEstateDb].[con].[Installment].[PayDate]=@CurrentDate

//	declare @NotificationMaxId int;
//	declare @Id int;
//	declare @UserId int;
//	DECLARE COR CURSOR FOR SELECT Id from @TempTable 
//	OPEN COR
//	FETCH NEXT FROM COR INTO  @Id
//	WHILE @@FETCH_STATUS = 0 
//	BEGIN
//		select @NotificationMaxId=MAX([Notification].Id)+1 FROM [RealEstateDb].[au].[Notification] ;
//		if @NotificationMaxId is null
//			set @NotificationMaxId=1;
//		insert into [RealEstateDb].[au].[Notification]
//		values (@NotificationMaxId,GETDATE(),'��� ���� ���� ����� ��� '+Convert(nvarchar,@Id),'/RealEstate/RegisterdInstallments/Index/'+Convert(nvarchar,@Id),1,'SystemServerAgent');
//		--------------
//		DECLARE COR1 CURSOR FOR SELECT au.[User].Id
//		FROM    au.RoleMenu INNER JOIN
//				au.Menu ON au.RoleMenu.MenuId = au.Menu.MenuId INNER JOIN
//				au.Role ON au.RoleMenu.RoleId = au.Role.Id INNER JOIN
//				au.UserRole ON au.Role.Id = au.UserRole.RoleId INNER JOIN
//				au.[User] ON au.UserRole.UserId = au.[User].Id
//		WHERE au.Menu.MenuId=29
//		OPEN COR1
//		FETCH NEXT FROM COR1 INTO  @UserId
//		WHILE @@FETCH_STATUS = 0 
//		BEGIN
//			insert into [RealEstateDb].[au].[UserNotification] values(@NotificationMaxId,@UserId,0,NULL);
//			FETCH NEXT FROM COR1 INTO @UserId
//		END 
//		CLOSE COR1
//		DEALLOCATE COR1
//		--------------
//		FETCH NEXT FROM COR INTO @Id
//	END 
//	CLOSE COR
//	DEALLOCATE COR
//end");

        }

    }
}
