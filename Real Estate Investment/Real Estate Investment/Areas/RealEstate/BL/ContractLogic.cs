using RealEstateInvestment.Areas.RealEstate.Models;
using RealEstateInvestment.Areas.RealEstate.Models.DTO;
using RealEstateInvestment.Areas.RealEstate.Models.ReportModels;
using RealEstateInvestment.Areas.RealEstate.Models.Serializer;
using RealEstateInvestment.Areas.RealEstate.Models.ViewModels;
using RealEstateInvestment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Tafqeet;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public class ContractLogic : IDisposable
    {
        private dbContainer _db;
        private ApplicationDbContext _context;
        public ContractLogic()
        {
            _db = new dbContainer();
            _context = new ApplicationDbContext();
        }

        public long AddContract(ContractRequestViewModel contractRequest, ApproveDefinition ApproveSystem, ApproveStep ApproveSystemFirstStep, StepStatusDefinition ApproveSystemFirstStepPendingStatus)
        {
            try
            {
                List<InstallmentDataSerializer> InstallmentData = contractRequest.InstallmentData;
                if (contractRequest.InstallmentData == null)
                {
                    InstallmentData = GetInstallmentData(contractRequest.Request);
                }
                Request Request = new Request();
                try { Request.Id = _context.Requests.Max(a => a.Id) + 1; } catch { Request.Id = 1; }
                Request.UserId = contractRequest.Request.UserId; Request.RequestTypeId = 1; Request.Step = ApproveSystemFirstStep.Id; Request.Status = ApproveSystemFirstStepPendingStatus.Id;
                Request.RequestContent = new JavaScriptSerializer().Serialize(new ContractRequestSerializer { Id = null, ProjectId = contractRequest.Request.ProjectId, UnitId = contractRequest.Request.UnitId, CustomerId = contractRequest.Request.CustomerId, SubCustomerId = null, ContractDate = contractRequest.Request.ContractDate.ToString("MM/dd/yyyy"), PaymentMethodHeaderId = contractRequest.Request.PaymentMethodHeaderId, InstallmentData = new List<InstallmentDataSerializerDTO>(InstallmentData.Select(a => new InstallmentDataSerializerDTO { Id = a.Id, ContractId = a.ContractId, CustomerId = a.CustomerId, PaymentMethodDetailId = a.PaymentMethodDetailId, Serial = a.Serial, PayDate = a.PayDate.ToString("MM/dd/yyyy"), PayValue = a.PayValue, PayNote = a.PayNote, TransactionDate = a.TransactionDate.Value.ToString("MM/dd/yyyy"), IsPaid = a.IsPaid, RefId = a.RefId })), DeliverySpecificationData = contractRequest.DeliverySpecificationData, ContractTypeId = contractRequest.Request.ContractTypeId, ContractModelId = contractRequest.Request.ContractModelId, UnitTotalValue = contractRequest.Request.UnitTotalValue, DocHeaderId = null });
                _context.Requests.Add(Request);
                _context.SaveChanges();
                return Request.Id;
            }
            catch (Exception e) { return 0; }
        }

        public long EditContract(ContractRequestViewModel contractRequest, ApproveDefinition ApproveSystem, ApproveStep ApproveSystemStep, StepStatusDefinition ApproveSystemStatus)
        {
            try
            {
                List<InstallmentDataSerializer> InstallmentData = contractRequest.InstallmentData;
                if (contractRequest.InstallmentData == null)
                {
                    InstallmentData = GetInstallmentData(contractRequest.Request);
                }
                var oldRequest = _context.Requests.Find(contractRequest.Request.Id);
                oldRequest.UserId = contractRequest.Request.UserId; oldRequest.Step = ApproveSystemStep.Id; oldRequest.Status = ApproveSystemStatus.Id;
                oldRequest.RequestContent = new JavaScriptSerializer().Serialize(new ContractRequestSerializer { Id = null, ProjectId = contractRequest.Request.ProjectId, UnitId = contractRequest.Request.UnitId, CustomerId = contractRequest.Request.CustomerId, SubCustomerId = null, ContractDate = contractRequest.Request.ContractDate.ToString("MM/dd/yyyy"), PaymentMethodHeaderId = contractRequest.Request.PaymentMethodHeaderId, InstallmentData = new List<InstallmentDataSerializerDTO>(InstallmentData.Select(a => new InstallmentDataSerializerDTO { Id = a.Id, ContractId = a.ContractId, CustomerId = a.CustomerId, PaymentMethodDetailId = a.PaymentMethodDetailId, Serial = a.Serial, PayDate = a.PayDate.ToString("MM/dd/yyyy"), PayValue = a.PayValue, PayNote = a.PayNote, TransactionDate = a.TransactionDate.Value.ToString("MM/dd/yyyy"), IsPaid = a.IsPaid, RefId = a.RefId })), DeliverySpecificationData = contractRequest.DeliverySpecificationData, ContractTypeId = contractRequest.Request.ContractTypeId, ContractModelId = contractRequest.Request.ContractModelId, UnitTotalValue = contractRequest.Request.UnitTotalValue, DocHeaderId = contractRequest.Request.DocHeaderId }); oldRequest.Remarks = contractRequest.Request.Remarks;
                _context.SaveChanges();
                return oldRequest.Id;
            }
            catch { return 0; }
        }
        public List<InstallmentDataSerializer> GetInstallmentData(ContractRequests request)
        {
            List<InstallmentDataSerializer> serializer = new List<InstallmentDataSerializer>();
            var paymentMethodHeder = _db.PaymentMethodHeaders.Find(request.PaymentMethodHeaderId);
            var paymentMethodDetails = _db.PaymentMethodDetails.Where(a => a.PaymentMethodHeaderId == paymentMethodHeder.Id).ToList();
            int ser = 0;

            decimal TotalBasicInstallment = 0;
            foreach (var d in paymentMethodDetails.Where(a => a.PaymentsCounts == 0))
            {
                if (d.IsRatioNotAmount == true)
                {
                    if (d.Ratio > 1)
                        TotalBasicInstallment += (decimal)(request.UnitTotalValue * (d.Ratio / 100));
                    else
                        TotalBasicInstallment = (decimal)(request.UnitTotalValue * d.Ratio);
                }
                else
                    TotalBasicInstallment = d.MinimumAmount.Value;
            }

            var installmentPayValue = (request.UnitTotalValue - TotalBasicInstallment)/ paymentMethodDetails.Where(a => a.PaymentsCounts>0).Select(a=>a.PaymentsCounts).FirstOrDefault();

            foreach (var detail in paymentMethodDetails)
            {
                var PayName = _db.PaymentTypes.FirstOrDefault(a => a.Id == detail.PaymentTypeId).Name;
                decimal PValue;
                if (detail.IsRatioNotAmount == true)
                {
                    if (detail.Ratio > 1)
                        PValue = (decimal)(request.UnitTotalValue * (detail.Ratio / 100));
                    else
                        PValue = (decimal)(request.UnitTotalValue * detail.Ratio);
                }
                else
                    PValue = detail.MinimumAmount.Value;

                if (detail.PaymentsCounts > 0)
                {
                    int startFrom = detail.StartFrom;
                    for (int i = 0; i < detail.PaymentsCounts; i++)
                    {
                        serializer.Add(new InstallmentDataSerializer
                        {
                            Id = null,
                            ContractId = null,
                            CustomerId = request.CustomerId,
                            PaymentMethodDetailId = detail.Id,
                            Serial = ++ser,
                            payName = PayName,
                            PayDate = request.ContractDate.AddMonths(startFrom),
                            PayValue = installmentPayValue,
                            PayNote = null,
                            TransactionDate = DateTime.Now,
                            IsPaid = false,
                            RefId = null,
                            PayCount = detail.PaymentsCounts,
                        });
                        startFrom = startFrom + detail.Period;
                    }
                }
                else
                {
                    serializer.Add(new InstallmentDataSerializer
                    {
                        Id = null,
                        ContractId = null,
                        CustomerId = request.CustomerId,
                        PaymentMethodDetailId = detail.Id,
                        Serial = ++ser,
                        payName = PayName,
                        PayDate = request.ContractDate.AddMonths(detail.StartFrom),
                        PayValue = PValue,
                        PayNote = null,
                        TransactionDate = DateTime.Now,
                        IsPaid = false,
                        RefId = null,
                        PayCount = detail.PaymentsCounts,
                    });
                }
            }
            return serializer;
        }

        public ContractWriteViewModel SetAllContractData(ContractWriteViewModel model)
        {
            //get basic contract data
            model.ContractRequest = new ContractRequestViewModel();
            model.ContractRequest.Request = _db.Database.SqlQuery<ufn_GetRequestsResultModel>("SELECT * FROM [con].[ufn_GetRequests] (" + model.Id + ", null, null)").Select(a => new ContractRequests { Id = a.Id, UserId = a.UserId, UserName = a.UserName, RequestTypeId = a.RequestTypeId, RequestTypeName = a.RequestTypeName, Step = a.Step, StepName = a.StepName, Status = a.Status, StatusName = a.StatusName, ProjectId = a.ProjectId, ProjectName = a.ProjectName, MainUnitId = a.MainUnitId, MainUnitName = a.MainUnitName, UnitId = a.UnitId, UnitName = a.UnitName, CustomerId = a.CustomerId, CustomerName = a.CustomerName, ContractDate = a.ContractDate, PaymentMethodHeaderId = a.PaymentMethodHeaderId, PaymentMethodHeaderName = a.PaymentMethodHeaderName, ContractTypeId = a.ContractTypeId, ContractTypeName = a.ContractTypeName, ContractModelId = a.ContractModelId, ContractModelName = a.ContractModelName, UnitTotalValue = a.UnitTotalValue, DocHeaderId = a.DocHeaderId, DocHeaderName = a.DocHeaderName, ContractId = a.ContractId }).FirstOrDefault();
            model.ContractRequest.InstallmentData = _db.Database.SqlQuery<InstallmentDataSerializer>("SELECT * FROM [con].[ufn_GetRequestInstallmentData] (" + model.Id + ")").ToList();
            model.ContractRequest.DeliverySpecificationData = _db.Database.SqlQuery<DeliverySpecificationSerializer>("SELECT * FROM[con].[ufn_GetRequestDeliverySpecificationData](" + model.Id + ")").ToList();
            model.project = _db.Projects.Find(model.ContractRequest.Request.ProjectId);
            _db.Entry(model.project).Reference(s => s.City).Load();
            model.unit = _db.Units.Find(model.ContractRequest.Request.UnitId);
            model.customer = _db.Customers.Find(model.ContractRequest.Request.CustomerId);
            _db.Entry(model.customer).Reference(s => s.Nationality).Load(); _db.Entry(model.customer).Reference(s => s.TypeId).Load();
            model.projectOwner = _db.ProjectOwners.FirstOrDefault(a => a.ProjectId == model.ContractRequest.Request.ProjectId);
            _db.Entry(model.projectOwner).Reference(s => s.ProjectMainOwnerObj).Load(); _db.Entry(model.projectOwner).Reference(s => s.ProjectOwnerObj).Load();

            //setup all contract variables
            model.Variables = GetContractsVariablesList(model.Id, model);

            //في حالة لو حصل تغيير على contractItems هيكون هنا
            model.ContractItemsTranslated = _db.ContractItems.Where(a => a.ContractModelId == model.ContractRequest.Request.ContractModelId).ToList();
            model.ContractItemsTranslated = TranslateContractItems(model);
            return model;
        }

        private static string Tafqet(double num, string type, string concateString)
        {
            tafqet ts = new tafqet();
            string result = string.Empty;
            switch (type)
            {
                case "مبلغ":
                    result = ts.NoToTxt(num, "جنيه", "قرش");
                    break;
                case "نسبة":
                case "عدد":
                    int wholeNumber = (int)num;
                    double decimalPortion = num - wholeNumber;
                    if (decimalPortion == 0)
                    {
                        result = ts.NoToTxt(num, "", "");
                    }
                    else
                    {
                        result = ts.NoToTxt(num, "فاصلة", "");
                        int idx = result.LastIndexOf('و');
                        if (idx != -1) { result = String.Join("", result.Substring(0, idx), result.Substring(idx + 1)); }
                        if (wholeNumber == 0)
                        {
                            result = result.Insert(3, " صفر فاصلة");
                            var resultString = Regex.Match(result, @"\d+").Value;
                            var ConvertedNum = ts.NoToTxt(double.Parse(resultString), "", "");
                            ConvertedNum = ConvertedNum.Replace("فقط", "");
                            result = result.Replace(resultString, ConvertedNum);
                        }
                        else
                        {
                            var resultString = Regex.Match(result, @"\d+").Value;
                            var ConvertedNum = ts.NoToTxt(double.Parse(resultString), "", "");
                            ConvertedNum = ConvertedNum.Replace("فقط", "");
                            result = result.Replace(resultString, ConvertedNum);
                        }
                    }
                    break;
            }
            return result + " " + concateString;
        }

        private List<ContractItem> TranslateContractItems(ContractWriteViewModel model)
        {
            var TranslateContractItem = new List<ContractItem>();
            foreach (var item in model.ContractItemsTranslated)
            {
                foreach (var variable in model.Variables)
                {
                    item.ContractItemString = item.ContractItemString.SafeReplace(variable.VarName, variable.VarValue, true);
                }
                TranslateContractItem.Add(item);
            }
            return TranslateContractItem;
        }

        public List<ContractSys> GetContractsVariablesList(int? RequestId, ContractWriteViewModel model)
        {
            List<ContractSys> AllVariables = new List<ContractSys>();
            List<ContractSys> BasicVariables = new List<ContractSys>();
            List<ContractSys> TafqetVariables = new List<ContractSys>();
            AllVariables.AddRange(model.Variables);
            //generate tafqet list
            int maxid;
            try { maxid = model.Variables.Max(a => a.VarId) + 1; } catch { maxid = 1; }
            foreach (var variable in model.Variables)
            {
                if (variable.IsTafqet == true)
                {
                    var result = "";
                    if (variable.IsMoney)
                        result = Tafqet(Convert.ToDouble(variable.VarValue), "مبلغ", "");
                    else
                    {
                        switch (variable.VarType)
                        {
                            case "int":
                                result = Tafqet(Convert.ToDouble(variable.VarValue), "عدد", "");
                                break;
                            case "decimal":
                                result = Tafqet(Convert.ToDouble(variable.VarValue), "نسبة", "في المئة");
                                break;
                        }
                    }

                    TafqetVariables.Add(new ContractSys
                    {
                        VarId = maxid,
                        VarName = "@@" + variable.VarId,
                        VarDescription = variable.VarDescription + " مفقط",
                        VarType = "string",
                        VarValue = result
                    });
                }
                maxid++;
            }
            AllVariables.AddRange(TafqetVariables);
            //basic variables list
            if (RequestId == null)
            {
                //gust genrate list without values --->names needed
                BasicVariables = new List<ContractSys>()
                {
                     new ContractSys{VarId=101,VarName="@101",VarDescription="اسم المشروع",VarType="string",VarValue=""},
                     new ContractSys{VarId=102,VarName="@102",VarDescription="مكان المشروع",VarType="string",VarValue=""},
                     new ContractSys{VarId=103,VarName="@103",VarDescription="اسم الوحدة",VarType="string",VarValue=""},
                     new ContractSys{VarId=104,VarName="@104",VarDescription="الوحدة الرئيسية",VarType="string",VarValue=""},
                     new ContractSys{VarId=105,VarName="@105",VarDescription="مساحة الوحدة",VarType="string",VarValue=""},
                     new ContractSys{VarId=106,VarName="@106",VarDescription="مساحة الوحدة مفقطة",VarType="string",VarValue=""},
                     new ContractSys{VarId=107,VarName="@107",VarDescription="اجمالي سعر الوحدة",VarType="string",VarValue=""},
                     new ContractSys{VarId=108,VarName="@108",VarDescription="اجمالي سعر الوحدة مفقط",VarType="string",VarValue=""},
                };
            }
            else
            {
                //genrate List with Values
                BasicVariables = new List<ContractSys>()
                {
                     new ContractSys{VarId=101,VarName="@101",VarDescription="اسم المشروع",VarType="string",VarValue=model.project.ProjectName},
                     new ContractSys{VarId=102,VarName="@102",VarDescription="مكان المشروع",VarType="string",VarValue=model.project.Location},
                     new ContractSys{VarId=103,VarName="@103",VarDescription="اسم الوحدة",VarType="string",VarValue=model.unit.UnitName},
                     new ContractSys{VarId=104,VarName="@104",VarDescription="الوحدة الرئيسية",VarType="string",VarValue=model.ContractRequest.Request.MainUnitName},
                     new ContractSys{VarId=105,VarName="@105",VarDescription="مساحة الوحدة",VarType="string",VarValue=model.unit.TotalMeters.ToString()},
                     new ContractSys{VarId=106,VarName="@106",VarDescription="مساحة الوحدة مفقطة",VarType="string",VarValue=Tafqet(Convert.ToDouble(model.unit.TotalMeters),"عدد","متر")},
                     new ContractSys{VarId=107,VarName="@107",VarDescription="اجمالي سعر الوحدة",VarType="string",VarValue=model.ContractRequest.Request.UnitTotalValue.ToString()},
                     new ContractSys{VarId=108,VarName="@108",VarDescription="اجمالي سعر الوحدة مفقط",VarType="string",VarValue=Tafqet(Convert.ToDouble(model.ContractRequest.Request.UnitTotalValue),"مبلغ","")},
                };
            }
            AllVariables.AddRange(BasicVariables);
            return AllVariables;
        }

        private List<InstallmentDataSerializer> GetInstallmentDataWithNames(List<InstallmentDataSerializer> InstallmentData)
        {
            foreach (var item in InstallmentData)
            {
                var paymentTypeId = _db.PaymentMethodDetails.FirstOrDefault(a => a.Id == item.PaymentMethodDetailId).PaymentTypeId;
                var paymentTypeName = _db.PaymentTypes.FirstOrDefault(a => a.Id == paymentTypeId).Name;
                item.payName = paymentTypeName;
            }
            return InstallmentData;
        }

        public ContractRpt SetupContract(ContractWriteViewModel model)
        {
            ContractRpt rpt = new ContractRpt();
            var EngDay = model.ContractRequest.Request.ContractDate.DayOfWeek.ToString();
            string ArDay = string.Empty;
            switch (EngDay)
            {
                case "Friday":
                    ArDay = "الجمعة";
                    break;
                case "Saturday":
                    ArDay = "السبت";
                    break;
                case "Sunday":
                    ArDay = "الأحد";
                    break;
                case "Monday":
                    ArDay = "الاثنين";
                    break;
                case "Tuesday":
                    ArDay = "الثلاثاء";
                    break;
                case "Wednesday":
                    ArDay = "الأربعاء";
                    break;
                case "Thursday":
                    ArDay = "الخميس";
                    break;
            }
            rpt.RptContractRequest = new RptContractRequest
            {
                Id = model.ContractRequest.Request.Id.ToString(),
                ProjectId = model.ContractRequest.Request.ProjectId.ToString(),
                ProjectName = model.ContractRequest.Request.ProjectName,
                UnitId = model.ContractRequest.Request.UnitId.ToString(),
                UnitName = model.ContractRequest.Request.UnitName,
                MainUnitId = model.ContractRequest.Request.MainUnitId.ToString(),
                MainUnitName = model.ContractRequest.Request.MainUnitName,
                CustomerId = model.ContractRequest.Request.CustomerId.ToString(),
                CustomerName = model.ContractRequest.Request.CustomerName,
                ContractDate = model.ContractRequest.Request.ContractDate.ToString("dd/MM/yyyy"),
                ContractDay = ArDay,
                PaymentMethodHeaderId = model.ContractRequest.Request.PaymentMethodHeaderId.ToString(),
                PaymentMethodHeaderName = model.ContractRequest.Request.PaymentMethodHeaderName,
                UnitTotalValue = model.ContractRequest.Request.UnitTotalValue.ToString(),
                ContractTypeId = model.ContractRequest.Request.ContractTypeId.ToString(),
                ContractTypeName = model.ContractRequest.Request.ContractTypeName,
                ContractModelId = model.ContractRequest.Request.ContractModelId.ToString(),
                ContractModelName = model.ContractRequest.Request.ContractModelName
            };
            model.ContractRequest.InstallmentData = GetInstallmentDataWithNames(model.ContractRequest.InstallmentData);
            rpt.RptInstallmentData = model.ContractRequest.InstallmentData.Select(a => new RptInstallmentData
            {
                Serial = a.Serial.ToString(),
                PayDate = a.PayDate.ToString("dd/MM/yyyy"),
                PayValue = a.PayValue.ToString(),
                payName = a.payName
            }).ToList();
            rpt.RptDeliverySpecification = model.ContractRequest.DeliverySpecificationData.Select(a => new RptDeliverySpecification
            {
                Id = a.Id.ToString(),
                Name = a.Name.ToString()
            }).ToList();
            rpt.RptProject = new RptProject
            {
                Id = model.project.Id.ToString(),
                ProjectName = model.project.ProjectName,
                Location = model.project.Location,
                ProjectDescription = model.project.ProjectDescription,
                ProjectContentDetails = model.project.ProjectContentDetails,
                CityName = model.project.City.CityName
            };
            var ProjectUnitType = _db.ProjectUnitsTypes.FirstOrDefault(a => a.Id == model.unit.ProjectUnitTypeId).UnitTypeId;
            var UnitTypeName = _db.UnitTypes.FirstOrDefault(a => a.Id == ProjectUnitType).UnitTypeName;
            rpt.RptUnit = new RptUnit
            {
                Id = model.unit.Id.ToString(),
                UnitName = model.unit.UnitName,
                UnitNo = model.unit.UnitNo,
                FloorNumber = model.unit.FloorNumber.ToString(),
                UnitContractAddress = model.unit.UnitContractAddress,
                UnitTypeName = UnitTypeName
            };
            rpt.RptCustomer = new RptCustomer
            {
                Id = model.customer.Id.ToString(),
                NameArab = model.customer.NameArab,
                NameEng = model.customer.NameEng,
                IdNumber = model.customer.IdNumber,
                IDTypeName = model.customer.TypeId.IdName,
                NationalityName = model.customer.Nationality.NationalityName,
                Address = model.customer.Address
            };
            rpt.RptProjectOwner = new RptProjectOwner
            {
                MainOwnerId = model.projectOwner.MainOwnerId.ToString(),
                MainOwnerName = model.projectOwner.ProjectMainOwnerObj.Name,
                MainOwnerAddress = model.projectOwner.ProjectMainOwnerObj.Address,
                ProjectOwnerId = model.projectOwner.ProjectOwnerId.ToString(),
                ProjectOwnerName = model.projectOwner.ProjectOwnerObj.Name,
                ProjectOwnerAddress = model.projectOwner.ProjectOwnerObj.Address,
                ProjectOwnerDelegateName = model.projectOwner.ProjectOwnerDelegateName,
                ProjectOwnerDelegateRepresent = model.projectOwner.ProjectOwnerDelegateRepresent,
                ProjectOwnerDetails = model.projectOwner.ProjectOwnerDetails
            };
            if (rpt.RptProjectOwner.MainOwnerId == rpt.RptProjectOwner.ProjectOwnerId)
            {
                rpt.RptProjectOwner.MainOwnerName = "";
            }
            else
            {
                rpt.RptProjectOwner.MainOwnerName = "من " + rpt.RptProjectOwner.MainOwnerName;
            }
            rpt.RptContractItem = model.ContractItemsTranslated.Select(a => new RptContractItem
            {
                Id = a.Id.ToString(),
                ContractItemName = a.ContractItemName,
                ContractItemString = a.ContractItemString
            }).ToList();
            return rpt;
        }
        public void Dispose()
        {
            _db.Dispose();
            _context.Dispose();
        }
    }
}