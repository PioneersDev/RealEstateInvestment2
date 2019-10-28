using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using RealEstateInvestment.Areas.RealEstate.BL;
using RealEstateInvestment.Areas.RealEstate.Models.ViewModels;

namespace RealEstateInvestment.Areas.RealEstate.Controllers
{
    public class CustomerQaed
    {
        public AccountOperationResult CustomerAccountOperation(AccountOperationParams model)
        {
            string connectionString = HandelConnectionStrings.GetConnectionString(model.CompanyName);
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("AccountOperation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (model.Operation == "Insert")
            {
                cmd.Parameters.AddWithValue("@ACCOUNTID", DBNull.Value);
                cmd.Parameters.AddWithValue("@ACCOUNTNAMEA", model.CustomerNameA);
                cmd.Parameters.AddWithValue("@ACCOUNTNAMEE", model.CustomerNameE);
                cmd.Parameters.AddWithValue("@MAINACCOUNTID", DBNull.Value);
                cmd.Parameters.AddWithValue("@MAINACCOUNT", false);
                cmd.Parameters.AddWithValue("@ACCOUNTNATURE", 1);
                cmd.Parameters.AddWithValue("@ACCOUNTTYPEID", 1);
                cmd.Parameters.AddWithValue("@ACCOUNTLEVEL", 2);
                cmd.Parameters.AddWithValue("@LEDGERID", 0);
                cmd.Parameters.AddWithValue("@BRANCHID", 0);
                cmd.Parameters.AddWithValue("@foroqomla", 0);
                cmd.Parameters.AddWithValue("@currid", 1);
                cmd.Parameters.AddWithValue("@USERNAME", model.UserName);
                cmd.Parameters.AddWithValue("@MACHINEIP", model.MachineIp);
                cmd.Parameters.AddWithValue("@MACHINENAME", model.MachineName);
                cmd.Parameters.AddWithValue("@LOGINUSER", model.LoginUser);
                cmd.Parameters.AddWithValue("@COMPANYNAME", model.CompanyName);
                cmd.Parameters.AddWithValue("@ACTIONTYPE", "Insert");
            }
            else if (model.Operation == "Update")
            {
                cmd.Parameters.AddWithValue("@ACCOUNTID", model.CustomerAccount.Value);
                cmd.Parameters.AddWithValue("@ACCOUNTNAMEA", model.CustomerNameA);
                cmd.Parameters.AddWithValue("@ACCOUNTNAMEE", model.CustomerNameE);
                cmd.Parameters.AddWithValue("@MAINACCOUNTID", DBNull.Value);
                cmd.Parameters.AddWithValue("@MAINACCOUNT", DBNull.Value);
                cmd.Parameters.AddWithValue("@ACCOUNTNATURE", DBNull.Value);
                cmd.Parameters.AddWithValue("@ACCOUNTTYPEID", DBNull.Value);
                cmd.Parameters.AddWithValue("@ACCOUNTLEVEL", DBNull.Value);
                cmd.Parameters.AddWithValue("@LEDGERID", DBNull.Value);
                cmd.Parameters.AddWithValue("@BRANCHID", DBNull.Value);
                cmd.Parameters.AddWithValue("@foroqomla", DBNull.Value);
                cmd.Parameters.AddWithValue("@currid", DBNull.Value);
                cmd.Parameters.AddWithValue("@USERNAME", model.UserName);
                cmd.Parameters.AddWithValue("@MACHINEIP", model.MachineIp);
                cmd.Parameters.AddWithValue("@MACHINENAME", model.MachineName);
                cmd.Parameters.AddWithValue("@LOGINUSER", model.LoginUser);
                cmd.Parameters.AddWithValue("@COMPANYNAME", model.CompanyName);
                cmd.Parameters.AddWithValue("@ACTIONTYPE", "Update");
            }
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            connection.Close();
            da.Dispose();
            return dataTable.ToCollection<AccountOperationResult>().FirstOrDefault();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CreateJournalEntries")]
        public CreateJournalEntriesResult CreateJournalEntries(CreateJournalEntriesParams model)
        {

            string connectionString = HandelConnectionStrings.GetConnectionString(model.CompanyName);
            DataTable dataTable = new DataTable();
            SqlParameter dtype = new SqlParameter("DAILYJOURNALTYPE", model.dETAIL_TYPEs.ListToDataTable());
            dtype.SqlDbType = SqlDbType.Structured; dtype.TypeName = "DETAIL_TYPE";
            SqlParameter itype = new SqlParameter("MULTIPLECHEQUE", model.mULTIPLECHEQUE_TYPEs.ListToDataTable());
            itype.SqlDbType = SqlDbType.Structured; itype.TypeName = "MULTIPLECHEQUE_TYPE";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("CreateJournalEntries", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);
            cmd.Parameters.AddWithValue("@ContractId", model.ContractId);
            cmd.Parameters.AddWithValue("@BRANCHID", model.BRANCHID);
            cmd.Parameters.AddWithValue("@TICKETDATE", model.TICKETDATE);
            cmd.Parameters.AddWithValue("@REMARKSA", model.REMARKSA);
            cmd.Parameters.AddWithValue("@REMARKSE", model.REMARKSE);
            cmd.Parameters.AddWithValue("@userdesc", model.userdesc);
            cmd.Parameters.AddWithValue("@isallokupdate", model.isallokupdate);

            cmd.Parameters.Add(dtype);
            cmd.Parameters.Add(itype);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            connection.Close();
            da.Dispose();
            return dataTable.ToCollection<CreateJournalEntriesResult>().FirstOrDefault();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PayRealEstateInstallment")]
        public CreateJournalEntriesResult PayRealEstateInstallment(PayRealEstateInstallmentParams model)
        {
            string connectionString = HandelConnectionStrings.GetConnectionString(model.CompanyName);
            DataTable dataTable = new DataTable();
            SqlParameter itype = new SqlParameter("MULTIPLECHEQUE", model.mULTIPLECHEQUE_TYPE.ListToDataTable());
            itype.SqlDbType = SqlDbType.Structured; itype.TypeName = "MULTIPLECHEQUE_TYPE";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("PayRealEstateInstallment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);
            cmd.Parameters.AddWithValue("@InstallmentId", model.InstallmentId);
            cmd.Parameters.AddWithValue("@TicketId", model.TicketId);
            cmd.Parameters.Add(itype);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            connection.Close();
            da.Dispose();
            return dataTable.ToCollection<CreateJournalEntriesResult>().FirstOrDefault();
        }

    }
}