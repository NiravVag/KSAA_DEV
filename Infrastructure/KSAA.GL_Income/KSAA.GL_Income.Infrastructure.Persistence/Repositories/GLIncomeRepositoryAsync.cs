using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.GSTR;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL;
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
    public class GLIncomeRepositoryAsync : IGLIncomeRepositoryAsync
    {
        protected readonly ApplicationDBContext _contex;
        public GLIncomeRepositoryAsync(ApplicationDBContext context)
        {
            _contex = context;
        }

        public async Task<GL_IncomeListModel> GetGLIncomeControlSheetAsync(string month, string year)
        {

            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());

            var model = new GL_IncomeListModel();
            model.GL_IncomeData = new List<GL_IncomeData>();
            model.SupplyModels = new List<SupplyModel>();

            SqlCommand cmd = new SqlCommand("prc_GL_Income_Supplier_Register", con)
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
                gLIncomeData.GL_Description = dataTable.Rows[i]["GLDescription"].ToString() ?? string.Empty;
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

            //con.Close();

            #region Test Code1
            /*
            var model = new GL_IncomeListModel();
            model.GL_IncomeData = new List<GL_IncomeData>();

            
            using (var connection = new SqlConnection(_contex.Database.GetConnectionString())) // get your connection string from the other class here
            {
                SqlCommand command = new SqlCommand("prc_GL_Income_Supplier_Register", connection);
                connection.Open();
                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        model.GL_IncomeData.Add(new GL_IncomeData
                        {
                            GL_Code = dr.GetString(1),
                            GL_Description = dr.GetString(2),
                            Amount = dr.GetInt32(0)
                        });
                    }
                    dr.NextResult();

                    model.Sum_GL = dr.GetInt32(1);

                    dr.NextResult();

                    model.Sum_supply = dr.GetInt32(2);
                }
            }
            */
            #endregion

            #region Test Code2
            //// Build command object
            //var command = _contex.Database.GetDbConnection().CreateCommand();
            //command.CommandText = "prc_GL_Income_Supplier_Register";
            //command.CommandType = System.Data.CommandType.StoredProcedure;

            //// Open database connection 
            //_contex.Database.OpenConnection();

            //// Create a DataReader 
            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            ////using (var result = reader)
            ////{
            //    // Build collection
            //    while (reader.Read())
            //    {
            //        model.GL_IncomeData.Add(new GL_IncomeData
            //        {
            //            GL_Code = reader.GetString(1),
            //            GL_Description = reader.GetString(2),
            //            Amount = reader.GetInt32(0)
            //        });
            //    }

            //    reader.NextResult();

            //    model.Sum_GL = reader.GetInt32(1);

            //    reader.NextResult();

            //    model.Sum_supply = reader.GetInt32(2);
            ////}
            #endregion

            //Supply Table List

            String sql2 = $"SELECT * FROM dbo.tbl_Contrl_Sheet_GL_Inc_Supply_Reg where DataSourceMap='Not Match' and Remarks <>'Different' and month='{month}' and year='{year}'";
            //String sql2 = "SELECT AccountingVoucherNo as Accounting_Voucher_No,* FROM dbo.tbl_Contrl_Sheet_GL_Inc_Supply_Reg where DataSourceMap='Not Match'";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds);
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                var data = new SupplyModel();
                data.GL_Code = rdr2["GLCode"].ToString() ?? string.Empty;
                data.Accounting_voucher = (string)rdr2["AccountingVoucherNo"];
                data.Amount = rdr2["Amount"] == System.DBNull.Value ? 0 : (decimal)rdr2["Amount"];
                data.Description = rdr2["Description"].ToString() ?? string.Empty;
                //data.Date = Convert.ToDateTime(rdr2["Date"]).Date.ToShortDateString();
                data.Date = Convert.ToDateTime(rdr2["Date"]).ToString(DateTimeFormat.StandardDateTime);
                data.HSN_SAC = rdr2["HSNSAC"].ToString() ?? string.Empty;
                data.CGST = rdr2["CGST"] == System.DBNull.Value ? 0 : (decimal)rdr2["CGST"];
                data.SGST = rdr2["SGST"] == System.DBNull.Value ? 0 : (decimal)rdr2["SGST"];
                data.IGST = rdr2["IGST"] == System.DBNull.Value ? 0 : (decimal)rdr2["IGST"];
                //data.CESS = rdr2["CESS"].ToString() ?? string.Empty;
                //data.GSTIN = rdr2["GSTIN"].ToString() ?? string.Empty;
                data.Remarks = rdr2["Remarks"].ToString() ?? string.Empty;
                data.Action = rdr2["Action"].ToString() ?? string.Empty;

                model.SupplyModels.Add(data);
            }
            con.Close();

            return model;
        }

        public async Task<GL_IncomeListModel> GenControlSheet(string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());

            GL_IncomeListModel data = new GL_IncomeListModel();

            SqlCommand cmd = new SqlCommand("prc_Contrl_Sheet_GL_Inc_Supply_Reg", con)
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

        public async Task<GL_IncomeListModel> AddInSupply(AddToSupplyCommand command)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());

            GL_IncomeListModel data = new GL_IncomeListModel();

            SqlCommand cmd = new SqlCommand("prc_Add_To_Supply_Contrl_Sheet", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Month", command.Month));
            cmd.Parameters.Add(new SqlParameter("@Year", command.Year));

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                
            }
            return data;
        }

        public async Task<List<SupplyModel>> GetPreViewDocumentList(string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());

            List<SupplyModel> supplyModel = new List<SupplyModel>();
            con.Open();

            String sql2 = $"select * from [dbo].[tbl_Contrl_Sheet_GL_Inc_Supply_Reg] where (DataSource='SL' or DataSource='BySystem - SL') and month='{month}' and year='{year}'";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds);
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                var data = new SupplyModel();
                data.Client_Code = rdr2["ClientCode"].ToString() ?? string.Empty;
                data.GL_Code = rdr2["GLCode"].ToString() ?? string.Empty;
                data.Invoice_No = rdr2["InvoiceNo"].ToString() ?? string.Empty;
                data.Accounting_voucher = (string)rdr2["AccountingVoucherNo"];
                data.Amount = rdr2["Amount"] == System.DBNull.Value ? 0 : (decimal)rdr2["Amount"];
                data.Description = rdr2["Description"].ToString() ?? string.Empty;
                data.Date = Convert.ToDateTime(rdr2["Date"]).ToString(DateTimeFormat.StandardDateTime);
                data.HSN_SAC = rdr2["HSNSAC"].ToString() ?? string.Empty;
                data.CGST = rdr2["CGST"] == System.DBNull.Value ? 0 : (decimal)rdr2["CGST"];
                data.SGST = rdr2["SGST"] == System.DBNull.Value ? 0 : (decimal)rdr2["SGST"];
                data.IGST = rdr2["IGST"] == System.DBNull.Value ? 0 : (decimal)rdr2["IGST"];
                data.CESS = rdr2["CESS"] == System.DBNull.Value ? 0 : (decimal)rdr2["CESS"];
                data.GSTIN = rdr2["GSTIN"].ToString() ?? string.Empty;
                data.DataSource = rdr2["DataSource"].ToString() ?? string.Empty;
                //data.Month = rdr2["Month"].ToString() ?? string.Empty;
                //data.Year = rdr2["Year"].ToString() ?? string.Empty;


                supplyModel.Add(data);
            }
            con.Close();

            return supplyModel;

        }

        public async Task<GSTRReplicaListModel> GetGSTRReplicaListAsync(string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());

            var model = new GSTRReplicaListModel();
            model.gSTRReplicas = new List<GSTRReplicaViewModel>();
            SqlCommand cmd = new SqlCommand("prc_Get_GSTR1_Summary", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Month", month));
            cmd.Parameters.Add(new SqlParameter("@Year", year));

            con.Open();

            
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da2.Fill(ds);
            SqlDataReader rdr2 = cmd.ExecuteReader();
            while (rdr2.Read())
            {
                var data = new GSTRReplicaViewModel();

                data.NoOfRecords = rdr2["NoOfRecords"].ToString() ?? string.Empty;
                data.GSTRCategory = rdr2["GSTR Category"].ToString() ?? string.Empty;
                data.GSTRTable = rdr2["GSTR Table"].ToString() ?? string.Empty;
                data.DocumentType = rdr2["Document Type"].ToString() ?? string.Empty;

                data.TaxableValue = rdr2["Taxable Value"] == System.DBNull.Value ? 0 : (decimal)rdr2["Taxable Value"];
                data.IntegratedTax = rdr2["Integrated Tax"] == System.DBNull.Value ? 0 : (decimal)rdr2["Integrated Tax"];
                data.CentralTax = rdr2["Central Tax"] == System.DBNull.Value ? 0 : (decimal)rdr2["Central Tax"];
                data.StateTax = rdr2["State Tax"] == System.DBNull.Value ? 0 : (decimal)rdr2["State Tax"];
                data.StateTaxCess = rdr2["State TaxCess"] == System.DBNull.Value ? 0 : (decimal)rdr2["State TaxCess"];

                model.gSTRReplicas.Add(data);
            }

            con.Close();

            return model;
        }
    }
}
