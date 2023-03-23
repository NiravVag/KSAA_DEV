using Antlr.Runtime.Misc;
using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.OutputLiability;
using KSAA.GL_Income.Application.DTOs.OutputSupply;
using KSAA.GL_Income.Application.Features.OutputLiability.Commands;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Persistence.Repositories
{
    public class OutputLiabilityRepositoryAsync : IOutputLiabilityRepositoryAsync
    {
        private readonly ApplicationDBContext _context;

        public OutputLiabilityRepositoryAsync(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<OutputLiabilityListModel> GenLiabilityControlSheetAsync(string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

            OutputLiabilityListModel data = new OutputLiabilityListModel();

            SqlCommand cmd = new SqlCommand("prc_Generate_Output_Liability_Control_Sheet", con)
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
            return data;
        }

        //New Logic
        public async Task<OutputLiabilityListModel> GetGLIncomeControlSheetAsync(string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

            var model = new OutputLiabilityListModel();
            model.GL_IncomeData = new List<GL_IncomeData>();
            model.SupplyModels = new List<SupplyModel>();
            model.outputRegisterModels = new List<OutputRegisterListModel>();

            SqlCommand cmd = new SqlCommand("prc_GL_Liability_Ledger_Register", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Month", month));
            cmd.Parameters.Add(new SqlParameter("@Year", year));

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adapter.Fill(ds);

            dataTable = ds.Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                GL_IncomeData gLIncomeData = new GL_IncomeData();
                gLIncomeData.Income_Booking_Resp_GL_ID = i + 1;
                gLIncomeData.GL_Code = dataTable.Rows[i]["GL_Code"].ToString() ?? string.Empty;
                gLIncomeData.GL_Description = dataTable.Rows[i]["GL_Description"].ToString() ?? string.Empty;
                gLIncomeData.CGSTLL = (decimal)dataTable.Rows[i]["CGSTLL"];
                gLIncomeData.SGSTLL = (decimal)dataTable.Rows[i]["SGSTLL"];
                gLIncomeData.IGSTLL = (decimal)dataTable.Rows[i]["IGSTLL"];
                gLIncomeData.CessLL = (decimal)dataTable.Rows[i]["CessLL"];

                model.GL_IncomeData.Add(gLIncomeData);
            }

            dataTable = ds.Tables[1];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                model.Sum_CentralTaxSL = dataTable.Rows[i]["CentralTaxSL"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["CentralTaxSL"];
                model.Sum_StateUTTaxSL = dataTable.Rows[i]["StateUTTaxSL"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["StateUTTaxSL"];
                model.Sum_IntegratedTaxSL = dataTable.Rows[i]["IntegratedTaxSL"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["IntegratedTaxSL"];
                model.Sum_CessAmountSL = dataTable.Rows[i]["CessAmountSL"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["CessAmountSL"];
            }

            dataTable = ds.Tables[2];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                model.Sum_Difference_CGST = dataTable.Rows[i]["Difference_CGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Difference_CGST"];
                model.Sum_Difference_SGST = dataTable.Rows[i]["Difference_SGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Difference_SGST"];
                model.Sum_Difference_IGST = dataTable.Rows[i]["Difference_IGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Difference_IGST"];
                model.Sum_Difference_Cess = dataTable.Rows[i]["Difference_Cess"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Difference_Cess"];
            }

            //model.diff = (model.Sum_GL - model.Sum_supply);

            DataSet ds1 = new DataSet();
            SqlCommand cmd1 = new SqlCommand("Prc_Get_Output_Liability_Control_Sheet", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd1.Parameters.Add(new SqlParameter("@month", month));
            cmd1.Parameters.Add(new SqlParameter("@year", year));

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);

            adapter1.Fill(ds1);
            dataTable = ds1.Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var data = new OutputRegisterListModel();
                    data.Id = (long)dataTable.Rows[i]["Id"];
                    data.Invoice_Number = (string)dataTable.Rows[i]["Invoice_Number"];
                    data.Central_Tax = (decimal)dataTable.Rows[i]["Central_Tax"];
                    data.State_UT_Tax = (decimal)dataTable.Rows[i]["State_UT_Tax"];
                    data.Integrated_Tax = (decimal)dataTable.Rows[i]["Integrated_Tax"];
                    data.Cess_Amount = (decimal)dataTable.Rows[i]["Cess_Amount"];

                    data.Invoice_Number_LL = (string)dataTable.Rows[i]["Invoice_Number_LL"];
                    data.CGSTLL = (decimal)dataTable.Rows[i]["CGSTLL"];
                    data.SGSTLL = (decimal)dataTable.Rows[i]["SGSTLL"];
                    data.IGSTLL = (decimal)dataTable.Rows[i]["IGSTLL"];
                    data.CessLL = (decimal)dataTable.Rows[i]["CessLL"];

                    data.Diffarances_CGST_SLLL = (decimal)dataTable.Rows[i]["Diffarances_CGST_SLLL"];
                    data.Difference_SGST_SLLL = (decimal)dataTable.Rows[i]["Difference_SGST_SLLL"];
                    data.Difference_IGST_SLLL = (decimal)dataTable.Rows[i]["Difference_IGST_SLLL"];
                    data.Difference_Cess_SLLL = (decimal)dataTable.Rows[i]["Difference_Cess_SLLL"];

                    data.Remarks = (string)dataTable.Rows[i]["Remarks"];
                    data.Action = (string)dataTable.Rows[i]["Action"];                    
                    model.outputRegisterModels.Add(data);
                }
            }
            con.Close();

            return model;
        }

        //Old Logic
        #region Old Logic
        public async Task<OutputLiabilityListModel> GetGLIncomeControlSheetAsync_OldLogic(string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

            var model = new OutputLiabilityListModel();
            model.GL_IncomeData = new List<GL_IncomeData>();
            model.SupplyModels = new List<SupplyModel>();
            model.outputRegisterModels = new List<OutputRegisterListModel>();

            SqlCommand cmd = new SqlCommand("Prc_GL_Liability_Ledger_Register", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Month", month));
            cmd.Parameters.Add(new SqlParameter("@Year", year));

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adapter.Fill(ds);

            dataTable = ds.Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                GL_IncomeData gLIncomeData = new GL_IncomeData();
                gLIncomeData.Income_Booking_Resp_GL_ID = i + 1;
                gLIncomeData.GL_Code = dataTable.Rows[i]["GL_Income_Code"].ToString() ?? string.Empty;
                gLIncomeData.GL_Description = dataTable.Rows[i]["GL_Description"].ToString() ?? string.Empty;
                gLIncomeData.Amount = dataTable.Rows[i]["Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Amount"];
                gLIncomeData.Amount = Math.Round(gLIncomeData.Amount, 2);
                gLIncomeData.Amount = Math.Abs(gLIncomeData.Amount);

                model.GL_IncomeData.Add(gLIncomeData);
            }


            dataTable = ds.Tables[1];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                model.Sum_GL = dataTable.Rows[i]["Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Amount"];
                model.Sum_GL = Math.Round(model.Sum_GL, 2);
                model.Sum_GL = Math.Abs(model.Sum_GL);
            }

            dataTable = ds.Tables[2];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                model.Sum_supply = dataTable.Rows[i]["Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Amount"];
                model.Sum_supply = Math.Round(model.Sum_supply, 2);
                model.Sum_supply = Math.Abs(model.Sum_supply);
            }

            model.diff = (model.Sum_GL - model.Sum_supply);

            DataSet ds1 = new DataSet();

            SqlCommand cmd1 = new SqlCommand("Prc_Get_Output_Liability_Control_Sheet", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd1.Parameters.Add(new SqlParameter("@month", month));
            cmd1.Parameters.Add(new SqlParameter("@year", year));
           

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);

            adapter1.Fill(ds1);
            dataTable = ds1.Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var data = new OutputRegisterListModel();
                    data.Id = (long)dataTable.Rows[i]["Id"];
                    data.Document_Type = dataTable.Rows[i]["Document_Type"].ToString() ?? string.Empty;
                    data.Invoice_Number = (string)dataTable.Rows[i]["Invoice_Number"];
                    data.Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date"]).Date.ToShortDateString();
                    data.E_Invoice_No = (string)dataTable.Rows[i]["E_Invoice_No"];
                    data.E_Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date"]).Date.ToShortDateString();
                    data.E_Invoice_Total_Amount = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Total_Amount"]);
                    data.E_Invoice_Tax_Amount = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Tax_Amount"]);
                    data.E_Invoice_Amount_Different = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Amount_Different"]);
                    data.E_Invoice_Tax_Different = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Tax_Different"]);
                    data.Shipping_Bill_No = dataTable.Rows[i]["Shipping_Bill_No"].ToString() ?? string.Empty;
                    data.Shipping_Bill_Date = dataTable.Rows[i]["Shipping_Bill_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Shipping_Bill_Date"];
                    data.HSN_Code = dataTable.Rows[i]["HSN_Code"].ToString() ?? string.Empty;
                    data.Quantity = dataTable.Rows[i]["Quantity"].ToString() ?? string.Empty;
                    data.Unique_Quantity_Code = dataTable.Rows[i]["Unique_Quantity_Code"].ToString() ?? string.Empty;
                    data.Description = dataTable.Rows[i]["Description"].ToString() ?? string.Empty;
                    data.Party_Name = dataTable.Rows[i]["Party_Name"].ToString() ?? string.Empty;
                    data.GSTIN = dataTable.Rows[i]["GSTIN"].ToString() ?? string.Empty;
                    data.Reverse_Charge = dataTable.Rows[i]["Reverse_Charge"].ToString() ?? string.Empty;
                    data.Place_Of_Supply_State_Name = (string)dataTable.Rows[i]["Place_Of_Supply_State_Name"];
                    data.Exchange_Rate_As_Per_Notifications = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Notifications"];
                    data.Exchange_Rate_As_Per_Shipping_Bill = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Shipping_Bill"];
                    data.Taxable_Value = (decimal)dataTable.Rows[i]["Taxable_Value"];
                    data.Rate = (string)dataTable.Rows[i]["Rate"];
                    data.Total_Tax = (decimal)dataTable.Rows[i]["Total_Tax"];
                    data.Central_Tax = (decimal)dataTable.Rows[i]["Central_Tax"];
                    data.State_UT_Tax = (decimal)dataTable.Rows[i]["State_UT_Tax"];
                    data.Integrated_Tax = (decimal)dataTable.Rows[i]["Integrated_Tax"];
                    data.Cess_Amount = (decimal)dataTable.Rows[i]["Cess_Amount"];
                    data.Total_Invoice_Value_Rs = (decimal)dataTable.Rows[i]["Total_Invoice_Value_Rs"];
                    data.Vehicle_No = dataTable.Rows[i]["Vehicle_No"].ToString() ?? string.Empty;
                    data.E_Way_Bill_No = dataTable.Rows[i]["E_Way_Bill_No"].ToString() ?? string.Empty;
                    data.Dispatch_Location_Code = dataTable.Rows[i]["Dispatch_Location_Code"].ToString() ?? string.Empty;
                    data.Port_Code = dataTable.Rows[i]["Port_Code"].ToString() ?? string.Empty;
                    data.Voucher_No = dataTable.Rows[i]["Voucher_No"].ToString() ?? string.Empty;
                    data.Accounting_Date = Convert.ToDateTime(dataTable.Rows[i]["Accounting_Date"]).Date.ToShortDateString();
                    data.Location_Code = (string)dataTable.Rows[i]["Location_Code"];
                    data.GL_Code = (string)dataTable.Rows[i]["GL_Code"];
                    data.E_Invoice_No_2 = (string)dataTable.Rows[i]["E_Invoice_No_2"];
                    data.E_Invoice_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date_2"]).Date.ToShortDateString();
                    data.E_Way_Bill_No_2 = (string)dataTable.Rows[i]["E_Way_Bill_No_2"];
                    data.E_Way_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Way_Date_2"]).Date.ToShortDateString();
                    data.Remarks = (string)dataTable.Rows[i]["Remarks"];
                    data.Action = (string)dataTable.Rows[i]["Action"];
                    model.outputRegisterModels.Add(data);
                }
            }

            con.Close();

            return model;
        }

        public async Task<OutputLiabilityListModel> AddInSupply(AddToSupplyOutputLiabliyCommand command)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

            OutputLiabilityListModel data = new OutputLiabilityListModel();

            SqlCommand cmd = new SqlCommand("prc_Add_To_Supply_Liability_Control_Sheet", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Month", command.Month));
            cmd.Parameters.Add(new SqlParameter("@Year", command.Year));
            cmd.Parameters.Add(new SqlParameter("@ClientCode", "1"));
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

            }
            return data;
        }
        #endregion


        public async Task<List<OutputSupplyViewModel>> GetPreViewDocumentList(string month, string year)
        {
            //List<OutputSupplyViewModel> supplyModel = new List<OutputSupplyViewModel>();
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());
                var model = new OutputLiabilityListModel();
                model.outputSupplyLists = new List<OutputSupplyViewModel>();

                con.Open();

                String sql2 = $"select * from [dbo].[tbl_Output_Liability_Control_Sheet] where (DataSource='SL' or DataSource='BySystem - SL') and month='{month}' and year='{year}'";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    var data = new OutputSupplyViewModel();
                    data.Client_Code = rdr2["ClientCode"].ToString() ?? string.Empty;
                    data.Document_Type = rdr2["DocumentTypeSL"].ToString() ?? string.Empty;
                    data.Invoice_Number = rdr2["InvoiceNumberSL"].ToString() ?? string.Empty;
                    data.Invoice_Date = rdr2["InvoiceDateSL"] == System.DBNull.Value ? "" : Convert.ToDateTime(rdr2["InvoiceDateSL"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.E_Invoice_No = rdr2["IRNEInvoices"].ToString() ?? string.Empty;
                    data.E_Invoice_Date = rdr2["IRNDateEInvoices"] == System.DBNull.Value ? "" : Convert.ToDateTime(rdr2["IRNDateEInvoices"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.E_Invoice_Total_Amount = rdr2["TaxableValueEInvoice"] == System.DBNull.Value ? 0 : (decimal)rdr2["TaxableValueEInvoice"];
                    data.E_Invoice_Tax_Amount = rdr2["TaxAmountIGSTCGSTSGSTEInvoice"] == System.DBNull.Value ? 0 : (decimal)rdr2["TaxAmountIGSTCGSTSGSTEInvoice"];
                    data.E_Invoice_Amount_Different = rdr2["TaxableValueDifferenceSLEInvoices"] == System.DBNull.Value ? 0 : (decimal)rdr2["TaxableValueDifferenceSLEInvoices"];
                    data.E_Invoice_Tax_Different = rdr2["TaxDifferenceSLEInvoices"] == System.DBNull.Value ? 0 : (decimal)rdr2["TaxDifferenceSLEInvoices"];
                    data.Shipping_Bill_No = rdr2["ShippingBillNoSL"].ToString() ?? string.Empty;
                    data.Shipping_Bill_Date = rdr2["ShippingBillDateSL"] == System.DBNull.Value ? "" : Convert.ToDateTime(rdr2["ShippingBillDateSL"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.HSN_Code = rdr2["HSNCodeSL"].ToString() ?? string.Empty;
                    data.Quantity = rdr2["QuantitySL"] == System.DBNull.Value ? 0 : (decimal)rdr2["QuantitySL"];
                    data.Unique_Quantity_Code = rdr2["UniqueQuantityCodeSL"].ToString() ?? string.Empty;
                    data.Description = rdr2["DescriptionSL"].ToString() ?? string.Empty;
                    data.Party_Name = rdr2["RecieverNameSL"].ToString() ?? string.Empty;
                    data.GSTIN = rdr2["GSTINUINOfRecipientSL"].ToString() ?? string.Empty;
                    data.Reverse_Charge = rdr2["ReverseChargeSL"].ToString() ?? string.Empty;
                    data.Place_Of_Supply_State_Name = rdr2["PlaceOfSupplyStateNameSL"].ToString() ?? string.Empty;
                    data.Exchange_Rate_As_Per_Notifications = rdr2["ExchangeRateAsPerNotificationsSL"].ToString() ?? string.Empty;
                    data.Exchange_Rate_As_Per_Shipping_Bill = rdr2["ExchangeRateAsPerShippingBillSL"].ToString() ?? string.Empty;
                    data.Taxable_Value = rdr2["TaxableValueSL"] == System.DBNull.Value ? 0 : (decimal)rdr2["TaxableValueSL"];
                    data.Rate = rdr2["RateSL"] == System.DBNull.Value ? "0.00" : Convert.ToString(rdr2["RateSL"]);
                    //data.Rate = rdr2["RateSL"].ToString() ?? string.Empty;
                    data.Total_Tax = rdr2["TotalTaxSL"] == System.DBNull.Value ? 0 : (decimal)rdr2["TotalTaxSL"];
                    data.Central_Tax = rdr2["CentralTaxSL"] == System.DBNull.Value ? 0 : (decimal)rdr2["CentralTaxSL"];
                    data.State_UT_Tax = rdr2["StateUTTaxSL"] == System.DBNull.Value ? 0 : (decimal)rdr2["StateUTTaxSL"];
                    data.Integrated_Tax = rdr2["IntegratedTaxSL"] == System.DBNull.Value ? 0 : (decimal)rdr2["IntegratedTaxSL"];
                    data.Cess_Amount = rdr2["CessAmountSL"] == System.DBNull.Value ? 0 : (decimal)rdr2["CessAmountSL"];
                    data.Total_Invoice_Value_Rs = rdr2["TotalInvoiceValueRsSL"] == System.DBNull.Value ? 0 : (decimal)rdr2["TotalInvoiceValueRsSL"];
                    data.Vehicle_No = rdr2["VehicleNoSL"].ToString() ?? string.Empty;
                    data.E_Way_Bill_No = rdr2["EWayBillNo"].ToString() ?? string.Empty;
                    data.Dispatch_Location_Code = rdr2["DispatchLocationCodeSL"].ToString() ?? string.Empty;
                    data.Port_Code = rdr2["PortCodeSL"].ToString() ?? string.Empty;
                    data.Voucher_No = rdr2["VoucherNoSL"].ToString() ?? string.Empty;
                    data.Accounting_Date = rdr2["AccountingDateSL"] == System.DBNull.Value ? "" : Convert.ToDateTime(rdr2["AccountingDateSL"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.Location_Code = rdr2["LocationCodeSL"].ToString() ?? string.Empty;
                    data.GL_Code = rdr2["GLCodeSL"].ToString() ?? string.Empty;
                    data.E_Invoice_No_2 = rdr2["EInvoiceNoSL"].ToString() ?? string.Empty;
                    data.E_Invoice_Date_2 = rdr2["EInvoiceDateSL"] == System.DBNull.Value ? "" : Convert.ToDateTime(rdr2["EInvoiceDateSL"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.E_Way_Bill_No_2 = rdr2["EWayBillNoSL"].ToString() ?? string.Empty;
                    data.E_Way_Date_2 = rdr2["EWayDateSL"] == System.DBNull.Value ? "" : Convert.ToDateTime(rdr2["EWayDateSL"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.Remarks = rdr2["Remark"].ToString() ?? string.Empty;
                    data.Action = rdr2["Action"].ToString() ?? string.Empty;

                    model.outputSupplyLists.Add(data);
                }
                con.Close();

                return model.outputSupplyLists;
            }

            catch (Exception ex)
            {

                throw ex;
            }



        }

        public async Task<HttpResponseMessage> LiabilityControlDataById(UpdateLiabilityControlDataByIdCommand command)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                HttpResponseMessage httpResponse = new HttpResponseMessage();

                SqlCommand cmd = new SqlCommand("prc_Update_Liability_Control_Sheet_By_Id", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", command.Month));
                cmd.Parameters.Add(new SqlParameter("@Year", command.Year));
                cmd.Parameters.Add(new SqlParameter("@Id", command.Id));
                //cmd.Parameters.Add(new SqlParameter("@InvoiceNumberSL", command.Invoice_Number));
                //cmd.Parameters.Add(new SqlParameter("@InvoiceNumberLL", command.Invoice_Number_LL));
                cmd.Parameters.Add(new SqlParameter("@CentralTaxSL", command.Central_Tax));
                cmd.Parameters.Add(new SqlParameter("@StateUTTaxSL", command.State_UT_Tax));
                cmd.Parameters.Add(new SqlParameter("@IntegratedTaxSL", command.Integrated_Tax));
                cmd.Parameters.Add(new SqlParameter("@CessAmountSL", command.Cess_Amount));
                cmd.Parameters.Add(new SqlParameter("@CGSTLL", command.CGSTLL));
                cmd.Parameters.Add(new SqlParameter("@SGSTLL", command.SGSTLL));
                cmd.Parameters.Add(new SqlParameter("@IGSTLL", command.IGSTLL));
                cmd.Parameters.Add(new SqlParameter("@CessLL", command.CessLL));

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtResults = new DataTable();
                try
                {
                    cmd.ExecuteNonQuery();
                    httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    da.Fill(dtResults);
                }
                catch (Exception ex)
                {

                }

                con.Close();
                return httpResponse;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public async Task<OutputRegisterListModel> GetOutputRegisterListAsync(string month, string year)
        //{
        //    try
        //    {
        //        var model = new OutputRegisterListModel();
        //        model.outputRegisterList = new List<OutputRegisterListModel>();
        //        DataSet ds = new DataSet();
        //        SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

        //        SqlCommand cmd = new SqlCommand("Prc_Get_Output_Liability_Control_Sheet", con)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        cmd.Parameters.Add(new SqlParameter("@month", month));
        //        cmd.Parameters.Add(new SqlParameter("@year", year));
        //        con.Open();

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //        DataTable dataTable = new DataTable();
        //        adapter.Fill(ds);
        //        dataTable = ds.Tables[0];
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dataTable.Rows.Count; i++)
        //            {
        //                var data = new OutputRegisterListModel();
        //                data.Id = (int)dataTable.Rows[i]["Id"];
        //                data.Document_Type = dataTable.Rows[i]["Document_Type"].ToString() ?? string.Empty;
        //                data.Invoice_Number = (string)dataTable.Rows[i]["Invoice_Number"];
        //                data.Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date"]).Date.ToShortDateString();
        //                data.E_Invoice_No = (string)dataTable.Rows[i]["E_Invoice_No"];
        //                data.E_Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date"]).Date.ToShortDateString();
        //                data.E_Invoice_Total_Amount = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Total_Amount"]);
        //                data.E_Invoice_Tax_Amount = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Tax_Amount"]);
        //                data.E_Invoice_Amount_Different = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Amount_Different"]);
        //                data.E_Invoice_Tax_Different = String.Format("{0:0.00}", dataTable.Rows[i]["E_Invoice_Tax_Different"]);
        //                data.Shipping_Bill_No = dataTable.Rows[i]["Shipping_Bill_No"].ToString() ?? string.Empty;
        //                data.Shipping_Bill_Date = dataTable.Rows[i]["Shipping_Bill_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Shipping_Bill_Date"];
        //                data.HSN_Code = dataTable.Rows[i]["HSN_Code"].ToString() ?? string.Empty;
        //                data.Quantity = dataTable.Rows[i]["Quantity"].ToString() ?? string.Empty;
        //                data.Unique_Quantity_Code = dataTable.Rows[i]["Unique_Quantity_Code"].ToString() ?? string.Empty;
        //                data.Description = dataTable.Rows[i]["Description"].ToString() ?? string.Empty;
        //                data.Party_Name = dataTable.Rows[i]["Party_Name"].ToString() ?? string.Empty;
        //                data.GSTIN = dataTable.Rows[i]["GSTIN"].ToString() ?? string.Empty;
        //                data.Reverse_Charge = dataTable.Rows[i]["Reverse_Charge"].ToString() ?? string.Empty;
        //                data.Place_Of_Supply_State_Name = (string)dataTable.Rows[i]["Place_Of_Supply_State_Name"];
        //                data.Exchange_Rate_As_Per_Notifications = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Notifications"];
        //                data.Exchange_Rate_As_Per_Shipping_Bill = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Shipping_Bill"];
        //                data.Taxable_Value = (decimal)dataTable.Rows[i]["Taxable_Value"];
        //                data.Rate = (string)dataTable.Rows[i]["Rate"];
        //                data.Total_Tax = (decimal)dataTable.Rows[i]["Total_Tax"];
        //                data.Central_Tax = (decimal)dataTable.Rows[i]["Central_Tax"];
        //                data.State_UT_Tax = (decimal)dataTable.Rows[i]["State_UT_Tax"];
        //                data.Integrated_Tax = (decimal)dataTable.Rows[i]["Integrated_Tax"];
        //                data.Cess_Amount = (decimal)dataTable.Rows[i]["Cess_Amount"];
        //                data.Total_Invoice_Value_Rs = (double)dataTable.Rows[i]["Total_Invoice_Value_Rs"];
        //                data.Vehicle_No = dataTable.Rows[i]["Vehicle_No"].ToString() ?? string.Empty;
        //                data.E_Way_Bill_No = dataTable.Rows[i]["E_Way_Bill_No"].ToString() ?? string.Empty;
        //                data.Dispatch_Location_Code = dataTable.Rows[i]["Dispatch_Location_Code"].ToString() ?? string.Empty;
        //                data.Port_Code = dataTable.Rows[i]["Port_Code"].ToString() ?? string.Empty;
        //                data.Voucher_No = dataTable.Rows[i]["Voucher_No"].ToString() ?? string.Empty;
        //                data.Accounting_Date = Convert.ToDateTime(dataTable.Rows[i]["Accounting_Date"]).Date.ToShortDateString();
        //                data.Location_Code = (string)dataTable.Rows[i]["Location_Code"];
        //                data.GL_Code = (string)dataTable.Rows[i]["GL_Code"];
        //                data.E_Invoice_No_2 = (string)dataTable.Rows[i]["E_Invoice_No_2"];
        //                data.E_Invoice_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date_2"]).Date.ToShortDateString();
        //                data.E_Way_Bill_No_2 = (string)dataTable.Rows[i]["E_Way_Bill_No_2"];
        //                data.E_Way_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Way_Date_2"]).Date.ToShortDateString();
        //                data.Remarks = (string)dataTable.Rows[i]["Remarks"];
        //                data.Action = (string)dataTable.Rows[i]["Action"];
        //                model.outputRegisterList.Add(data);
        //            }
        //        }
        //        con.Close();
        //        if (model.outputRegisterList != null)
        //        {
        //            return model;
        //        }
        //        else
        //        {
        //            return model;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}