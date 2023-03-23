using AutoMapper;
using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.Domain.Entities.OutputRegister;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
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
    public class AdvanceAdjustmentRepositoryAsync : IAdvanceAdjustmentRepositoryAsync
    {
        protected readonly ApplicationDBContext _contex;
        private readonly IGenericRepositoryAsync<OutputRegister> _outputRegisterRepositoryAsync;
        private readonly IMapper _mapper;
        public AdvanceAdjustmentRepositoryAsync(ApplicationDBContext contex)
        {
            _contex = contex;
        }

        public async Task<List<AdvanceAdjustmentViewModel>> GetAdvanceAdjustmentAsync(string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());
                var advanceAdjustmentList = new List<AdvanceAdjustmentViewModel>();
                SqlCommand cmd = new SqlCommand("prc_Get_Advance_Received_Module_W_AmendmentDate", con)
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
                        AdvanceAdjustmentViewModel data = new AdvanceAdjustmentViewModel();
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.ClientCode = (string)dataTable.Rows[i]["ClientCode"];
                        //data.EmployeeCode = (string)dataTable.Rows[i]["EmployeeCode"];
                        //data.InvoiceNumber = (string)dataTable.Rows[i]["InvoiceNumber"];
                        data.ReceiptNumber = dataTable.Rows[i]["ReceiptNumber"].ToString() ?? string.Empty;
                        data.Dateofadjustment = Convert.ToDateTime(dataTable.Rows[i]["DateOfAdustment"]).ToString(DateTimeFormat.StandardDateTime);
                        data.GSTIN = (string)dataTable.Rows[i]["GSTIN"];
                        data.POS = (string)dataTable.Rows[i]["POS"];
                        data.Typeofsupply = (string)dataTable.Rows[i]["TypeOfSupply"];
                        data.TaxableValue = (decimal)dataTable.Rows[i]["TaxableValue"];
                        data.Rate = (decimal)dataTable.Rows[i]["Rate"];
                        data.CessPercentage = (decimal)dataTable.Rows[i]["CessPercentage"];
                        data.CGST = (decimal)dataTable.Rows[i]["CGST"];
                        data.SGST = (decimal)dataTable.Rows[i]["SGST"];
                        data.IGST = (decimal)dataTable.Rows[i]["IGST"];
                        data.Cess = (decimal)dataTable.Rows[i]["Cess"];
                        data.TotalTax = (decimal)dataTable.Rows[i]["TotalTax"];
                        data.TotalreceiptValue = (decimal)dataTable.Rows[i]["TotalInvoiceValue"];
                        data.TotalAmendmentTaxableValue = (decimal)dataTable.Rows[i]["TotalAmendmentTaxableValue"];

                        advanceAdjustmentList.Add(data);
                    }
                }
                con.Close();
                return advanceAdjustmentList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AdvanceAdjustmentViewModel> GetAdjustmentAmendmentById(long id, string month, string year)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());
                //var advanceAdjustmentList = new AdvanceAdjustmentViewModel();
                SqlCommand cmd = new SqlCommand("prc_Get_Advance_Received_Module_W_AmendmentDate_GetBy_ID", con)
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
                AdvanceAdjustmentViewModel data = new AdvanceAdjustmentViewModel();
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.ClientCode = (string)dataTable.Rows[i]["ClientCode"];
                        //data.EmployeeCode = (string)dataTable.Rows[i]["EmployeeCode"];
                        //data.InvoiceNumber = (string)dataTable.Rows[i]["InvoiceNumber"];
                        data.ReceiptNumber = dataTable.Rows[i]["ReceiptNumber"].ToString() ?? string.Empty;
                        data.Dateofadjustment = Convert.ToDateTime(dataTable.Rows[i]["DateOfAdustment"]).ToString(DateTimeFormat.StandardDateTime);
                        data.GSTIN = (string)dataTable.Rows[i]["GSTIN"];
                        data.POS = (string)dataTable.Rows[i]["POS"];
                        data.Typeofsupply = (string)dataTable.Rows[i]["TypeOfSupply"];
                        data.TaxableValue = dataTable.Rows[i]["TaxableValue"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["TaxableValue"];
                        data.Rate = dataTable.Rows[i]["Rate"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Rate"];
                        data.CessPercentage = dataTable.Rows[i]["CessPercentage"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["CessPercentage"];
                        data.CGST = dataTable.Rows[i]["CGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["CGST"];
                        data.SGST = dataTable.Rows[i]["SGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["SGST"];
                        data.IGST = dataTable.Rows[i]["IGST"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["IGST"];
                        data.Cess = dataTable.Rows[i]["Cess"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Cess"];
                        data.TotalTax = dataTable.Rows[i]["TotalTax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["TotalTax"];
                        data.TotalreceiptValue = dataTable.Rows[i]["TotalInvoiceValue"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["TotalInvoiceValue"];
                        data.TotalAmendmentTaxableValue = dataTable.Rows[i]["TotalAmendmentTaxableValue"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["TotalAmendmentTaxableValue"];
                        data.Month = (string)dataTable.Rows[i]["Month"];
                        data.Year = (string)dataTable.Rows[i]["Year"];

                        //advanceAdjustmentList.Add(data);
                    }
                }
                con.Close();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<OutputRegisterViewModel>> GetSLInvoiceList(string month, string year)
        {
            return (_contex.OutputRegisters.Where(x => x.InvoiceNumberSL != null && x.Month == month && x.Year == year && !x.IsInvoiceTagged).Select(x => new OutputRegisterViewModel()
            {
                Id = x.Id,
                InvoiceNumberSL = x.InvoiceNumberSL
            }).ToList());
        }

        public async Task<AdvanceAdjustmentTagReceiptModel> AddTagInvoiceById(AddTagInvoiceByIdCommand command)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_contex.Database.GetConnectionString());

                AdvanceAdjustmentTagReceiptModel data = new AdvanceAdjustmentTagReceiptModel();

                SqlCommand cmd = new SqlCommand("prc_Update_Invoice_Tagging_From_Advance_Amendment_Module", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", command.Month));
                cmd.Parameters.Add(new SqlParameter("@Year", command.Year));
                cmd.Parameters.Add(new SqlParameter("@ReceiptNumber", command.ReceiptNumber));
                cmd.Parameters.Add(new SqlParameter("@AmendmentInvoiceAmount", command.AmendmentInvoiceAmount));
                cmd.Parameters.Add(new SqlParameter("@InvoiceAmount", command.InvoiceAmount));
                cmd.Parameters.Add(new SqlParameter("@SLRegisterID", command.SLRegisterId));
                //cmd.Parameters.Add(new SqlParameter("@InvoiceNumberSL", command.InvoiceNumberSL));
                cmd.Parameters.Add(new SqlParameter("@AdvancedReceivedID", command.AdvancedReceivedID));

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {

                }

                con.Close();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OutputRegisterViewModel> GetSLInvoiceDetailById(long id, string month, string year)
        {
            return (_contex.OutputRegisters.Where(x => x.Id == id && x.Month == month && x.Year == year).Select(x => new OutputRegisterViewModel()
            {
                Id = x.Id,
                InvoiceNumberSL = x.InvoiceNumberSL,
                CentralTaxSL = x.CentralTaxSL,
                StateUTTaxSL = x.StateUTTaxSL,
                IntegratedTaxSL = x.IntegratedTaxSL,
                TaxableValueSL = x.TaxableValueSL
            }).First());
        }
    }
}
