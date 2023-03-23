using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
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
    public class AdvaceReceivedRepositoryAsync : IAdvaceReceivedRepositoryAsync
    {
        private readonly ApplicationDBContext _context;

        public AdvaceReceivedRepositoryAsync(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<AdvanceReceivedListModule> GetAdvaceReceivedModuleList(string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                var model = new AdvanceReceivedListModule();
                model.AdvanceReceivedList = new List<AdvanceReceivedListModule>();

                SqlCommand cmd = new SqlCommand("prc_Get_Advance_Received_Module", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
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
                        var data = new AdvanceReceivedListModule();
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.ClientCode = dataTable.Rows[i]["ClientCode"].ToString() ?? string.Empty;
                        data.ReceiptNumber = dataTable.Rows[i]["ReceiptNumber"].ToString() ?? string.Empty;
                        data.DateofReceipt = Convert.ToDateTime(dataTable.Rows[i]["DateofReceipt"]).ToString(DateTimeFormat.StandardDateTime);
                        data.GSTIN = dataTable.Rows[i]["GSTIN"].ToString() ?? string.Empty;
                        data.POS = dataTable.Rows[i]["POS"].ToString() ?? string.Empty;
                        data.TypeOfSupply = dataTable.Rows[i]["TypeOfSupply"].ToString() ?? string.Empty;
                        data.TaxableValue = (decimal)dataTable.Rows[i]["TaxableValue"];
                        data.TotalAmendmentTaxableValue = (decimal)dataTable.Rows[i]["TotalAmendmentTaxableValue"];
                        data.Rate = (decimal)dataTable.Rows[i]["Rate"];
                        data.CessPercentage = (decimal)dataTable.Rows[i]["CessPercentage"];
                        data.CGST = dataTable.Rows[i]["CGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["CGST"];
                        data.SGST = dataTable.Rows[i]["SGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["SGST"];
                        data.IGST = dataTable.Rows[i]["IGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["IGST"];
                        data.Cess = dataTable.Rows[i]["Cess"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Cess"];
                        data.TotalTax = (decimal)dataTable.Rows[i]["TotalTax"];
                        data.TotalInvoiceValue = (decimal)dataTable.Rows[i]["TotalInvoiceValue"];
                        //data.Month = dataTable.Rows[i]["Month"].ToString() ?? string.Empty;
                        //data.Year = dataTable.Rows[i]["Year"].ToString() ?? string.Empty;

                        model.AdvanceReceivedList.Add(data);
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

        public async Task<HttpResponseMessage> AddReceivedAmendment(long id, string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                HttpResponseMessage httpResponse = new HttpResponseMessage();

                SqlCommand cmd = new SqlCommand("prc_Get_Advance_Received_Module_Amendment", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@Month", month));
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

        public async Task<List<AdvanceAmendmentViewModel>> GetPreviewAddAmendmentByIdList(long id, string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                var comparSLInvoiceList = new List<AdvanceAmendmentViewModel>();

                SqlCommand cmd = new SqlCommand("prc_Get_Advance_Received_Module_Amendment", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));
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
                        AdvanceAmendmentViewModel data = new AdvanceAmendmentViewModel();
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.AdvanceReceivedId = (long)dataTable.Rows[i]["AdvanceReceivedId"];
                        data.TaxableValue = (decimal)dataTable.Rows[i]["TaxableValue"];
                        data.Rate = (decimal)dataTable.Rows[i]["Rate"];
                        data.CessPercentage = (decimal)dataTable.Rows[i]["CessPercentage"];
                        data.CGST = (decimal)dataTable.Rows[i]["CGST"];
                        data.SGST = (decimal)dataTable.Rows[i]["SGST"];
                        data.IGST = (decimal)dataTable.Rows[i]["IGST"];
                        data.Cess = (decimal)dataTable.Rows[i]["Cess"];
                        data.TotalTax = (decimal)dataTable.Rows[i]["TotalTax"];
                        //data.TotalInvoiceValue = (decimal)dataTable.Rows[i]["TotalInvoiceValue"];
                        data.CreatedOn = Convert.ToDateTime(dataTable.Rows[i]["CreatedOn"]).ToString(DateTimeFormat.StandardDateTime);
                        data.CreatedBy = dataTable.Rows[i]["CreatedBy"].ToString() ?? string.Empty;

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

        public async Task<AdvanceReceivedViewModule> UpdateAdvanceReceivedById(long id, string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

            AdvanceReceivedViewModule data = new AdvanceReceivedViewModule();

            SqlCommand cmd = new SqlCommand("prc_Update_Total_Amendment_Taxable_Value", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@AdvanceReceivedId", id));
            cmd.Parameters.Add(new SqlParameter("@Month", month));
            cmd.Parameters.Add(new SqlParameter("@Year", year));

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }

            con.Close();
            return data;
        }
    }
}
