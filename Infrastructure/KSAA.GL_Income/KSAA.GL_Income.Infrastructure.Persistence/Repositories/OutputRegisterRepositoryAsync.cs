using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
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
    public class OutputRegisterRepositoryAsync : IOutputRegisterRepositoryAsync
    {
        private readonly ApplicationDBContext _context;

        public OutputRegisterRepositoryAsync(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<OutputRegisterViewModel>> GetOutputRegisterGridAsync(string month, string year)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());
                var outputRegGrid = new List<OutputRegisterViewModel>();


                SqlCommand cmd = new SqlCommand("Prc_Get_Output_Register_KSAA_Template", con)
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
                        OutputRegisterViewModel data = new OutputRegisterViewModel();
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.DocumentType = (string)dataTable.Rows[i]["DocumentType"];
                        data.InvoiceNumber = dataTable.Rows[i]["InvoiceNumber"].ToString() ?? string.Empty;
                        //data.InvoiceDate = dataTable.Rows[i]["InvoiceDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["InvoiceDate"];
                        data.InvoiceDate = Convert.ToDateTime(dataTable.Rows[i]["InvoiceDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["InvoiceDate"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_InvoiceNo = dataTable.Rows[i]["E_InvoiceNo"].ToString() ?? string.Empty; ;
                        //data.EInvoiceDate = dataTable.Rows[i]["EInvoiceDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EInvoiceDate"];
                        data.EInvoiceDate = Convert.ToDateTime(dataTable.Rows[i]["EInvoiceDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EInvoiceDate"]).ToString(DateTimeFormat.StandardDateTime);
                        data.EInvoiceTotalAmount = dataTable.Rows[i]["EInvoiceTotalAmount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["EInvoiceTotalAmount"];
                        data.EInvoiceTaxAmount = dataTable.Rows[i]["EInvoiceTaxAmount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["EInvoiceTaxAmount"];
                        data.EInvoiceAmountDifferent = dataTable.Rows[i]["EInvoiceAmountDifferent"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["EInvoiceAmountDifferent"];
                        data.EInvoiceTaxDifferent = (decimal)dataTable.Rows[i]["EInvoiceTaxDifferent"];
                        data.EInvoiceAmountDifferent = dataTable.Rows[i]["EInvoiceAmountDifferent"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["EInvoiceAmountDifferent"];
                        data.ShippingBillNo = dataTable.Rows[i]["ShippingBillNo"].ToString() ?? string.Empty; ;
                        //data.ShippingBillDate = dataTable.Rows[i]["ShippingBillDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["ShippingBillDate"];
                        data.ShippingBillDate = Convert.ToDateTime(dataTable.Rows[i]["ShippingBillDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["ShippingBillDate"]).ToString(DateTimeFormat.StandardDateTime);
                        data.HSNCode = (string)dataTable.Rows[i]["HSNCode"];
                        data.Quantity = dataTable.Rows[i]["Quantity"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Quantity"];
                        data.UniqueQuantityCode = (string)dataTable.Rows[i]["UniqueQuantityCode"];
                        data.Description = (string)dataTable.Rows[i]["Description"];
                        data.PartyName = (string)dataTable.Rows[i]["PartyName"];
                        data.GSTIN = (string)dataTable.Rows[i]["GSTIN"];
                        data.ReverseCharge = (string)dataTable.Rows[i]["ReverseCharge"];
                        data.PlaceOfSupplyStateName = (string)dataTable.Rows[i]["PlaceOfSupplyStateName"];
                        data.Exchange_RateAsPerNotifications = (string)dataTable.Rows[i]["Exchange_RateAsPerNotifications"];
                        data.Exchange_Rate_As_Per_Shipping_Bill = (string)dataTable.Rows[i]["Exchange_Rate_As_Per_Shipping_Bill"];
                        data.TaxableValue = dataTable.Rows[i]["TaxableValue"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["TaxableValue"];
                        data.Rate = (string)dataTable.Rows[i]["Rate"];
                        data.TotalTax = (decimal)dataTable.Rows[i]["TotalTax"];
                        data.TotalTax = dataTable.Rows[i]["TotalTax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["TotalTax"];
                        data.CentralTax = dataTable.Rows[i]["CentralTax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["CentralTax"];
                        data.StateUTTax = dataTable.Rows[i]["StateUTTax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["StateUTTax"];
                        data.IntegratedTax = dataTable.Rows[i]["IntegratedTax"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["IntegratedTax"];
                        data.CessAmount = dataTable.Rows[i]["CessAmount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["CessAmount"];
                        data.TotalInvoiceValue_Rs = dataTable.Rows[i]["TotalInvoiceValue_Rs"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["TotalInvoiceValue_Rs"];
                        data.VehicleNo = (string)dataTable.Rows[i]["VehicleNo"];
                        data.EWayBillNo = (string)dataTable.Rows[i]["EWayBillNo"];
                        data.DispatchLocationCode = (string)dataTable.Rows[i]["DispatchLocationCode"];
                        data.PortCode = (string)dataTable.Rows[i]["PortCode"];
                        data.VoucherNo = (string)dataTable.Rows[i]["VoucherNo"];
                        //data.AccountingDate = dataTable.Rows[i]["AccountingDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["AccountingDate"];
                        data.AccountingDate = Convert.ToDateTime(dataTable.Rows[i]["AccountingDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["AccountingDate"]).ToString(DateTimeFormat.StandardDateTime);
                        data.LocationCode = (string)dataTable.Rows[i]["LocationCode"];
                        data.GL_Code = (string)dataTable.Rows[i]["GL_Code"];
                        data.EInvoiceNo2 = (string)dataTable.Rows[i]["EInvoiceNo2"];
                        //data.EInvoiceDate2 = dataTable.Rows[i]["EInvoiceDate2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EInvoiceDate2"];
                        data.EInvoiceDate2 = Convert.ToDateTime(dataTable.Rows[i]["EInvoiceDate2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EInvoiceDate2"]).ToString(DateTimeFormat.StandardDateTime);
                        data.EWayBillNo2 = (string)dataTable.Rows[i]["EWayBillNo2"];
                        //data.EWayDate2 = dataTable.Rows[i]["EWayDate2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EWayDate2"];
                        data.EWayDate2 = Convert.ToDateTime(dataTable.Rows[i]["EWayDate2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EWayDate2"]).ToString(DateTimeFormat.StandardDateTime);
                        data.AdvanceReceiptNumber = (string)dataTable.Rows[i]["AdvanceReceiptNumber"];
                        data.IsInvoiceAmended = dataTable.Rows[i]["IsInvoiceAmended"] == System.DBNull.Value ? false : (bool)dataTable.Rows[i]["IsInvoiceAmended"];
                        data.RemarksInvoiceAmended = dataTable.Rows[i]["RemarksInvoiceAmended"].ToString() ?? string.Empty;
                        outputRegGrid.Add(data);
                    }
                }
                con.Close();

                return outputRegGrid;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
