using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.GL_Income.Application.DTOs.ComparisonReport;
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
    public class ComparisonReportRepositoryAsync : IComparisonReportRepositoryAsync
    {
        private readonly ApplicationDBContext _context;

        public ComparisonReportRepositoryAsync(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ComparisonReportSLEInvoiceListModel> GetComparisonReportSheetSLEInvoiceAsync(string month, string year, string action)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                var model = new ComparisonReportSLEInvoiceListModel();
                model.ComparSLInvoiceList = new List<ComparisonReportSLEInvoiceListModel>();

                SqlCommand cmd = new SqlCommand("Prc_Get_Comparison_Report_SL_E_Invoice_Portal", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Action", action));
                cmd.Parameters.Add(new SqlParameter("@month", month));
                cmd.Parameters.Add(new SqlParameter("@year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                dataTable = ds.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ComparisonReportSLEInvoiceListModel data = new ComparisonReportSLEInvoiceListModel();
                        data.Comparison_Report_E_Invoice_Portal_ID = (long)dataTable.Rows[i]["Comparison_Report_E_Invoice_Portal_ID"];
                        data.E_Invoice_Bill_No = dataTable.Rows[i]["E_Invoice_Bill_No"].ToString() ?? string.Empty;
                        data.E_invoice_Bill_Date = Convert.ToDateTime(dataTable.Rows[i]["E_invoice_Bill_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Invoice_Number = (string)dataTable.Rows[i]["Invoice_Number"];
                        data.Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Invoice_Value = (string)dataTable.Rows[i]["Invoice_Value"];
                        data.Taxable_Value_E_Invoice = (decimal)dataTable.Rows[i]["Taxable_Value_E_Invoice"];
                        data.Total_Tax_E_Invoice = (decimal)dataTable.Rows[i]["Total_Tax_E_Invoice"];
                        data.Invoice_Number_SL = (string)dataTable.Rows[i]["Invoice_Number_SL"];
                        data.Invoice_Date_SL = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date_SL"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Taxable_Value_SL = (decimal)dataTable.Rows[i]["Taxable_Value_SL"];
                        data.Total_Tax_SL = (decimal)dataTable.Rows[i]["Total_Tax_SL"];
                        data.Taxable_Value_Diff_Invoice = (decimal)dataTable.Rows[i]["Taxable_Value_Diff_Invoice"];
                        data.Tax_Value_Diff_Invoice = (decimal)dataTable.Rows[i]["Tax_Value_Diff_Invoice"];
                        data.Remarks_E_Invoice = dataTable.Rows[i]["Remarks_E_Invoice"].ToString() ?? string.Empty;
                        data.Actions_E_Invoice = dataTable.Rows[i]["Actions_E_Invoice"].ToString() ?? string.Empty;

                        model.ComparSLInvoiceList.Add(data);
                    }
                }

                con.Close();
                if (model.ComparSLInvoiceList != null)
                {
                    return model;
                }
                else
                {
                    return model;
                }

                return model;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ComparisonReportSLEInvoiceListModel> GenComparisonSheetSLEInvoice(string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                ComparisonReportSLEInvoiceListModel data = new ComparisonReportSLEInvoiceListModel();

                SqlCommand cmd = new SqlCommand("prc_Insert_Comparison_Report_SL_E_Invoice_Portal", con)
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

        public async Task<ComparisonReportSLEWayListModel> GetComparisonReportSheetSLEWayAsync(string month, string year, string action)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                var model = new ComparisonReportSLEWayListModel();
                model.ComparSLEWayList = new List<ComparisonReportSLEWayListModel>();
                //List<ComparisonReportSLEWayListModel> comparisonReportList = new List<ComparisonReportSLEWayListModel>();

                SqlCommand cmd = new SqlCommand("Prc_Get_Comparison_Report_SL_E_Invoice_Portal", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Action", action));
                cmd.Parameters.Add(new SqlParameter("@month", month));
                cmd.Parameters.Add(new SqlParameter("@year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                dataTable = ds.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ComparisonReportSLEWayListModel data = new ComparisonReportSLEWayListModel();
                        data.Comparison_Report_E_Invoice_Portal_ID = (long)dataTable.Rows[i]["Comparison_Report_E_Invoice_Portal_ID"];
                        data.E_way_Bill_No = dataTable.Rows[i]["E_way_Bill_No"].ToString() ?? string.Empty;
                        data.E_way_Bill_Date = Convert.ToDateTime(dataTable.Rows[i]["E_way_Bill_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Way_Invoice_Number = dataTable.Rows[i]["E_Way_Invoice_Number"].ToString() ?? string.Empty;
                        data.E_Way_Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["E_Way_Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Invoice_Value_E_Way = (string)dataTable.Rows[i]["Invoice_Value_E_Way"];
                        data.E_Way_Taxable_Value = (decimal)dataTable.Rows[i]["E_Way_Taxable_Value"];
                        data.E_Way_Total = (decimal)dataTable.Rows[i]["E_Way_Total"];
                        data.Invoice_Number_SL = (string)dataTable.Rows[i]["Invoice_Number_SL"];
                        data.Invoice_Date_SL = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date_SL"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Taxable_Value_SL = (decimal)dataTable.Rows[i]["Taxable_Value_SL"];
                        data.Total_Tax_SL = (decimal)dataTable.Rows[i]["Total_Tax_SL"];
                        data.Taxable_Value_Diff_E_Way = (decimal)dataTable.Rows[i]["Taxable_Value_Diff_E_Way"];
                        data.Tax_Value_Diff_E_Way = (decimal)dataTable.Rows[i]["Tax_Value_Diff_E_Way"];
                        data.Remarks_E_Way = dataTable.Rows[i]["Remarks_E_Way"].ToString() ?? string.Empty;
                        data.Actions_E_Way = dataTable.Rows[i]["Actions_E_Way"].ToString() ?? string.Empty;

                        model.ComparSLEWayList.Add(data);
                    }
                }

                con.Close();
                if (model.ComparSLEWayList != null)
                {
                    return model;
                }
                else
                {
                    return model;
                }

                return model;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ComparisonReportSLEWayListModel> UpdateComparisonSheetSLEWay(string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                ComparisonReportSLEWayListModel data = new ComparisonReportSLEWayListModel();

                SqlCommand cmd = new SqlCommand("prc_Update_Comparison_Report_SL_E_Invoice_Portal", con)
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

        public async Task<HttpResponseMessage> UpdateSLEInvoiceAction(string action, int id, string updateType, int year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                HttpResponseMessage httpResponse = new HttpResponseMessage();

                SqlCommand cmd = new SqlCommand("Prc_Comparison_Report_SL_E_Invoice_Update_Action", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@UpdateAction", updateType));
                cmd.Parameters.Add(new SqlParameter("@ActionType", action));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

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

        public async Task<HttpResponseMessage> UpdateSLEWayAction(string action, int id, string updateType, int year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                HttpResponseMessage httpResponse = new HttpResponseMessage();

                SqlCommand cmd = new SqlCommand("Prc_Comparison_Report_SL_E_Invoice_Update_Action", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@UpdateAction", updateType));
                cmd.Parameters.Add(new SqlParameter("@ActionType", action));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

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

        public async Task<List<CompairsonReportsSLEInvoiceEWay>> GetPreviewSLDocumentList(string month, string year, string action)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                var comparSLInvoiceList = new List<CompairsonReportsSLEInvoiceEWay>();

                SqlCommand cmd = new SqlCommand("Prc_Get_Comparison_Report_SL_E_Invoice_Portal", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Action", action));
                cmd.Parameters.Add(new SqlParameter("@month", month));
                cmd.Parameters.Add(new SqlParameter("@year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                dataTable = ds.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        CompairsonReportsSLEInvoiceEWay data = new CompairsonReportsSLEInvoiceEWay();
                        data.Comparison_Report_E_Invoice_Portal_ID = (long)dataTable.Rows[i]["Comparison_Report_E_Invoice_Portal_ID"];
                        data.E_Invoice_Bill_No = dataTable.Rows[i]["E_Invoice_Bill_No"].ToString() ?? string.Empty;
                        data.E_invoice_Bill_Date = (DateTime)dataTable.Rows[i]["E_invoice_Bill_Date"];
                        data.Invoice_Number = (string)dataTable.Rows[i]["Invoice_Number"];
                        data.Invoice_Date = (DateTime)dataTable.Rows[i]["Invoice_Date"];
                        data.Invoice_Value = (string)dataTable.Rows[i]["Invoice_Value"];
                        data.Taxable_Value_E_Invoice = (decimal)dataTable.Rows[i]["Taxable_Value_E_Invoice"];
                        data.Total_Tax_E_Invoice = (decimal)dataTable.Rows[i]["Total_Tax_E_Invoice"];
                        data.Invoice_Number_SL = (string)dataTable.Rows[i]["Invoice_Number_SL"];
                        data.Invoice_Date_SL = (DateTime)dataTable.Rows[i]["Invoice_Date_SL"];
                        data.Taxable_Value_SL = (decimal)dataTable.Rows[i]["Taxable_Value_SL"];
                        data.Total_Tax_SL = (decimal)dataTable.Rows[i]["Total_Tax_SL"];
                        data.Taxable_Value_Diff_Invoice = (decimal)dataTable.Rows[i]["Taxable_Value_Diff_Invoice"];
                        data.Tax_Value_Diff_Invoice = (decimal)dataTable.Rows[i]["Tax_Value_Diff_Invoice"];
                        data.Remarks_E_Invoice = dataTable.Rows[i]["Remarks_E_Invoice"].ToString() ?? string.Empty;
                        //data.Actions_E_Invoice = dataTable.Rows[i]["Actions_E_Invoice"].ToString() ?? string.Empty;

                        data.E_way_Bill_No = dataTable.Rows[i]["E_way_Bill_No"].ToString() ?? string.Empty;
                        data.E_way_Bill_Date = (DateTime)dataTable.Rows[i]["E_way_Bill_Date"];
                        data.E_Way_Invoice_Number = dataTable.Rows[i]["E_Way_Invoice_Number"].ToString() ?? string.Empty;
                        data.E_Way_Invoice_Date = (DateTime)dataTable.Rows[i]["E_Way_Invoice_Date"];
                        data.Invoice_Value_E_Way = (string)dataTable.Rows[i]["Invoice_Value_E_Way"];
                        data.E_Way_Taxable_Value = (decimal)dataTable.Rows[i]["E_Way_Taxable_Value"];
                        data.E_Way_Total = (decimal)dataTable.Rows[i]["E_Way_Total"];
                        data.Taxable_Value_Diff_E_Way = (decimal)dataTable.Rows[i]["Taxable_Value_Diff_E_Way"];
                        data.Tax_Value_Diff_E_Way = (decimal)dataTable.Rows[i]["Tax_Value_Diff_E_Way"];
                        data.Remarks_E_Way = dataTable.Rows[i]["Remarks_E_Way"].ToString() ?? string.Empty;
                        //data.Actions_E_Way = dataTable.Rows[i]["Actions_E_Way"].ToString() ?? string.Empty;

                        comparSLInvoiceList.Add(data);
                    }
                }
                con.Close();

                return comparSLInvoiceList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}