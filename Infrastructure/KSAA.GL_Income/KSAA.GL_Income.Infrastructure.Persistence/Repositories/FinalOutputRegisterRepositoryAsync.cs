using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Persistence.Repositories
{
    public class FinalOutputRegisterRepositoryAsync : IFinalOutputRegisterRepositoryAsync
    {
        private readonly ApplicationDBContext _context;
        public FinalOutputRegisterRepositoryAsync(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<FinalOutputRegisterListModel> GetFinalOutputRegisterAsync(string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());
                var model = new FinalOutputRegisterListModel();
                model.finalOutputRegistersList = new List<FinalOutputRegisterViewModel>();
                SqlCommand cmd = new SqlCommand("Prc_Get_Final_Output_Register_KSAA_Template", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@month", month));
                cmd.Parameters.Add(new SqlParameter("@year", year));
                cmd.Parameters.Add(new SqlParameter("@FnType", "gridbind"));
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                dataTable = ds.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var data = new FinalOutputRegisterViewModel();
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.Document_Type = (string)dataTable.Rows[i]["Document_Type"];
                        data.Invoice_Number = dataTable.Rows[i]["Invoice_Number"].ToString() ?? string.Empty; ;
                        data.Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Invoice_No = dataTable.Rows[i]["E_Invoice_No"].ToString() ?? string.Empty; ;
                        data.E_Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Invoice_Total_Amount = dataTable.Rows[i]["E_Invoice_Total_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Total_Amount"];
                        data.E_Invoice_Tax_Amount = dataTable.Rows[i]["E_Invoice_Tax_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Tax_Amount"];
                        data.E_Invoice_Amount_Different = dataTable.Rows[i]["E_Invoice_Amount_Different"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Amount_Different"];
                        data.E_Invoice_Tax_Different = (decimal)dataTable.Rows[i]["E_Invoice_Tax_Different"];
                        data.Shipping_Bill_No = dataTable.Rows[i]["Shipping_Bill_No"].ToString() ?? string.Empty; ;
                        data.Shipping_Bill_Date = Convert.ToDateTime(dataTable.Rows[i]["Shipping_Bill_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Shipping_Bill_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.HSN_Code = (string)dataTable.Rows[i]["HSN_Code"];
                        data.Quantity = dataTable.Rows[i]["Quantity"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Quantity"];
                        data.Unique_Quantity_Code = (string)dataTable.Rows[i]["Unique_Quantity_Code"];
                        data.Description = (string)dataTable.Rows[i]["Description"];
                        data.Party_Name = (string)dataTable.Rows[i]["Party_Name"];
                        data.GSTIN = (string)dataTable.Rows[i]["GSTIN"];
                        data.Reverse_Charge = (string)dataTable.Rows[i]["Reverse_Charge"];
                        data.Place_Of_Supply_State_Name = (string)dataTable.Rows[i]["Place_Of_Supply_State_Name"];
                        data.Exchange_Rate_As_Per_Notifications = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Notifications"];
                        data.Exchange_Rate_As_Per_Shipping_Bill = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Shipping_Bill"];
                        data.Taxable_Value = dataTable.Rows[i]["Taxable_Value"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Taxable_Value"];
                        data.Rate = dataTable.Rows[i]["Rate"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Rate"];
                        data.Total_Tax = dataTable.Rows[i]["Total_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Total_Tax"];
                        data.Central_Tax = dataTable.Rows[i]["Central_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Central_Tax"];
                        data.State_UT_Tax = dataTable.Rows[i]["State_UT_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["State_UT_Tax"];
                        data.Integrated_Tax = dataTable.Rows[i]["Integrated_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Integrated_Tax"];
                        data.Cess_Amount = dataTable.Rows[i]["Cess_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Cess_Amount"];
                        data.Total_Invoice_Value_Rs = dataTable.Rows[i]["Total_Invoice_Value_Rs"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Total_Invoice_Value_Rs"];
                        data.Vehicle_No = (string)dataTable.Rows[i]["Vehicle_No"];
                        data.E_Way_Bill_No = (string)dataTable.Rows[i]["E_Way_Bill_No"];
                        data.Dispatch_Location_Code = (string)dataTable.Rows[i]["Dispatch_Location_Code"];
                        data.Port_Code = (string)dataTable.Rows[i]["Port_Code"];
                        data.Voucher_No = (string)dataTable.Rows[i]["Voucher_No"];
                        data.Accounting_Date = Convert.ToDateTime(dataTable.Rows[i]["Accounting_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Accounting_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Location_Code = (string)dataTable.Rows[i]["Location_Code"];
                        data.GL_Code = (string)dataTable.Rows[i]["GL_Code"];
                        data.E_Invoice_No_2 = (string)dataTable.Rows[i]["E_Invoice_No_2"];
                        data.E_Invoice_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date_2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Invoice_Date_2"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Way_Bill_No_2 = (string)dataTable.Rows[i]["E_Way_Bill_No_2"];
                        data.E_Way_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Way_Date_2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Way_Date_2"]).ToString(DateTimeFormat.StandardDateTime);
                        data.TypeOfSupplySL = (string)dataTable.Rows[i]["TypeOfSupplySL"];
                        data.GSTPaymentTypeSL = (string)dataTable.Rows[i]["GSTPaymentTypeSL"];

                        model.finalOutputRegistersList.Add(data);
                    }
                }
                con.Close();

                return model;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<FinalOutputRegisterListModel> GenFinalOutputRegister(string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                FinalOutputRegisterListModel data = new FinalOutputRegisterListModel();

                SqlCommand cmd = new SqlCommand("prc_Generate_Final_Output_Register_KSAA_Template", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", month));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                }
                con.Close();
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FinalOutputRegisterListModel> ExportFinalOutputRegisterAsync(string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());
                var model = new FinalOutputRegisterListModel();
                model.finalOutputRegistersList = new List<FinalOutputRegisterViewModel>();
                SqlCommand cmd = new SqlCommand("Prc_Get_Final_Output_Register_KSAA_Template", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@month", month));
                cmd.Parameters.Add(new SqlParameter("@year", year));
                cmd.Parameters.Add(new SqlParameter("@FnType", "download"));
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                dataTable = ds.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var data = new FinalOutputRegisterViewModel();
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.Document_Type = (string)dataTable.Rows[i]["Document_Type"];
                        data.Invoice_Number = dataTable.Rows[i]["Invoice_Number"].ToString() ?? string.Empty; ;
                        data.Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Invoice_No = dataTable.Rows[i]["E_Invoice_No"].ToString() ?? string.Empty; ;
                        data.E_Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Invoice_Total_Amount = dataTable.Rows[i]["E_Invoice_Total_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Total_Amount"];
                        data.E_Invoice_Tax_Amount = dataTable.Rows[i]["E_Invoice_Tax_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Tax_Amount"];
                        data.E_Invoice_Amount_Different = dataTable.Rows[i]["E_Invoice_Amount_Different"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Amount_Different"];
                        data.E_Invoice_Tax_Different = (decimal)dataTable.Rows[i]["E_Invoice_Tax_Different"];
                        data.Shipping_Bill_No = dataTable.Rows[i]["Shipping_Bill_No"].ToString() ?? string.Empty; ;
                        data.Shipping_Bill_Date = Convert.ToDateTime(dataTable.Rows[i]["Shipping_Bill_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Shipping_Bill_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.HSN_Code = (string)dataTable.Rows[i]["HSN_Code"];
                        data.Quantity = dataTable.Rows[i]["Quantity"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Quantity"];
                        data.Unique_Quantity_Code = (string)dataTable.Rows[i]["Unique_Quantity_Code"];
                        data.Description = (string)dataTable.Rows[i]["Description"];
                        data.Party_Name = (string)dataTable.Rows[i]["Party_Name"];
                        data.GSTIN = (string)dataTable.Rows[i]["GSTIN"];
                        data.Reverse_Charge = (string)dataTable.Rows[i]["Reverse_Charge"];
                        data.Place_Of_Supply_State_Name = (string)dataTable.Rows[i]["Place_Of_Supply_State_Name"];
                        data.Exchange_Rate_As_Per_Notifications = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Notifications"];
                        data.Exchange_Rate_As_Per_Shipping_Bill = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Shipping_Bill"];
                        data.Taxable_Value = dataTable.Rows[i]["Taxable_Value"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Taxable_Value"];
                        data.Rate = dataTable.Rows[i]["Rate"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Rate"];
                        data.Total_Tax = dataTable.Rows[i]["Total_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Total_Tax"];
                        data.Central_Tax = dataTable.Rows[i]["Central_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Central_Tax"];
                        data.State_UT_Tax = dataTable.Rows[i]["State_UT_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["State_UT_Tax"];
                        data.Integrated_Tax = dataTable.Rows[i]["Integrated_Tax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Integrated_Tax"];
                        data.Cess_Amount = dataTable.Rows[i]["Cess_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Cess_Amount"];
                        data.Total_Invoice_Value_Rs = dataTable.Rows[i]["Total_Invoice_Value_Rs"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Total_Invoice_Value_Rs"];
                        data.Vehicle_No = (string)dataTable.Rows[i]["Vehicle_No"];
                        data.E_Way_Bill_No = (string)dataTable.Rows[i]["E_Way_Bill_No"];
                        data.Dispatch_Location_Code = (string)dataTable.Rows[i]["Dispatch_Location_Code"];
                        data.Port_Code = (string)dataTable.Rows[i]["Port_Code"];
                        data.Voucher_No = (string)dataTable.Rows[i]["Voucher_No"];
                        data.Accounting_Date = Convert.ToDateTime(dataTable.Rows[i]["Accounting_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Accounting_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Location_Code = (string)dataTable.Rows[i]["Location_Code"];
                        data.GL_Code = (string)dataTable.Rows[i]["GL_Code"];
                        data.E_Invoice_No_2 = (string)dataTable.Rows[i]["E_Invoice_No_2"];
                        data.E_Invoice_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date_2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Invoice_Date_2"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Way_Bill_No_2 = (string)dataTable.Rows[i]["E_Way_Bill_No_2"];
                        data.E_Way_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Way_Date_2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Way_Date_2"]).ToString(DateTimeFormat.StandardDateTime);
                        //data.TypeOfSupplySL = (string)dataTable.Rows[i]["TypeOfSupplySL"];
                        //data.GSTPaymentTypeSL = (string)dataTable.Rows[i]["GSTPaymentTypeSL"];

                        model.finalOutputRegistersList.Add(data);
                    }
                }
                con.Close();

                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}