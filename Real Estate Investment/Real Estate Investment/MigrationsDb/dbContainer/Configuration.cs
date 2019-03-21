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
//            , new Religion { Id = 1, ReligionName = "ÇáÇÓáÇã" }
//            , new Religion { Id = 2, ReligionName = "ÇáãÓíÍíÉ" });

//            context.PhoneTypes.AddOrUpdate(p => p.Id
//            , new PhoneType { Id = 1, PhoneTypeName = "ãæÈÇíá" }
//            , new PhoneType { Id = 2, PhoneTypeName = "ÃÑÖí" });

//            context.Nationalities.AddOrUpdate(p => p.Id
//            , new Nationality { Id = 1, NationalityName = "ãÕÑí/É" });

//            context.TypeIds.AddOrUpdate(p => p.Id
//            , new TypeId { Id = 1, IdName = " ÈØÇŞÉ ÑŞã Şæãí" }
//            , new TypeId { Id = 2, IdName = "ÌæÇÒ ÓİÑ" });

//            context.Statuses.AddOrUpdate(p => p.Id
//            , new Status { Id = 1, Name = "ÛíÑ ãÍÌæÒÉ" }
//            , new Status { Id = 2, Name = "ãÍÌæÒÉ" }
//            , new Status { Id = 3, Name = "Êã ÇáÊÚÇŞÏ" }
//            , new Status { Id = 4, Name = "Êã ÇáÈíÚ" });

//            context.Owners.AddOrUpdate(p => p.Id
//            , new Owner { Id = 1, Name = "ÔÑßÉ ÇáãíÏÇä ááÇÓÊÔÇÑÇÊ", Address = "1 ÔÇÑÚ ÍæÖ ÇáÌÒíÑÉ - ßæÑäíÔ ÇáãÚÇÏí -ÇáŞÇåÑÉ" }
//            , new Owner { Id = 2, Name = "ÔÑßÉ ÑÄíÉ ááÇÓÊËãÇÑ ÇáÚŞÇÑí", Address = "" });

//            context.DocTypes.AddOrUpdate(p => p.Id
//            , new DocType { Id = 1, Name = "äãæĞÌ" }
//            , new DocType { Id = 2, Name = "ÚŞÏ" });

//            context.PaymentTypes.AddOrUpdate(p => p.Id
//            , new PaymentType { Id = 1, Name = "ÏİÚÉ ÊÚÇŞÏ", PayAddition = false }
//            , new PaymentType { Id = 2, Name = "ÏİÚÉ Ãæáì", PayAddition = false }
//            , new PaymentType { Id = 3, Name = "ÏİÚÉ ÇÓÊáÇã", PayAddition = false }
//            , new PaymentType { Id = 4, Name = "ÏİÚÉ ÕíÇäÉ", PayAddition = true }
//            , new PaymentType { Id = 5, Name = "ÃŞÓÇØ ÑÈÚ ÓäæíÉ", PayAddition = false });

//            context.ContractSyses.AddOrUpdate(p => p.VarId
//            , new ContractSys { VarId = 1, VarName = "@1", VarDescription = "ÛÑÇãÉ ÇáÊÃÎíÑ İí ÓÏÇÏ Ãí ŞÓØ (äÓÈÉ ãä ÇáŞÓØ)", VarValue = "2.5", VarType = "decimal", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 2, VarName = "@2", VarDescription = "ÇáŞíãÉ ÇáÊí íÊã ÎÕãåÇ İí ÍÇáÉ ÇÓÊÑÏÇÏ ãáßíÉ ÇáæÍÏÉ (äÓÈÉ ãä ŞíãÉ ÇáæÍÏÉ)", VarValue = "10", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 3, VarName = "@3", VarDescription = "ÛÑÇãÉ ÊäÇÒá ÇáÚãíá ááÛíÑ (äÓÈÉ ãä ŞíãÉ ÇáæÍÏÉ)", VarValue = "5", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 4, VarName = "@4", VarDescription = "ÊÇÑíÎ ÊÓáíã ÇáæÍÏÉ ááÚãíá", VarValue = "1/1/2019", VarType = "datetime", IsTafqet = false, IsMoney = false }
//            , new ContractSys { VarId = 5, VarName = "@5", VarDescription = "ãÏÉ ÇáÓãÇÍ ÍÊì ÊÓáíã ÇáæÍÏÉ ááÚãíá ÈÇáÃÔåÑ", VarValue = "6", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 6, VarName = "@6", VarDescription = "ÛÑÇãÉ ÊÃÎíÑ ÇáÊÓáíã (äÓÈÉ ãä Ëãä ÇáæÍÏÉ ÇáÓßäíÉ Úä ßá ÔåÑ ÊÃÎíÑ)", VarValue = "0.5", VarType = "decimal", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 7, VarName = "@7", VarDescription = "ÇáÍÏ ÇáÃŞÕì áÛÑÇãÉ ÊÃÎíÑ ÇáÊÓáíã (äÓÈÉ ãä Ëãä ÇáæÍÏÉ)", VarValue = "5", VarType = "int", IsTafqet = true, IsMoney = false }
//            , new ContractSys { VarId = 8, VarName = "@8", VarDescription = "æÏíÚÉ ÇáÕíÇäÉ Úä ßá ãÊÑ", VarValue = "600", VarType = "int", IsTafqet = false, IsMoney = true }
//            , new ContractSys { VarId = 9, VarName = "@9", VarDescription = "ÇÌãÇáí æÏíÚÉ ÇáÕíÇäÉ", VarValue = "100000", VarType = "int", IsTafqet = true, IsMoney = true }
//            , new ContractSys { VarId = 10, VarName = "@10", VarDescription = "ÃŞÕì ãæÚÏ áÇÓÊáÇã æÏíÚÉ ÇáÕíÇäÉ", VarValue = "1/1/2019", VarType = "datetime", IsTafqet = false, IsMoney = false });

//            context.UnitTypes.AddOrUpdate(p => p.Id
//            , new UnitType { Id = 1, UnitTypeName = "ÔŞÉ", IsParent = false, SubUnitId = null }
//            , new UnitType { Id = 2, UnitTypeName = "ãÍá", IsParent = false, SubUnitId = null }
//            , new UnitType { Id = 3, UnitTypeName = "İíáÇ", IsParent = false, SubUnitId = null }
//            , new UnitType { Id = 4, UnitTypeName = "ÚãÇÑÉ", IsParent = true, SubUnitId = 1 }
//            , new UnitType { Id = 5, UnitTypeName = "ãæá", IsParent = true, SubUnitId = 2 });


//            context.ContractTypes.AddOrUpdate(p => p.Id
//            , new ContractType { Id = 1, Name = "ÊŞÓíØ" }
//            , new ContractType { Id = 2, Name = "Êãáíß" }
//            , new ContractType { Id = 3, Name = "ÇíÌÇÑ" });

//            context.Countries.AddOrUpdate(p => p.Id, new Country { Id = 1, CountryName = "ãÕÑ" });
//            context.Cities.AddOrUpdate(p => p.Id, new City { Id = 1, CountryId = 1, CityName = "ÇáŞÇåÑÉ" });
//            context.Districts.AddOrUpdate(p => p.Id, new District { Id = 1, CityId = 1, DistrictName = "ÇáäÒåÉ" }, new District { Id = 2, CityId = 1, DistrictName = "ÇáÊÌãÚ ÇáÎÇãÓ" });

//            context.Customers.AddOrUpdate(p => p.Id, new Customer { Id = 1, NameArab = "ÚÈÇÓ ãÍãÏ ÚÈÇÓ ÓáíãÇä", NameEng = "Abbas Mohamed Abbas Soliman", Email = "eng.abbasmohamed14@gmail.com", ReligionId = 1, NationalityId = 1, CountryId = 1, CityId = 1, DistrictId = 1, IDTypeId = 1, IdNumber = "29212148801254", IdissuePlace = "Ô ÇáÍÑíÉ ãÑßÒ ØãÇ - ÓæåÇÌ", IdExpiryDate = DateTime.ParseExact("04/07/2025", "dd/MM/yyyy", null), Address = "6 ÔÇÑÚ ÍÓæäÉ - ÔÇÑÚ ÌÓÑ ÇáÓæíÓ ÇáÌÑÇÌ ÈÌæÇÑ ãÕäÚ ÇáãáÇÈÓ " });

//            context.CustomerPhones.AddOrUpdate(p => p.Id, new CustomerPhone { Id = 1, CustomerId = 1, PhoneTypeId = 1, PhoneNo = "01118863234" });

//            context.Projects.AddOrUpdate(p => p.Id
//            , new Project { Id = 1, CountryId = 1, CityId = 1, DistrictId = 2, ProjectName = "ÓÊæä ÑíÒÏäÓ", ProjectContentDetails = "ãäÇØŞ ááİíáÇÊ æãäÇØŞ ÇÏÇÑíÉ æÊÌÇÑíÉ ÈÇáÇÖÇİÉ áãäÇØŞ ÚãÇÑÇÊ ÓßäíÉ", Location = "ŞØÚÉ ÇáÃÑÖ ÑŞã (4) ÈÇáØÑíŞ ÇáÏÇÆÑí- ÇáÊÌãÚ ÇáÎÇãÓ- ãÏíäÉ ÇáŞÇåÑÉ ÇáÌÏíÏÉ", ProjectDescription = "ãÔÑæÚ ãÌÊãÚ ÚãÑÇäí ãÊßÇãá" });
//            context.ProjectOwners.AddOrUpdate(p => p.Id
//            , new ProjectOwner { Id = 1, ProjectId = 1, ProjectOwnerId = 1, IsMainOwner = false, MainOwnerId = 2, ProjectOwnerDelegateName = "åÔÇã ÃÍãÏ ÚÈÏ ÇááØíİ ÇáÚæÖí", ProjectOwnerDelegateRepresent = "ÑÆíÓ ãÌáÓ ÇáÇÏÇÑÉ", ProjectOwnerDetails = "íãÊáß ÚÏÏ ãä ÇáÈäÇíÇÊ ÇáÓßäíÉ" });
//            context.PaymentMethodHeaders.AddOrUpdate(p => p.Id, new PaymentMethodHeader { Id = 1, Name = "6 ÓäæÇÊ", TotalYearPeriod = 6 });
//            context.PaymentMethodDetails.AddOrUpdate(p => p.Id
//            , new PaymentMethodDetail { Id = 1, PaymentMethodHeaderId = 1, PaymentTypeId = 1, IsRatioNotAmount = true, Ratio = 10, MinimumAmount = null, StartFrom = 0, Period = 0, PaymentsCounts = 0 }
//            , new PaymentMethodDetail { Id = 2, PaymentMethodHeaderId = 1, PaymentTypeId = 2, IsRatioNotAmount = true, Ratio = 6.665m, MinimumAmount = null, StartFrom = 3, Period = 0, PaymentsCounts = 0 }
//            , new PaymentMethodDetail { Id = 3, PaymentMethodHeaderId = 1, PaymentTypeId = 5, IsRatioNotAmount = true, Ratio = 0.03125m, MinimumAmount = null, StartFrom = 6, Period = 3, PaymentsCounts = 24 });

//            context.ContractModels.AddOrUpdate(p => p.Id
//            , new ContractModel { Id = 1, ContractTypeId = 1, Name = "ÚŞÏ ÊŞÓíØ ÔŞŞ ÓÊæä ÑÒíÏäÓ" });

//            context.ContractItems.AddOrUpdate(p => p.Id
//                , new ContractItem { Id = 1, ContractModelId = 1, ContractItemName = "ÇáÈäÏ ÇáÃæá", ContractItemString = "íÚÊÈÑÇáÊãåíÏ ÇáÓÇÈŞ æÇáãáÇÍŞ ÇáãÑİŞÉ ÈÇáÚŞÏ Ãæ ÇáÊí Óæİ ÊáÍŞ Èå İíãÇ ÈÚÏ æÇáÊÎØíØ ÇáÚÇã ááãÔÑæÚ ÇáãÍÏÏ Úáíå ãæŞÚ ÇáæÍÏÉ ÇáãÈíÚÉ æÇáÔÑæØ æÇáãæÇÕİÇÊ ÇáãÑİŞÉ ÈåĞÇ ÇáÚŞÏ Ãæ ÇáÊí Óæİ ÊÑİŞ Èå ÌÒÁÇğ áÇ íÊÌÒÃ ãä åĞÇ ÇáÚŞÏ æãßãáÇğ æãÊããÇğ áßÇİÉ ÈäæÏå æÃÍßÇãå æáåÇ ĞÇÊ ÇáŞæÉ æÇáäİÇĞ ÇáŞÇäæäí ÇáÊí áÈäæÏ æÃÍßÇã åĞÇ ÇáÚŞÏ" }

//                , new ContractItem { Id = 2, ContractModelId = 1, ContractItemName = " ÇáÈäÏ ÇáËÇäí (ÈíÇä ÇáãÈíÚ)", ContractItemString = "ÈÇÚ ÇáØÑİ ÇáÃæá Çáì ÇáØÑİ ÇáËÇäí ÇáŞÇÈá áĞáß ÇáæÍÏÉ ÇáÓßäíÉ @103 İí @104 ÈãÔÑæÚ @101 ÇáãŞÇã Úáì @102 æíÈáÛ ÇÌãÇáí ãÓØÍ ÇáæÍÏÉ ÇáÓßäíÉ ãÍá åĞÇ ÇáÚŞÏ  (@105)ã2 İŞØ @106 ãÊÑ ãÑÈÚ  \"ÊÍÊ ÇáÚÌÒ æÇáÒíÇÏÉ\" Úáì ãÇåæ ãÈíä ÈÇáãÓŞØ ÇáÃİŞí æÇáÑÓã ÇáåäÏÓí ááæÍÏÉ ÇáÓßäíÉ ãÍá åĞÇ ÇáÚŞÏ æÇáÊÑÇÎíÕ ÇáÊí ÕÏÑÊ æÇáÊí ÕÊÕÏÑ áÇÍŞÇ ¡ æŞÏ ÇÊİŞ ÇáØÑİÇä Úáì Çä åĞÇ ÇáÈíÚ æÇáÚŞÏ ãæŞæİ Úáì ÔÑØ æÇŞİ æåæ ÓÏÇÏ ßÇãá ÇáËãä İí ÇáãÚÇÏ ÇáãÊİŞ Úáíå æÇáãäÕæÕ Úáíå ¡ æíÚÊÈÑ åĞÇ ÇáÚŞÏ ÛíÑ äÇŞá ááãáßíÉ æÛíÑ ãÑÊÈ áÃíÉ ÍŞæŞ ÚíäíÉ ÃÕáíÉ ÃæÊÈÚíÉ Ãæ ÔÎÕíÉ Úáì ÇáÚíä ãÍá ÇáÊÚÇŞÏ ÇáÇ ÈÚÏ ÓÏÇÏ ÇáØÑİ ÇáËÇäí áßÇãá ÇáËãä İí ÇáãÚÇÏ ÇáãÍÏÏ ¡æíÔãá åĞÇ ÇáÈíÚ ÍÕÉ ÔÇÆÚÉ ÈÇáÃÑÖ ÇáãŞÇã ÚáíåÇ ÇáãÈäì ÇáßÇÆä Èå ÇáæÍÏÉ ÇáãÈíÚÉ ãÍá åĞÇ ÇáÚŞÏ æÇáÃÌÒÇÁ ÇáãÔÊÑßÉ ÊÚÇÏá äÓÈÉ ãÓØÍ ÇáæÍÏÉ ÇáãÈíÚÉ Çáì ßÇãá ãÓÇÍÉ æÍÏÇÊ ÇáÚŞÇÑ æáÇ íÍŞ ááØÑİ ÇáËÇäí ÇáãØÇáÈÉ ÈŞÓãÊåÇ Ãæ ÍÕÉ ãİÑÒÉ ÈåÇ ¡ Úáì Ãä áÇ íÚÏ ãä ÇáÃÌÒÇÁ ÇáãÔÊÑßÉ ßÇãá ãÓÇÍÉ ÇáÓØÍ æÇáÍÏíŞÉ ÍíË ÃäåãÇ ãáß ááØÑİ ÇáÃæá æáå æÍÏå ÍŞ ÇáÊÕÑİ İíåÇ æÇÓÊÚãÇáåÇ ¡ ßãÇ Ãä ÇáãÊİŞ Úáíå Èíä ÇáØÑİíä Ãä åĞÇ ÇáÈíÚ áÇ íÔãá Ãí ÍŞæŞ İíãÇ íÎÕ ÇáãÑÇİŞ ÇáÚÇãÉ æÇáØÑŞ æÇáÃÑÕİÉ æÇáÔæÇÑÚ ÇáÏÇÎáíÉ æÇáãÓÇÍÇÊ æÇáãÈÇäí ÇáãÎÕÕÉ ááãäİÚÉ ÇáÚÇãÉ æÇáÍÏÇÆŞ ÇáÚÇãÉ æÇáãäÇØŞ ÇáÎÏãíÉ ÃíäãÇ æÌÏÊ æÎáÇİå ãä ÇáãäÔÂÊ ÇáÊí íŞíãåÇ ÇáØÑİ ÇáÃæá ¡ ÍíË Ãä Êáß ÇáãäÔÂÊ ÊÚÏ ãáßÇğ ááØÑİ ÇáÃæá." }

//                , new ContractItem { Id = 3, ContractModelId = 1, ContractItemName = "ÇáÈäÏ ÇáËÇáË (ÇáËãä æØÑíŞÉ ÇáÏİÚ)", ContractItemString = "Êã åĞÇ ÇáÈíÚ ãŞÇÈá Ëãä ÇÌãÇáí æŞÏÑå (@107) (İŞØ @108 İŞØ áÇ ÛíÑ) ¡ ÇÊİŞ ÇáØÑİÇä Úáì Çä íÊã ÓÏÇÏåÇ ßãÇ åæ æÇÑÏ İí ÌÏæá ÇáÓÏÇÏ" }

//                //                , new ContractItem { Id = 4, ContractItemName = "ÇáÈäÏ ÇáÑÇÈÚ (ÇáÇáÊÒÇã ÈÇáÓÏÇÏ)", ContractItemString = @"1-íáÊÒã ÇáØÑİ ÇáËÇäí ÈÓÏÇÏ ÈÇŞí Ëãä ÇáÈíÚ ÈÇáßÇãá İí ÇáãæÇÚíÏ ÇáãÊİŞ ÚáíåÇ
//                //2-æíÍÙÑ Úá ÇáØÑİ ÇáËÇäí ÇáÊÃÎÑ Ãæ ÇáÃãÊäÇÚ Úä ÇáÓÏÇÏ áÇí ÓÈÈ ãä ÇáÃÓÈÇÈ ÃíÇ ßÇä  ¡ æíÚÊÈÑ ÊæŞíÚ ÇáØÑİ ÇáËÇäí Úáì åĞÇ ÇáÚŞÏ ÇŞÑÇÑÇğ ãäå ÈĞáß æÊäÇÒá äåÇÆí ãä ÇáØÑİ ÇáËÇäí Úä Ãí ÍŞ áå İí ÇáÍÈÓ Ãæ ÇáÏİÚ ÈÚÏã ÇáÊäİíĞ ¡ æíÚÊÈÑ ÇÎáÇá ÇáØÑİ ÇáËÇäí ÈĞáß ÇÎáÇá ÌæåÑí ÈÔÑæØ ÇáÚŞÏ íÈíÍ ááØÑŞ ÇáÃæá ÇÚãÇá ÇáÔÑØ ÇáÕÑíÍ ÇáİÇÓÎ ÇáæÇÑÏ ÈÇáÈäÏ ÇáÎÇãÓ ãä åĞÇ ÇáÚŞÏ
//                //" }
//                //                , new ContractItem { Id = 5, ContractItemName = "ÇáÈäÏ ÇáÎÇãÓ (ÇáÊÃÎíÑ İí ÇáÓÏÇÏ)", ContractItemString = @"1-ÇĞÇ ÊÃÎÑ Ãæ ÊÎáİ Ãæ ÇãÊäÚ ÇáØÑİ ÇáËÇäí Úä ÓÏÇÏ ŞíãÉ Ãí ŞÓØ İí ÇáãæÚÏ ÇáãÍÏÏ áå áÃí ÓÈÈ ãä ÇáÃÓÈÇÈ ÃßËÑ ãä ãÏÉ ÚÔÑÉ ÃíÇã ãä ÊÇÑíÎ ÇáÅÓÊÍŞÇŞ İíÍŞ ááØÑİ ÇáÃæá ÊÍÕíá ÛÑÇãÉ ŞÏÑåÇ  @ÛÑÇãÉÇáÊÃÎíÑ (@ÛÑÇãÉÇáÊÃÎíÑãİÕáÉ áÇ ÛíÑ) ãä ŞíãÉ ÇáŞÓØ Úä ßá ÔåÑ ÊÃÎíÑ Ãæ ÌÒÃãä ÇáÔåÑ Úáì Çä ÊÓÊÍŞ ÈÏÇíÉ ãä ÊÇÑíÎ ÇáŞÓØ ÇáãÊÃÎÑ æÍÊì ÊÇÑíÎ ÇáÓÏÇÏ  ¡ ßãÇ íÍŞ ááØÑİ ÇáÃæá ÃíÖÇ İí åĞå ÇáÍÇáÉ ÇĞÇ ÊÌÇæÒÉ ãÏÉ ÇáÊÃÎíÑ áÃßËÑ ãä 60 íæãÇ ãä ÊÇÑíÎ ÇáÃÓÊÍŞÇŞ ÇÚÊÈÇÑ åĞÇ ÇáÚŞÏ ãİÓæÎÇ ãä ÊáŞÇÁ äİÓå Ïæä ÍÇÌÉ Çáì ÊäÈíå Çæ ÇäĞÇÑ Ãæ ÕÏæÑ Íßã ŞÖÇÆí ÈĞáß Ãæ ÇÊÎÇĞ ÇíÉ ÇÌÑÇÁÇÊ ŞÖÇÆíÉ æÇÓÊÑÏÇÏ ÇáæÍÏÉ ÇáÓßäíÉ ãä ÊÍÊ íÏ ÇáØÑİ ÇáËÇäí Ãæ Ãí íÏ ßÇäÊ Åä ßÇä ŞÏ ÇÓÊáãåÇ æíÊã ÑÏ ãÇ Êã ÓÏÇÏå ãä ÇáËãä ÈÚÏ ÎÕã ŞíãÉ (@ÛÑÇãÉÇÓÊÑÏÇÏ) (İŞØ @ÛÑÇãÉÇÓÊÑÏÇÏãİÕáÉ) ãä ÇÌãÇáí ŞíãÉ ÇáæÍÏÉ ÇáÓßäíÉ ãÍá åĞÇ ÇáÚŞÏ ãŞÇÈá ÇáãÕÑæİÇÊ ÇáÅÏÇÑíÉ æÇáÏÚÇíÉ æÇáÅÚáÇä æÛíÑåÇ ãä ÇáãÕÑæİÇÊ ÇáÊí ÊßÈÏåÇ ÇáØÑİ ÇáÃæá İí ÓÈíá ÇÊãÇã åĞÇ ÇáÚŞÏ  æÇáÊí íŞÑ ÈåÇ ÇáØÑİ ÇáËÇäí æÇäåÇ ŞíãÉ ÛíÑ ÎÇÖÚÉ áÑŞÇÈÉ ÇáŞÖÇÁ æĞáß áÃä ÓÈÈ İÓÎ ÇáÚŞÏ íÑÌÚ Çáì ÇáØÑİ ÇáËÇäí  ¡ æÚáì Ãä íÊã ÑÏ ÇáãÈÇáÛ Úáì ÃŞÓÇØ æÚáì ãÏÏ ããÇËáÉ ááÃŞÓÇØ æÇáãÏÏ ÇáÊí Êã ÈåÇ ÇáÓÏÇÏ ãä ŞÈá ÇáØÑİ ÇáËÇäí æÚáì Ãä íÈÏÃ ÇÓÊÍŞÇŞ ÇáØÑİ ÇáËÇäí áÊáß ÇáãÈÇáÛ ÈÚÏ ÇÚÇÏÉ ÈíÚ ÇáØÑİ ÇáÃæá ááæÍÏÉ ÇáãÓÊÑÏÉ æááØÑİ ÇáÃæá ÇáÍŞ İí ÇáãØÇáÈÉ Èßá Ãæ ÈÚÖ ãÇ ĞßÑ
//                //2-íÍŞ ááØÑİ ÇáÃæá İí ÍÇáÉ İÓÎ ÇáÚŞÏ ÇáÊÕÑİ İí ÇáæÍÏÉ ÇáÓßäíÉ ãÍá åĞÇ ÇáÚŞÏ ááÛíÑ Ïæä Ãä íßæä ááØÑİ ÇáËÇäí Ãí ÍŞ İí ÇáÅÚÊÑÇÖ Úáì Ğáß
//                //3-æáÇ íÚÊÈÑ ÊãÓß ÇáØÑİ ÇáÃæá (ÇáÈÇÆÚ) ÈÇáÔÑØ ÇáÕÑíÍ ÇáİÇÓÎ ÈÇáäÓÈÉ Çáì ÃÍÏ ÇáÃŞÓÇØ ÊäÇÒáÇ ãäå Úä ÇáÊãÓß Èå ÈÇáäÓÈÉ Çáì ÛíÑå ãä ÇáÃŞÓÇØ
//                //" }
//                //                , new ContractItem { Id = 6, ContractItemName = "ÇáÈäÏ ÇáÓÇÏÓ (ÚÏæá ÇáØÑİ ÇáËÇäí Úä ÇáÈíÚ)", ContractItemString = @"İí ÍÇáÉ ÑÛÈÉ ÇáØÑİ ÇáËÇäí İí ÇáÚÏæá Úä ÇÊãÇã ÇáÈíÚ æİÓÎ ÇáÚŞÏ æÇÓÊÑÏÇÏ ãÇ ÓÈŞ ÓÏÇÏå ãä ÃŞÓÇØ æÇÚÇÏÉ ÇáÍÇá áãÇ ßÇäÊ Úáíå ŞÈá ÇáÊÚÇŞÏ  ¡ İÚáíå ÇáÊŞÏã ÈØáÈ ÑÓãí Åáì ÇáØÑİ ÇáÃæá íÈÏí İíå ÑÛÈÊå Êáß ¡ æíÊã ÇáÈÊ ÈÇáØáÈ ÈÇáãæÇİŞÉ ÃæÇáÑİÖ İí ãÏÉ ÃŞÕÇåÇ ÔåÑ ãä ÊÇÑíÎ ÊŞÏíãå æİí ÍÇáÉ ÇáãæÇİŞÉ Úáì ÇáÚÏæá Ãæ ÇáİÓÎ ÈäÇÁÇğ Úáì ØáÈ ÇáØÑİ ÇáËÇäí İíÊã ÎÕã ãÈáÛ íÚÇÏá @ÛÑÇãÉÇÓÊÑÏÇÏ (İŞØ @ÛÑÇãÉÇÓÊÑÏÇÏãİÕáÉ áÇÛíÑ) ãä ÇÌãÇáí ŞíãÉ ÇáæÍÏÉ ÇáÓßäíÉ ãŞÇÈá ÇáãÕÇÑíİ ÇáÅÏÇÑíÉ Úä İÓÎ ÇáÚŞÏ ßÊÚæíÖ ÇÊİÇŞí Úä ØáÈ ÇáÚÏæá áÇ íÎÖÚ áÑŞÇÈÉ ÇáŞÖÇÁ ¡ æíáÊÒã ÇáØÑİ ÇáËÇäí ÈÑÏ ÇáæÍÏÉ ÇáÓßäíÉ ãÍá åĞÇ ÇáÚŞÏ Çä ßÇä ŞÏ ÇÓÊáãåÇ ¡ Ëã íŞæã ÇáØÑİ ÇáÃæá ÈÑÏ ÇáËãä ÇáãÏİæÚ ÈÚÏ ÎÕã Êáß ÇáäÓÈÉ Úáì Ãä íÊã ÇáÑÏ ÈĞÇÊ ØÑíŞÉ ÓÏÇÏ ÇáÃŞÓÇØ æÎáÇá ãÏÏ ããÇËáÉ ááÃŞÓÇØ æÇáãÏÏ ÇáÊí Êã ÈåÇ ÇáÓÏÇÏ ãä ŞÈá ÇáØÑİ ÇáËÇäí ¡ Úáì Ãä íÈÏÃ ÇáØÑİ ÇáÃæá İí ÑÏ ÇáãÈÇáÛ ÈÚÏ ÅÚÇÏÉ ÈíÚ ÇáØÑİ ÇáÃæá ááæÍÏÉ ÇáãÓÊÑÏÉ¡ æİí ÌãíÚ ÇáÃÍæÇá íÍŞ ááØÑİ ÇáÃæá ÈÅÑÇÏÊå ÇáãäİÑÏÉ ÚÏã ÇáãæÇİŞÉ Úáì ØáÈ ÇáÚÏæá Ãæ ÇÑÌÇÁ ÇáÈÊ İíå" }

//                //                , new ContractItem { Id = 7, ContractItemName = "ÇáÈäÏ ÇáÓÇÈÚ (İÓÎ ÇáÚŞÏ æÊÓáíã ÇáæÍÏÉ ÇáÓßäíÉ)", ContractItemString = @"ãÚ ÚÏã ÇáÅÎáÇá áãÇ Êã ÇáÅÊİÇŞ Úáíå ÈÇáÈäÏ ÇáÎÇãÓ æÈÇŞí ÈäæÏ ÇáÚŞÏ İÅäå İí ÍÇáÉ İÓÎ Ãæ ÇäİÓÇÎ Ãæ ÑÏ Ãæ ÇÈØÇá Ãæ ÈØáÇä åĞÇ ÇáÚŞÏ áÃí ÓÈÈ ãä ÇáÃÓÈÇÈ ÃíÇ ßÇä ¡ İíáÊÒã ÇáØÑİ ÇáËÇäí ÈÑÏ æÊÓáíã ÇáæÍÏÉ ÇáÓßäíÉ ãÍá åĞÇ ÇáÚŞÏ İí ÍÇáÉ ÇÓÊáÇãåÇ ¡ ÎÇáíÉ ÊãÇãÇ ãä ÇáÔæÇÛá Ãæ ÇáÃÔÎÇÕ æÈÇáÍÇáÉ ÇáÊí ßÇäÊ ÚáíåÇ Çáì ÇáØÑİ ÇáÃæá ¡ Úáì Ãä íÊã Ğáß İæÑÇ Ïæä ÍÇÌÉ Çá ÊäÈíå Ãæ ÇäĞÇÑ Ãæ ÕÏæÑ Íßã ŞÖÇÆí ¡ æáÇ íÓÑí İí ÍŞ ÇáØÑİ ÇáÃæá Ãí ÅÌÑÇÁ Ãæ ÚŞæÏ Ãæ Ãí ÊÕÑİ ãä ÇáÊÕÑİÇÊ ÇáÊí ŞÏ íßæä ÇáØÑİ ÇáËÇäí ŞÏ ÃÈÑãåÇ İí ÔÃä ÇáæÍÏÉ ÇáÓßäíÉ ãÍá ÇáÚŞÏ Ãæ Ãí ÍŞ ãä ÇáÍŞæŞ ÇáÊí íßæä ŞÏ ÑÊÈåÇ ÚáíåÇ ÓæÇÁ ßÇäÊ ÍŞæŞ ÚíäíÉ Ãæ ÊÈÚíÉ Ãæ ÔÎÕíÉ Ãæ Ãí ŞÑæÖ Ãæ ÖãÇäÇÊ Úáì ÇáÚíä ãÍá åĞÇ ÇáÚŞÏ ¡æİí ÍÇáÉ ÇÎáÇá ÇáØÑİ ÇáËÇäí ÈÑÏ ÇáÚíä æÊÓáíãåÇ İÊÚÊÈÑ íÏå Ãæ íÏ ãä Íá ãÍáå íÏ ÛÇÕÈÉ æíÍŞ ááØÑİ ÇáÃæá ÇááÌæÁ Çáì ÇáŞÖÇÁ ÇáãÓÊÚÌá áÅÎáÇÁ ÇáæÍÏÉ ÇáÓßäíÉ æÇÓÊáÇãåÇ æÅÚÇÏÉ ÍÇáÊåÇ Åáì ãÇßÇäÊ Úáíå ÈäİŞÇÊ ÊÎÕã ããÇ íßæä ÇáØÑİ ÇáËÇäí ŞÏ ÓÏÏå ãä ÇáËãä ãÚ ÇáÊÚæíÖÇÊ ÇááÇÒãÉ ¡ æßÇİÉ Ğáß Ïæä ÍÇÌÉ Çáì ÊäÈíå Ãæ ÇäĞÇÑ Ãæ ÕÏæÑ Íßã ŞÖÇÆí " }

//                //                  , new ContractItem { Id = 8, ContractItemName = "ÇáÈäÏ ÇáËÇãä (ÇáÊÕÑİ İí ÇáæÍÏÉ ÇáÓßäíÉ)", ContractItemString = @"1-ãä ÇáãÊİŞ Úáíå Ãä åĞÇ ÇáÚŞÏ åæ ÚŞÏ ãÚáŞ Úáì ÔÑØ æÇŞİ æåæ ÓÏÇÏ ßÇãá ÃŞÓÇØ ÇáËãä İí ãæÇÚíÏåÇ æåæ ÛíÑ äÇŞá ááãáßíÉ ÅáÇ ÈÚÏ ÓÏÇÏ ßÇãá ÇáËãä ØÈŞÇ áãÇ Êã ÇáÇÊİÇŞ Úáíå ¡ æãÇ íÓÊÍŞ ááØÑİ ÇáÃæá İí ÇáãæÇÚíÏ ÇáãÊİŞ ÚáíåÇ æíÍÊİÙ ÇáØÑİ ÇáÃæá ÈãáßíÉ ÇáæÍÏÉ ÇáÓßäíÉ ÇáãÈíÚÉ æíßæä áå ÍŞ ÇãÊíÇÒ ÚáíåÇ ÍÊì ÇáæİÇÁ ÈßÇãá ÇáËãä 
//                //2-æãä ÇáãÊİŞ Úáíå Èíä ÇáØÑİíä Ãä íÍá ãÍá ÇáØÑİ ÇáËÇäí İí ÍÇáÉ æİÇÊå Ãæ İŞÏÇä ÃåáíÊå ŞÈá ÓÏÇÏ ßÇãá ÇáËãä æÑËÊå (ÇáÎáİ ÇáÚÇã) İí ÍÇáÉ ÇÈÏÇÁ ÇáÑÛÈÉ ÈĞáß ÎáÇá ËáÇËÉ ÃÔåÑ ãä ÊÇÑíÎ ÇáæİÇÉ -áÇ ŞÏÑ Çááå- Ãæ İŞÏÇä ÇáÃåáíÉ ÈÔÑØ ÇáÇáÊÒÇã ÈßÇİÉ ÇáÇáÊÒÇãÇÊ ÇáãŞÑÑÉ İí åĞÇ ÇáÚŞÏ Úáì ãæÑËåã ÇáØÑİ ÇáËÇäí ÇáãÔÊÑí æİí ÍÇáÉ ØáÈåã ÇáÚÏæá Úä ÊãÇã ÇáÈíÚ Ãæ ÇáÚŞÏ íÓÑí Úáíåã ãÇ ßÇä íÓÑí Úáì ãæÑËåã ÍÓÈãÇ æÑÏ İí ÇáÈäÏ ÇáÓÇÏÓ ãä åĞÇ ÇáÚŞÏ 
//                //æáÇ íÌæÒ ááØÑİ ÇáËÇäí ÇáãÔÊÑí Ãæ Îáİå ÇáÚÇã ÓæÇÁ ŞÈá Ãæ ÈÚÏ ÇÓÊáÇã ÇáæÍÏÉ ÇáÓßäíÉ ÇÊÎÇĞ Ãí ÇÌÑÇÁ Ãæ ÇÈÑÇã Ãí ÚŞÏ Ãæ ÇáÊÕÑİ İí ÇáæÍÏÉ ãÍá åĞÇ ÇáÚŞÏ ÈÃí æÌå ãä ÃæÌå ÇáÊÕÑİÇÊ Ãæ ÊÑÊíÈ Ãí ÍŞæŞ ÚíäíÉ ÃÕáíÉ Ãæ ÊÈÚíÉ Ãæ ÍŞæŞ ÔÎÕíÉ Ãæ ÇáÍÕæá Úáì Ãí ŞÑæÖ Ãæ ÖãÇäÇÊ Ãæ ãäÍ Ãí ÊæßíáÇÊ ÈÔÃä ÇáæÍÏÉ ãÍá åĞÇ ÇáÚŞÏ ¡ æÈÕİÉ ÚÇãÉ áÇ íÍŞ áåãÇ ÊÑÊíÈ Ãí ÇáÊÒÇãÇÊ Úáì ÇáæÍÏÉ ÇáÓßäíÉ ÇáÇ ÈÚÏ ÓÏÇÏ ßÇãá ÇáËãä æÃí ãÕÇÑíİ ãÓÊÍŞÉ İí ĞãÊåã ááØÑİ ÇáÃæá 
//                //3-æİí ÍÇáÉ ÊÕÑİ ÇáØÑİ ÇáËÇäí Ãæ Îáİå ÇáÚÇã İí ÇáæÍÏÉ ÇáÓßäíÉ Ãæ İí ÌÒÁ ãäåÇ ŞÈá ÓÏÇÏ ßÇãá ÇáËãä æßÇİÉ ÇáãÈÇáÛ ÇáãÓÊÍŞÉ İí ĞãÊåã ááØÑİ ÇáÃæá  ÃÚÊÈÑ åĞÇ ÇáÚŞÏ ãİÓæÎÇ ãä ÊáŞÇÁ äİÓå Ïæä ÇáÍÇÌÉ Çáì ÊäÈíå Ãæ ÇäĞÇÑ Ãæ ÇÓÊÕÏÇÑ Íßã ŞÖÇÆí Ãæ ÇÊÎÇĞ Ãí ÇÌÑÇÁÇÊ æíßæä ááØÑİ ÇáÃæá ÇÓÊÑÏÇÏ ÇáÚíä ãÍá åĞÇ ÇáÚŞÏ ãä ÊÍÊ Ãí íÏ ßÇäÊ ãÚ ÇáÇÍÊİÇÙ ÈãÇ ŞÇã ÇáØÑİ ÇáËÇäí Ãæ Îáİå ÇáÚÇã ÈÓÏÇÏå ãä Ëãä ßÊÚæíÖ ÇÊİÇŞí Úä ÇáÇÎáÇá ÈåĞÇ ÇáÇáÊÒÇã ÛíÑ ÎÇÖÚ áÑŞÇÈÉ ÇáŞÖÇÁ¡ æßÇİÉ Ğáß Ïæä ÍÇÌÉ Çáì ÊäÈíå Ãæ ÇäĞÇÑ Ãæ ÕÏæÑ Íßã ŞÖÇÆí 
//                //4-åĞÇ æãÚ ÚÏã ÇáÇÎáÇá ÈÃÍßÇã ÇáİŞÑÇÊ ÇáÓÇÈŞÉ ÈåĞÇ ÇáÈäÏ İíÌæÒ ááØÑİ ÇáËÇäí İí ÍÇáÉ ÑÛÈÊå İí ÇáÊäÇÒá Úä ÇáæÍÏÉ ãÍá åĞÇ ÇáÚŞÏ ááÛíÑ Ãä íÊŞÏã ÈØáÈ ááØÑİ ÇáÃæá íÈÏí İíå ÑÛÈÊå Êáß ¡ æíßæä ááØÑİ ÇáÃæá ãØáŞ ÇáÍÑíÉ İí ÇáŞÈæá Ãæ ÇáÑİÖ ¡ æİí ÍÇáÉ ãæÇİŞÉ ÇáØÑİ ÇáÃæá Úáì ÑÛÈÉ ÇáØÑİ ÇáËÇäí İí ÇáÊäÇÒá ¡İíÌÈ Ãä íÊã ÇáÊäÇÒá ÈãÚÑİÉ æãÕÇÏŞÉ ÇáØÑİ ÇáÃæá Úáì ÇáÊäÇÒá æáÇ íäİĞ ÇáÊäÇÒá ÇáÇ ÈãÕÇÏŞÉ ÇáØÑİ ÇáÃæá ¡ Úáì Çä íÊã ÇáÊäÇÒá ÈÚÏ ÓÏÇÏ ÇáØÑİ ÇáËÇäí ááØÑİ ÇáÃæá @ÛÑÇãÉÇáÊäÇÒá (İŞØ @ÛÑÇãÉÇáÊäÇÒáãİÕáÉ áÇ ÛíÑ) ãä ŞíãÉ ÇáæÍÏÉ ÇáÓßäíÉ ãŞÇÈá ÇáãÕÇÑíİ ÇáÅÏÇÑíÉ ÇááÇÒãÉ¡ æíÓÊËäì ãä Êáß ÇáãÕÇÑíİ ÇáÊäÇÒá áÕÇáÍ ÇáÃŞÇÑÈ ãä ÇáÏÑÌÉ ÇáÃæáì æáãÑÉ æÇÍÏÉ İŞØ
//                //" }

//                //                  , new ContractItem { Id = 9, ContractItemName = "ÇáÈäÏ ÇáÊÇÓÚ (ãÚÇíäÉ ÇáæÍÏÉ ÇáÓßäíÉ ÇáãÈíÚÉ)", ContractItemString = @"íŞÑ ÇáØÑİ ÇáËÇäí Ãäå ÇØáÚ Úáì ÇáÊÎØíØ ÇáÚÇã ááãÔÑæÚ æãæŞÚå æÇáãæŞÚ ÇáĞí ÓÊŞÇã Úáíå ÇáæÍÏÉ ãÍá åĞÇ ÇáÚŞÏ æÇáÑÓæãÇÊ ÇáåäÏÓíÉ ÇáÎÇÕÉ ÈäãæĞÌ ÇáÈäÇÁ ÇáãÑİŞ ÈÇáÚŞÏ ÇáĞí ÊÚÇŞÏ Úáíå ãÚ ÇáØÑİ ÇáÃæá Úáì ÇŞÇãÊå æÇáãÓŞØ ÇáÃİŞí æÇáÑÓã ÇáãæÖÍ ááÔŞÉ ãÍá ÇáÚŞÏ ¡ æÚáã ÈãæÇÕİÇÊ ÅŞÇãÉ ãÈÇäí ÇáæÍÏÉ ÇáÓßäíÉ ãæÖæÚ åĞÇ ÇáÚŞÏ æÃÊã ÇáãÚÇíäÉ ÇáÊÇãÉ ÇáäÇİíÉ ááÌåÇáÉ ÔÑÚÇ æŞÇäæäÇ æİŞÇ áãÇ ÊŞÏã æÚáã ÈãæŞÚåÇ ãä ÇáãÔÑæÚ æŞÈá ÇáÔÑÇÁ ÈäÇÁÇğ Úáì Ğáß ßãÇ íŞÑ ÈÃäå áÇ íÌæÒ áå ÈÚÏ Ğáß Ãä íØáÈ ÊÛííÑ ãæŞÚåÇ ÈæÍÏÉ ãä æÍÏÇÊ ÇáãÔÑæÚ Ãæ ÇÌÑÇÁ ÊÚÏíá İíåÇ íÎÇáİ äãæĞÌ ÇáÈäÇÁ ÇáãÊÚÇŞÏ Úáíå ÇáÇ ÈãæÇİŞÉ ÇáØÑİ ÇáÃæá Úáì Ğáß ßÊÇÈÉ ßãÇ íŞÈá ÇáØÑİ ÇáËÇäí ãä ÇáÂä æÈÕİÉ äåÇÆíÉ Ãä íŞÊÕÑ ÇäÊİÇÚå ÈÇáæÍÏÉ ÇáÓßäíÉ ÇáãÈíÚÉ Úáì ÇáÛÑÖ ÇáĞí ÎÕÕ ãä ÃÌáå æåæ ÇáÓßä æáÇ íÌæÒ áå Ãæ áÎáİå ÇáÚÇã Ãæ ÇáÎÇÕ ÊÛííÑ Ğáß ÇáÛÑÖ áÅÓÊÛáÇáå İí äÔÇØ ÂÎÑ ãä ÇáÃäÔØÉ ÛíÑ ÇáÓßäíÉ ÃíÇ ßÇäÊ æíÚÊÈÑ åĞÇ ÇáÊÒÇã ÌæåÑí İí ÇÈÑÇã åĞÇ ÇáÚŞÏ ¡ ßãÇ íŞÑ ÇáØÑİ ÇáËÇäí Ãäå áÇ íÌæÒ áå ÇáÑÌæÚ Úáì ÇáØÑİ ÇáÃæá Ãæ ØáÈ İÓÎ Ãæ ÅäİÓÇÎ Ãæ ÑÏ Ãæ ÅÈØÇá Ãæ ÈØáÇä ÇáÚŞÏ Ãæ ÇáãØÇáÈÉ ÈÃí ÍŞæŞ ÈÔÃä Ğáß áÃí ÓÈÈ ãä ÇáÃÓÈÇÈ" }
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
//		values (@NotificationMaxId,GETDATE(),'ÍÇä ãæÚÏ ÓÏÇÏ ÇáŞÓØ ÑŞã '+Convert(nvarchar,@Id),'/RealEstate/RegisterdInstallments/Index/'+Convert(nvarchar,@Id),1,'SystemServerAgent');
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
