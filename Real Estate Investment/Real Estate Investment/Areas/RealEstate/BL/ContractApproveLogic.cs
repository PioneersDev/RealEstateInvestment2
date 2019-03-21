using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public enum ContractApproveColumns
    {
        Id = 0,
        ContractId = 1,
        ProjectName = 2,
        MainUnitName = 3,
        UnitName = 4,
        CustomerName = 5,
        ContractDate = 6,
        CurrentStatus = 7,
        Remarks = 8,
        ContractDetails = 9,
        DocHeader = 10,
        dropdownlist = 11,
        RegisterContract = 12
    }

    public class ListItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public bool IsApproved { get; set; }
    }

    public class ContractApproveStepsColumns
    {
        static public List<ContractApproveColumns> Step2 = new List<ContractApproveColumns>() { ContractApproveColumns.Id, ContractApproveColumns.ContractId, ContractApproveColumns.ContractDate, ContractApproveColumns.ProjectName, ContractApproveColumns.MainUnitName, ContractApproveColumns.UnitName, ContractApproveColumns.CustomerName, ContractApproveColumns.ContractDate, ContractApproveColumns.CurrentStatus, ContractApproveColumns.Remarks, ContractApproveColumns.ContractDetails, ContractApproveColumns.DocHeader, ContractApproveColumns.dropdownlist };

        static public List<ContractApproveColumns> Step3 = new List<ContractApproveColumns>() { ContractApproveColumns.Id, ContractApproveColumns.ContractId, ContractApproveColumns.ContractDate, ContractApproveColumns.ProjectName, ContractApproveColumns.MainUnitName, ContractApproveColumns.UnitName, ContractApproveColumns.CustomerName, ContractApproveColumns.ContractDate, ContractApproveColumns.CurrentStatus, ContractApproveColumns.Remarks, ContractApproveColumns.ContractDetails, ContractApproveColumns.DocHeader, ContractApproveColumns.RegisterContract };

        public static List<ContractApproveColumns> GetStepColumns(int StepOrder)
        {
            List<ContractApproveColumns> StepColumns = null;
            switch (StepOrder)
            {
                case 2:
                    StepColumns = Step2; break;
                case 3:
                    StepColumns = Step3; break;
            }
            return StepColumns;
        }
    }

    public class ContractApproveDataTable
    {
        public List<ContractApproveModel> data { get; set; }
        public List<List<ContractApproveColumns>> contractapprovestepcolumns;
    }
    public class ContractApproveModel : IDisposable
    {
        private dbContainer _db;
        private ApplicationDbContext _context;
        public ContractApproveModel(ContractRequests instance)
        {
            _db = new dbContainer();
            _context = new ApplicationDbContext();
            AutoMapper.Mapper.Map(instance, this);
        }
        public long Id { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int RequestTypeId { get; set; }

        public string RequestTypeName { get; set; }

        public int Step { get; set; }

        public string StepName { get; set; }

        public string Remarks { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public int? MainUnitId { get; set; }

        public string MainUnitName { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string SubCustomerId { get; set; }

        private DateTime contractdate;

        public object ContractDate { get { return contractdate.ToString("dd/MM/yyyy"); } set { contractdate = ((DateTime)value); } }

        public int PaymentMethodHeaderId { get; set; }

        public string PaymentMethodHeaderName { get; set; }

        public int UnitTotalValue { get; set; }

        public int? DocHeaderId { get; set; }

        public string DocHeaderName { get; set; }

        public long? ContractId { get; set; }

        public string CurrentStatus
        {
            get
            {
                return this.StepName + " (" + this.StatusName + ")";
            }
        }

        public List<int> UserSteps { get; set; }

        public List<ListItem> dropdownlist
        {
            get
            {
                var item = _context.StepStatusDefinitions.Where(status => status.ApproveStepId == Step).Select(s => new ListItem { Value = s.Id, Text = s.StatusName, IsApproved = s.Approved }).ToList();
                return item;
            }

        }

        public int GetStepOrder(int step)
        {
            return _context.ApproveSteps.FirstOrDefault(a => a.Id == step).ApproveOrder;
        }

        public List<ContractApproveColumns> StepColumns
        {
            get
            {
                var itemStepOrder = GetStepOrder(this.Step);
                var list = ContractApproveStepsColumns.GetStepColumns(itemStepOrder);
                return list;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
            _context.Dispose();
        }
    }
    public class ContractApproveLogic : IDisposable
    {
        private dbContainer _db;
        private ApplicationDbContext _context;
        public ContractApproveLogic()
        {
            _db = new dbContainer();
            _context = new ApplicationDbContext();
        }
        public void Dispose()
        {
            _db.Dispose();
            _context.Dispose();
        }
        public long ChangeContractStatus(ContractRequestViewModel model, bool IsApprove)
        {
            long Id = 0;
            //في حالة الموافقة
            if (IsApprove == true)
            {
                var ApproveSystem = _context.ApproveDefinitions.FirstOrDefault(a => a.TableName == "Contract");
                var ApproveStep = new ApproveStep();
                var ApproveStatus = new StepStatusDefinition();
                using (ContractApproveStepLogic steplogic = new ContractApproveStepLogic())
                {
                    ApproveStep = steplogic.GetNextStep(model.Request.Step);
                    ApproveStatus = steplogic.GetNextStatus(model.Request.Step);
                }
                ContractLogic logic = new ContractLogic();
                Id = logic.EditContract(model, ApproveSystem, ApproveStep, ApproveStatus);
            }
            //في حالة الرفض
            else
            {
                var ApproveSystem = _context.ApproveDefinitions.FirstOrDefault(a => a.TableName == "Contract");
                var ApproveStep = new ApproveStep();
                var ApproveStatus = new StepStatusDefinition();
                using (ContractApproveStepLogic steplogic = new ContractApproveStepLogic())
                {
                    ApproveStep = steplogic.GetCurrentStep(model.Request.Step);
                    ApproveStatus = steplogic.GetCurrentRegectStatus(model.Request.Step);
                }
                ContractLogic logic = new ContractLogic();
                Id = logic.EditContract(model, ApproveSystem, ApproveStep, ApproveStatus);
            }
            return Id;
        }
        public int RegisterContract(ContractRequestViewModel model)
        {
            int MaxContractId = 0;
            try
            {
                try { MaxContractId = _db.Contracts.Max(a => a.Id) + 1; } catch { MaxContractId = 1; }
                Contract contract = new Contract
                {
                    Id = MaxContractId,
                    ProjectId = model.Request.ProjectId,
                    UnitId = model.Request.UnitId,
                    CustomerId = model.Request.CustomerId,
                    ContractDate = model.Request.ContractDate,
                    PaymentMethodHeaderId = model.Request.PaymentMethodHeaderId,
                    UnitTotalValue = model.Request.UnitTotalValue,
                    DocHeaderId = model.Request.DocHeaderId.Value,
                    ContractTypeId = model.Request.ContractTypeId,
                    ContractModelId = model.Request.ContractModelId,
                    RequestId = model.Request.Id
                };
                _db.Contracts.Add(contract);

                int MaxInstallmentId = 0;
                try { MaxInstallmentId = _db.Installments.Max(a => a.Id) + 1; } catch { MaxInstallmentId = 1; }
                foreach (var item in model.InstallmentData)
                {
                    Installment installment = new Installment
                    {
                        Id = MaxInstallmentId++,
                        ContractId = MaxContractId,
                        CustomerId = item.CustomerId,
                        PaymentMethodDetailId = item.PaymentMethodDetailId,
                        Serial = item.Serial,
                        PayDate = item.PayDate,
                        PayValue = item.PayValue,
                        PayNote = item.PayNote,
                        TransactionDate = item.TransactionDate,
                        IsPaid = item.IsPaid,
                        RefId = item.RefId
                    };
                    _db.Installments.Add(installment);
                }

                int MaxDeliverySpecificationId = 0;
                try { MaxDeliverySpecificationId = _db.ContractDeliverySpecifications.Max(a => a.Id) + 1; } catch { MaxDeliverySpecificationId = 1; }
                foreach (var item in model.DeliverySpecificationData)
                {
                    ContractDeliverySpecification deliverySpecification = new ContractDeliverySpecification
                    {
                        Id = MaxDeliverySpecificationId++,
                        ContractId = MaxContractId,
                        DeliverySpecificationString = item.Name
                    };
                    _db.ContractDeliverySpecifications.Add(deliverySpecification);
                }
                _db.SaveChanges();
            }
            catch (Exception e) { return 0; }
            return MaxContractId;
        }
    }

    public class ContractApproveStepLogic : IDisposable
    {
        public dbContainer _db;
        public ApplicationDbContext _context;
        private int UserId { get; set; }
        public IQueryable<ContractRequests> Data { get; set; }
        public List<ContractApproveColumns> StepColumns { get; set; }
        public ContractApproveStepLogic()
        {
            _db = new dbContainer();
            _context = new ApplicationDbContext();
        }
        public ContractApproveStepLogic(int userId)
        {
            UserId = userId;
            _db = new dbContainer();
            _context = new ApplicationDbContext();
        }

        public ApproveStep GetNextStep(int step)
        {
            int currentsteporder = _context.ApproveSteps.FirstOrDefault(a => a.Id == step).ApproveOrder;
            int nextsteporder = ++currentsteporder;
            ApproveStep nextStep = new ApproveStep();
            try { nextStep = _context.ApproveSteps.FirstOrDefault(a => a.ApproveOrder == nextsteporder); } catch { nextStep = null; }
            if (nextStep == null)
                nextStep = _context.ApproveSteps.FirstOrDefault(a => a.Id == step);
            return nextStep;
        }

        public StepStatusDefinition GetNextStatus(int step)
        {
            StepStatusDefinition nextStatus = new StepStatusDefinition();
            var nextStep = GetNextStep(step);
            if (nextStep.Id == step)
                nextStatus = _context.StepStatusDefinitions.FirstOrDefault(a => a.ApproveStepId == nextStep.Id && a.Approved == true);
            else
                nextStatus = _context.StepStatusDefinitions.FirstOrDefault(a => a.ApproveStepId == nextStep.Id && a.Binding == true);
            return nextStatus;
        }

        public ApproveStep GetCurrentStep(int step)
        {
            return _context.ApproveSteps.FirstOrDefault(a => a.Id == step);
        }

        public StepStatusDefinition GetCurrentRegectStatus(int step)
        {
            return _context.StepStatusDefinitions.FirstOrDefault(a => a.ApproveStepId == step && a.Reject == true);
        }
        public bool IsContractApproveUser()
        {
            bool HasSteps = _context.ApproveUsers.Count(a => a.UserId == UserId) > 0;
            return HasSteps;
        }

        public string GetPageHeader()
        {
            return "الموافقة على العقود";
        }

        public List<int> GetUserSteps()
        {
            return _context.ApproveUsers.Where(a => a.UserId == UserId).Select(a => a.ApproveStepId).ToList();
        }

        public int GetStepOrder(int step)
        {
            return _context.ApproveSteps.FirstOrDefault(a => a.Id == step).ApproveOrder;
        }

        private int StepPendingStatus(int step)
        {
            var pendingstatus = _context.StepStatusDefinitions.FirstOrDefault(a => a.ApproveStepId == step && a.Binding == true).Id;
            return pendingstatus;
        }

        public IQueryable<ContractRequests> FilterData()
        {
            var UserSteps = GetUserSteps();
            var Data = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (null, null, 1)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, Remarks = a.Remarks }).Where(a => UserSteps.Contains(a.Step) && a.Status == StepPendingStatus(a.Step)).AsQueryable();
            return Data;
        }

        public List<List<ContractApproveColumns>> GetRowsStepColumns(List<ContractApproveModel> model)
        {
            List<List<ContractApproveColumns>> list = new List<List<ContractApproveColumns>>();
            foreach (var item in model)
            {
                var itemStepOrder = GetStepOrder(item.Step);
                list.Add(ContractApproveStepsColumns.GetStepColumns(itemStepOrder));
            }
            return list;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
    public class ContractApproveStepColumns
    {
    }
}