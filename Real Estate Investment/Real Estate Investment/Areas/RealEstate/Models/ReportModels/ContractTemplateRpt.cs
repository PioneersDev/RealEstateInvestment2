using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.Models.ReportModels
{
    public class ContractRpt
    {
        public RptContractRequest RptContractRequest { get; set; }
        public List<RptInstallmentData> RptInstallmentData { get; set; }
        public List<RptDeliverySpecification> RptDeliverySpecification { get; set; }
        public List<RptContractItem> RptContractItem { get; set; }
        public RptProject RptProject { get; set; }
        public RptUnit RptUnit { get; set; }
        public RptCustomer RptCustomer { get; set; }
        public RptProjectOwner RptProjectOwner { get; set; }
    }
    public class RptContractRequest
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string RequestTypeId { get; set; }

        public string RequestTypeName { get; set; }

        public string Step { get; set; }

        public string StepName { get; set; }

        public string Status { get; set; }

        public string StatusName { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string UnitId { get; set; }

        public string UnitName { get; set; }

        public string MainUnitId { get; set; }

        public string MainUnitName { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string SubCustomerId { get; set; }

        public string ContractDate { get; set; }

        public string ContractDay { get; set; }

        public string PaymentMethodHeaderId { get; set; }

        public string PaymentMethodHeaderName { get; set; }

        public string ContractTypeId { get; set; }

        public string ContractTypeName { get; set; }

        public string ContractModelId { get; set; }

        public string ContractModelName { get; set; }

        public string UnitTotalValue { get; set; }

        public string DocHeaderId { get; set; }

        public string DocHeaderName { get; set; }

        public string ContractId { get; set; }
    }

    public class RptInstallmentData
    {
        public string Id { get; set; }

        public string ContractId { get; set; }

        public string CustomerId { get; set; }

        public string PaymentMethodDetailId { get; set; }

        public string payName { get; set; }

        public string Serial { get; set; }

        public string PayDate { get; set; }

        public string PayValue { get; set; }

        public string PayNote { get; set; }

        public string TransactionDate { get; set; }

        public string IsPaid { get; set; }

        public string RefId { get; set; }

        public string PayCount { get; set; }
    }

    public class RptDeliverySpecification
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class RptContractItem
    {
        public string Id { get; set; }

        public string ContractItemName { get; set; }

        public string ContractItemString { get; set; }
    }
    public class RptProject
    {
        public string Id { get; set; }

        public string ProjectName { get; set; }

        public string TransmissionDate { get; set; }

        public string ProjectDescription { get; set; }

        public string ProjectContentDetails { get; set; }

        public string Location { get; set; }

        public string CountryId { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public string DistrictId { get; set; }

        public string DocHeaderId { get; set; }
    }

    public class RptUnit
    {
        public string Id { get; set; }

        public string ProjectUnitTypeId { get; set; }

        public string UnitName { get; set; }

        public string TotalMeters { get; set; }

        public string TotalPrice { get; set; }

        public string NetPrice { get; set; }

        public string MeterPrice { get; set; }

        public string Description { get; set; }

        public string Garage { get; set; }

        public string GarageMetes { get; set; }

        public string GaragePrice { get; set; }

        public string Perecent { get; set; }

        public string MaintenanceDeposit { get; set; }

        public string MainUnitId { get; set; }

        public string ProjectId { get; set; }

        public string UnitNo { get; set; }

        public string UnitContractAddress { get; set; }

        public string FloorNumber { get; set; }

        public string StatusId { get; set; }

        public string DocHeaderId { get; set; }

        public string UnitTypeName { get; set; }
    }
    public class RptCustomer
    {
        public string Id { get; set; }

        public string NameArab { get; set; }

        public string NameEng { get; set; }

        public string Address { get; set; }

        public string IdNumber { get; set; }
        public string IdNumberForAgent { get; set; }

        public string IdissuePlace { get; set; }

        public string IdExpiryDate { get; set; }

        public string Occupation { get; set; }

        public string Email { get; set; }

        public string NationalityId { get; set; }

        public string NationalityName { get; set; }

        public string ReligionId { get; set; }

        public string IDTypeId { get; set; }

        public string IDTypeName { get; set; }

        public string CountryId { get; set; }

        public string CityId { get; set; }

        public string DistrictId { get; set; }
    }
    public class RptProjectOwner
    {
        public string Id { get; set; }

        public string ProjectId { get; set; }

        public string ProjectOwnerId { get; set; }

        public string ProjectOwnerName { get; set; }

        public string ProjectOwnerAddress { get; set; }

        public string ProjectOwnerDelegateName { get; set; }

        public string ProjectOwnerDelegateRepresent { get; set; }

        public string ProjectOwnerDetails { get; set; }

        public string IsMainOwner { get; set; }

        public string MainOwnerId { get; set; }

        public string MainOwnerName { get; set; }

        public string MainOwnerAddress { get; set; }
    }
}