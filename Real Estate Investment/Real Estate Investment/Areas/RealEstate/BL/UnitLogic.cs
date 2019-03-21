using RealEstateInvestment.Areas.RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public class UnitLogic : IDisposable
    {

        private dbContainer _db;

        public UnitLogic()
        {
            _db = new dbContainer();
        }

        public bool AddUnit(Unit unit)
        {
            try
            {
                var projectUnitType = _db.ProjectUnitsTypes.Find(unit.ProjectUnitTypeId);
                int chinfloor = 1;
                if (unit.MainUnitId != null)
                {
                    var parentUnit = _db.Units.Where(a => a.Id == unit.MainUnitId.Value).FirstOrDefault();
                    var parentUnitType = _db.ProjectUnitsTypes.Where(a => a.Id == parentUnit.ProjectUnitTypeId).FirstOrDefault();
                    chinfloor = parentUnitType.MainUnitSubUnitsNum.Value;
                }
                int MaxId;
                try { MaxId = _db.Units.Max(a => a.Id) + 1; } catch { MaxId = 1; }
                var CharName = string.Empty;
                var NumName = 0;
                var floorNum = 0;
                switch (projectUnitType.NameContain)
                {
                    case 1:
                        NumName = projectUnitType.NumStartFrom.Value;
                        break;
                    case 2:
                        CharName = projectUnitType.CharStartFrom;
                        break;
                    case 3:
                        NumName = projectUnitType.NumStartFrom.Value;
                        CharName = projectUnitType.CharStartFrom;
                        break;
                }
                for (int i = 1; i <= projectUnitType.Count; i++)
                {
                    var Name = string.Empty;
                    switch (projectUnitType.NameIncrementIn)
                    {
                        case 1:
                            Name = NumName.ToString();
                            floorNum = NumName;
                            break;
                        case 2:
                            Name = CharName;
                            floorNum = ExcelColumn.toNumber(CharName);
                            break;
                        case 3:
                            Name = CharName + NumName.ToString();
                            floorNum = NumName;
                            break;
                    }
                    int? floor = 0;
                    if (unit.MainUnitId != null)
                    {
                        floor = (int)Math.Ceiling((decimal)floorNum / chinfloor);
                    }
                    _db.Units.Add(new Unit { Id = MaxId++, ProjectUnitTypeId = unit.ProjectUnitTypeId, UnitName = unit.UnitName + " " + Name, TotalMeters = unit.TotalMeters, TotalPrice = unit.TotalPrice, NetPrice = unit.NetPrice, Description = unit.Description, Garage = unit.Garage, GarageMetes = unit.GarageMetes, GaragePrice = unit.GaragePrice, Perecent = unit.Perecent, MaintenanceDeposit = unit.MaintenanceDeposit, MainUnitId = unit.MainUnitId ?? 0, ProjectId = unit.ProjectId, UnitNo = Name, DocHeaderId = unit.DocHeaderId, FloorNumber = unit.MainUnitId == null ? null : floor, StatusId = unit.StatusId, UnitContractAddress = unit.UnitContractAddress ,MeterPrice=unit.MeterPrice});
                    switch (projectUnitType.NameIncrementIn)
                    {
                        case 1:
                            NumName = NumName + projectUnitType.NameIncrement;
                            break;
                        case 2:
                            var temp = ExcelColumn.toNumber(CharName);
                            CharName = ExcelColumn.toName(temp + projectUnitType.NameIncrement);
                            break;
                        case 3:
                            NumName = ++NumName;
                            temp = ExcelColumn.toNumber(CharName);
                            CharName = ExcelColumn.toName(temp + projectUnitType.NameIncrement);
                            break;
                    }
                    
                }
                _db.SaveChanges();
                return true;
            }
            catch(Exception e){ return false; }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}