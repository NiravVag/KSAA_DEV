using KSAA.DAL;
using KSAA.DAL.Repositories;
using KSAA.Domain.Common;
using KSAA.Domain.Entities.DocumentUpload;
using KSAA.Domain.Entities.Master;
using KSAA.Master.Application.DTOs.DocumentUpload;
using KSAA.Master.Application.DTOs.IAD;
using KSAA.Master.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories
{
    public class DocumentTypeRepositoryAsync : IDocumentTypeRepositoryAsync
    {
        private readonly ApplicationDBContext _context;

        public DocumentTypeRepositoryAsync(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GLIncomeRegisterListModel> GetGLDocumentPrivew(string month, string year)
        {
            try
            {
                var model = new GLIncomeRegisterListModel();
                model.gLIncomeRegistersList = new List<GLIncomeRegisterViewModel>();

                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                SqlCommand cmd = new SqlCommand("prc_Get_GL_Data", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", month));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new GLIncomeRegisterViewModel();
                    data.Id = (long)rdr["Id"];
                    data.ClientCode = rdr["ClientCode"].ToString() ?? string.Empty;
                    data.DocumentType = rdr["DocumentType"].ToString() ?? string.Empty;
                    data.InvoiceReceiptDNCNNo = rdr["InvoiceReceiptDNCNNo"].ToString() ?? string.Empty;
                    data.InvoiceReceiptDNCNDate = Convert.ToDateTime(rdr["InvoiceReceiptDNCNDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.CustomerCode = rdr["CustomerCode"].ToString() ?? string.Empty;
                    data.GSTIN = rdr["GSTIN"].ToString() ?? string.Empty;
                    data.GLIncomeCode = rdr["GLIncomeCode"].ToString() ?? string.Empty;
                    data.GLIncomeDescription = rdr["GLIncomeDescription"].ToString() ?? string.Empty;
                    data.TaxableValue = (decimal)rdr["TaxableValue"];
                    data.CGST = rdr["CGST"] == System.DBNull.Value ? 0 : (decimal)rdr["CGST"];
                    data.SGST = rdr["SGST"] == System.DBNull.Value ? 0 : (decimal)rdr["SGST"];
                    data.IGST = rdr["IGST"] == System.DBNull.Value ? 0 : (decimal)rdr["IGST"];
                    data.CESS = rdr["CESS"] == System.DBNull.Value ? 0 : (decimal)rdr["CESS"];
                    data.LocationCode = rdr["LocationCode"].ToString() ?? string.Empty;
                    data.VoucherNo = rdr["VoucherNo"].ToString() ?? string.Empty;
                    data.AccountingDate = Convert.ToDateTime(rdr["AccountingDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.Month = rdr["Month"].ToString() ?? string.Empty;
                    data.Year = rdr["Year"].ToString() ?? string.Empty;


                    model.gLIncomeRegistersList.Add(data);
                }

                con.Close();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SupplyRegisterListModel> GetSLDocumentPrivew(string month, string year)
        {
            try
            {
                var model = new SupplyRegisterListModel();
                model.supplyRegistersList = new List<SupplyRegisterViewModel>();

                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                SqlCommand cmd = new SqlCommand("prc_Get_SL_Data", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", month));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new SupplyRegisterViewModel();
                    data.Id = (long)rdr["Id"];
                    data.ClientCode = rdr["ClientCode"].ToString() ?? string.Empty;
                    data.DocumentType = rdr["DocumentType"].ToString() ?? string.Empty;
                    data.InvoiceReceiptDNCNNo = rdr["InvoiceReceiptDNCNNo"].ToString() ?? string.Empty;
                    data.EInvoiceNo = rdr["EInvoiceNo"].ToString() ?? string.Empty;
                    data.InvoiceReceiptDNCNDate = Convert.ToDateTime(rdr["InvoiceReceiptDNCNDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.ShippingBillNo = rdr["ShippingBillNo"].ToString() ?? string.Empty;
                    data.ShippingBillDate = Convert.ToDateTime(rdr["ShippingBillDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.HSNCode = rdr["HSNCode"].ToString() ?? string.Empty;
                    data.Quantity = (decimal)rdr["Quantity"];
                    data.UniqueQuantityCode = rdr["UniqueQuantityCode"].ToString() ?? string.Empty;
                    data.Description = rdr["Description"].ToString() ?? string.Empty;
                    data.PartyName = rdr["PartyName"].ToString() ?? string.Empty;
                    data.GSTIN = rdr["GSTIN"].ToString() ?? string.Empty;
                    data.ReverseCharge = rdr["ReverseCharge"].ToString() ?? string.Empty;
                    data.PlaceOfSupplyStateName = rdr["PlaceOfSupplyStateName"].ToString() ?? string.Empty;
                    data.ExchangeRateAsPerNotifications = rdr["ExchangeRateAsPerNotifications"].ToString() ?? string.Empty;
                    data.ExchangeRateAsPerShippingBill = rdr["ExchangeRateAsPerShippingBill"].ToString() ?? string.Empty;
                    data.ClientCode = rdr["ClientCode"].ToString() ?? string.Empty;
                    data.TaxableValue = (decimal)rdr["TaxableValue"];
                    data.Rate = (decimal)rdr["CGST"];
                    data.TaxAmount = (decimal)rdr["TaxAmount"];
                    data.CGST = (decimal)rdr["CGST"];
                    data.SGSTUTGST = (decimal)rdr["SGSTUTGST"];
                    data.IGST = (decimal)rdr["IGST"];
                    data.Cess = (decimal)rdr["Cess"];
                    data.TotalInvoiceValue = (decimal)rdr["TotalInvoiceValue"];
                    data.VehicleNo = rdr["VehicleNo"].ToString() ?? string.Empty;
                    data.EInvoiceDate = Convert.ToDateTime(rdr["EInvoiceDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.EWayBillNo = rdr["EWayBillNo"].ToString() ?? string.Empty;
                    data.EWayDate = Convert.ToDateTime(rdr["EWayDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.DispatchLocationCode = rdr["DispatchLocationCode"].ToString() ?? string.Empty;
                    data.PortCode = rdr["PortCode"].ToString() ?? string.Empty;
                    data.VoucherNo = rdr["VoucherNo"].ToString() ?? string.Empty;
                    data.AccountingDate = Convert.ToDateTime(rdr["AccountingDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.LocationCode = rdr["LocationCode"].ToString() ?? string.Empty;
                    data.GLCode = rdr["GLCode"].ToString() ?? string.Empty;
                    data.TypeOfSupply = rdr["TypeOfSupply"].ToString() ?? string.Empty;
                    data.GSTPaymentType = rdr["GSTPaymentType"].ToString() ?? string.Empty;

                    model.supplyRegistersList.Add(data);
                }
                con.Close();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<EInvoiceRegisterListModel> GetEInvoiceDocumentPrivew(string month, string year)
        {
            try
            {
                var model = new EInvoiceRegisterListModel();
                model.eInvoiceRegistersList = new List<EInvoiceRegisterViewModel>();

                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                SqlCommand cmd = new SqlCommand("prc_Get_EInvoice_Data", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", month));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new EInvoiceRegisterViewModel();
                    data.Id = (long)rdr["Id"];
                    data.ClientCode = rdr["ClientCode"].ToString() ?? string.Empty;
                    data.GSTINUINOfRecipient = rdr["GSTINUINOfRecipient"].ToString() ?? string.Empty;
                    data.RecieverName = rdr["RecieverName"].ToString() ?? string.Empty;
                    data.InvoiceNumber = rdr["InvoiceNumber"].ToString() ?? string.Empty;
                    data.InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.InvoiceValue = rdr["InvoiceValue"].ToString() ?? string.Empty;
                    data.PlaceOfSupply = rdr["PlaceOfSupply"].ToString() ?? string.Empty;
                    data.ReverseCharge = rdr["ReverseCharge"].ToString() ?? string.Empty;
                    data.ApplicableofTaxRate = (decimal)rdr["ApplicableofTaxRate"];
                    data.InvoiceType = rdr["InvoiceType"].ToString() ?? string.Empty;
                    data.ECommerceGSTIN = rdr["ECommerceGSTIN"].ToString() ?? string.Empty;
                    data.Rate = (decimal)rdr["Rate"];
                    data.TaxableValue = (decimal)rdr["TaxableValue"];
                    data.IntegratedTax = (decimal)rdr["IntegratedTax"];
                    data.CentralTax = (decimal)rdr["CentralTax"];
                    data.StateUTTax = (decimal)rdr["StateUTTax"];
                    data.CessAmount = (decimal)rdr["CessAmount"];
                    data.IRN = rdr["IRN"].ToString() ?? string.Empty;
                    data.IRNDate = Convert.ToDateTime(rdr["IRNDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.EInvoiceStatus = rdr["EInvoiceStatus"].ToString() ?? string.Empty;
                    data.GSTR1AutoPopulationDeletionUponCancellationDate = Convert.ToDateTime(rdr["GSTR1AutoPopulationDeletionUponCancellationDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.GSTR1AutoPopulationDeletionStatus = rdr["GSTR1AutoPopulationDeletionStatus"].ToString() ?? string.Empty;
                    data.ErrorInAutoPopulationDeletion = rdr["ErrorInAutoPopulationDeletion"].ToString() ?? string.Empty;
                    data.InvoiceType2 = rdr["InvoiceType2"].ToString() ?? string.Empty;
                    data.Month = rdr["Month"].ToString() ?? string.Empty;
                    data.Year = rdr["Year"].ToString() ?? string.Empty;

                    model.eInvoiceRegistersList.Add(data);
                }
                con.Close();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EWayBillRegisterListModel> GetEWayBillDocumentPrivew(string month, string year)
        {
            try
            {
                var model = new EWayBillRegisterListModel();
                model.eWayBillRegistersList = new List<EWayBillRegisterViewModel>();

                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                SqlCommand cmd = new SqlCommand("prc_Get_EWayBill_Data", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", month));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new EWayBillRegisterViewModel();
                    data.Id = (long)rdr["Id"];
                    data.ClientCode = rdr["ClientCode"].ToString() ?? string.Empty;
                    data.EWBNo = rdr["EWBNo"].ToString() ?? string.Empty;
                    data.EWBDate = Convert.ToDateTime(rdr["EWBDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.SupplyType = rdr["SupplyType"].ToString() ?? string.Empty;
                    data.DocNo = rdr["DocNo"].ToString() ?? string.Empty;
                    data.DocDate = Convert.ToDateTime(rdr["DocDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.OtherPartyGSTIN = rdr["OtherPartyGSTIN"].ToString() ?? string.Empty;
                    data.TransporterDetails = rdr["TransporterDetails"].ToString() ?? string.Empty;
                    data.FromGSTINInfo = rdr["FromGSTINInfo"].ToString() ?? string.Empty;
                    data.TOGSTINInfo = rdr["TOGSTINInfo"].ToString() ?? string.Empty;
                    data.Status = rdr["Status"].ToString() ?? string.Empty;
                    data.NoOfItems = (decimal)rdr["NoOfItems"];
                    data.MainHSNCode = rdr["MainHSNCode"].ToString() ?? string.Empty;
                    data.MainHSNDesc = rdr["MainHSNDesc"].ToString() ?? string.Empty;
                    data.AssessableValue = (decimal)rdr["AssessableValue"];
                    data.SGST = (decimal)rdr["SGST"];
                    data.CGST = (decimal)rdr["CGST"];
                    data.IGST = (decimal)rdr["IGST"];
                    data.CESS = (decimal)rdr["CESS"];
                    data.CESSNonAdvol = (decimal)rdr["CESSNonAdvol"];
                    data.OtherValue = (decimal)rdr["OtherValue"];
                    data.TotalInvoice = (decimal)rdr["TotalInvoice"];
                    data.ValidTillDate = Convert.ToDateTime(rdr["ValidTillDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.ModeOfGeneration = rdr["ModeOfGeneration"].ToString() ?? string.Empty;
                    data.CancelledBy = rdr["CancelledBy"].ToString() ?? string.Empty;
                    data.CancelledDate = Convert.ToDateTime(rdr["CancelledDate"]).ToString(DateTimeFormat.StandardDateTime, CultureInfo.InvariantCulture);
                    data.Month = rdr["Month"].ToString() ?? string.Empty;
                    data.Year = rdr["Year"].ToString() ?? string.Empty;

                    model.eWayBillRegistersList.Add(data);
                }
                con.Close();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<LiabilityLedgerListModel> GetLLDocumentPrivew(string month, string year)
        {
            try
            {
                var model = new LiabilityLedgerListModel();
                model.liabilityLedgersList = new List<LiabilityLedgerViewModel>();

                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                SqlCommand cmd = new SqlCommand("prc_Get_Liability_Data", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", month));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new LiabilityLedgerViewModel();
                    data.Id = (long)rdr["Id"];
                    data.ClientCode = rdr["ClientCode"].ToString() ?? string.Empty;
                    data.GLCode = rdr["GLCode"].ToString() ?? string.Empty;
                    data.GLDescription = rdr["GLIncomeDescription"].ToString() ?? string.Empty;
                    data.DocumentType = rdr["DocumentType"].ToString() ?? string.Empty;
                    data.InvoiceReceiptDNCNNo = rdr["InvoiceReceiptDNCNNo"].ToString() ?? string.Empty;
                    data.EInvoiceNo = rdr["EInvoiceNo"].ToString() ?? string.Empty;
                    data.CGST = (decimal)rdr["CGST"];
                    data.SGST = (decimal)rdr["SGST"];
                    data.IGST = (decimal)rdr["IGST"];
                    data.CESS = (decimal)rdr["CESS"];
                    data.Month = rdr["Month"].ToString() ?? string.Empty;
                    data.Year = rdr["Year"].ToString() ?? string.Empty;

                    model.liabilityLedgersList.Add(data);
                }
                con.Close();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateInvoiceAmendmentData(List<InvoiceAmendmentUpdateViewModel> invoiceAmendmentUpdateList)
        {
            bool isSuccessfull = true;

            try
            {
                foreach (var item in invoiceAmendmentUpdateList)
                {
                    SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                    SqlCommand cmd = new SqlCommand("prc_Update_Invoice_Amendment_Module_Output_Register_Temp", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@InoviceNumber", item.InvoiceNumber));
                    cmd.Parameters.Add(new SqlParameter("@RevisedGSTIN", item.RevisedGSTIN));
                    cmd.Parameters.Add(new SqlParameter("@RevisedPOS", item.RevisedPOS));
                    cmd.Parameters.Add(new SqlParameter("@RevisedDocumentType", item.RevisedDocumentType));
                    cmd.Parameters.Add(new SqlParameter("@RevisedInvoiceNoDebitCreditNote", item.RevisedInvoiceNoDebitCreditNote));
                    cmd.Parameters.Add(new SqlParameter("@RevisedInvoiceDate",Convert.ToDateTime(item.RevisedInvoiceDate)));
                    cmd.Parameters.Add(new SqlParameter("@RevisedShippingBillNo", item.RevisedShippingBillNo));
                    cmd.Parameters.Add(new SqlParameter("@RevisedShippingBillDate", Convert.ToDateTime(item.RevisedShippingBillDate)));
                    cmd.Parameters.Add(new SqlParameter("@RevisedPortCode", item.RevisedPortCode));
                    cmd.Parameters.Add(new SqlParameter("@RevisedGSTPaymentType", item.RevisedGSTPaymentType));
                    cmd.Parameters.Add(new SqlParameter("@RevisedTaxableValue", item.RevisedTaxableValue));
                    cmd.Parameters.Add(new SqlParameter("@RevisedHSNSAC", item.RevisedHSNSAC));
                    cmd.Parameters.Add(new SqlParameter("@RevisedRate", item.RevisedRate));
                    cmd.Parameters.Add(new SqlParameter("@RevisedCess", item.RevisedCess));
                    cmd.Parameters.Add(new SqlParameter("@RevisedCGST", item.RevisedCGST));
                    cmd.Parameters.Add(new SqlParameter("@RevisedSGST", item.RevisedSGST));
                    cmd.Parameters.Add(new SqlParameter("@RevisedIGST", item.RevisedIGST));
                    cmd.Parameters.Add(new SqlParameter("@RevisedTotalTax", item.RevisedTotalTax));
                    cmd.Parameters.Add(new SqlParameter("@RemarksforChangeinLiability", item.RemarksforChangeinLiability));
                    cmd.Parameters.Add(new SqlParameter("@GSTR1presentationRemark", item.GSTR1presentationRemark));
                    cmd.Parameters.Add(new SqlParameter("@ClientCode", item.ClientCode));
                    cmd.Parameters.Add(new SqlParameter("@Month", item.Month));
                    cmd.Parameters.Add(new SqlParameter("@Year", item.Year));

                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 1)
                    {
                        isSuccessfull = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccessfull;
        }

        public async Task<AdvanceReceivedListModel> GetAdvRecDocumentPrivew(string month, string year)
        {
            try
            {
                var model = new AdvanceReceivedListModel();
                model.advanceReceivedList = new List<AdvanceReceivedViewModel>();

                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

                SqlCommand cmd = new SqlCommand("prc_Get_Advance_Received_Data", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Month", month));
                cmd.Parameters.Add(new SqlParameter("@Year", year));

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(ds);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new AdvanceReceivedViewModel();
                    data.Id = (long)rdr["Id"];
                    data.ClientCode = rdr["ClientCode"].ToString() ?? string.Empty;
                    data.ReceiptNumber = rdr["ReceiptNumber"].ToString() ?? string.Empty;
                    data.DateofReceipt = Convert.ToDateTime(rdr["DateofReceipt"]).ToString(DateTimeFormat.StandardDateTime);
                    data.GSTIN = rdr["GSTIN"].ToString() ?? string.Empty;
                    data.POS = rdr["POS"].ToString() ?? string.Empty;
                    data.TypeOfSupply = rdr["TypeOfSupply"].ToString() ?? string.Empty;
                    data.TaxableValue = (decimal)rdr["TaxableValue"];
                    data.TotalAmendmentTaxableValue = (decimal)rdr["TotalAmendmentTaxableValue"];
                    data.Rate = (decimal)rdr["Rate"];
                    data.CessPercentage = (decimal)rdr["CessPercentage"];
                    data.CGST = rdr["CGST"] == System.DBNull.Value ? 0 : (decimal)rdr["CGST"];
                    data.SGST = rdr["SGST"] == System.DBNull.Value ? 0 : (decimal)rdr["SGST"];
                    data.IGST = rdr["IGST"] == System.DBNull.Value ? 0 : (decimal)rdr["IGST"];
                    data.Cess = rdr["Cess"] == System.DBNull.Value ? 0 : (decimal)rdr["Cess"];
                    data.TotalTax = (decimal)rdr["TotalTax"];
                    data.TotalInvoiceValue = (decimal)rdr["TotalInvoiceValue"];
                    data.Month = rdr["Month"].ToString() ?? string.Empty;
                    data.Year = rdr["Year"].ToString() ?? string.Empty;

                    model.advanceReceivedList.Add(data);
                }
                con.Close();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FinalOutputRegisterListModel> GetFOPDocumentPreview(string month, string year)
        {
            //try
            //{
            //    var model = new FinalOutputRegisterListModel();
            //    model.finalOutputRegistersList = new List<FinalOutputRegisterViewModel>();

            //    DataSet ds = new DataSet();
            //    SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());

            //    SqlCommand cmd = new SqlCommand("prc_Get_Liability_Data ", con)
            //    {
            //        CommandType = CommandType.StoredProcedure
            //    };
            //    cmd.Parameters.Add(new SqlParameter("@Month", month));
            //    cmd.Parameters.Add(new SqlParameter("@Year", year));

            //    con.Open();

            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            //    DataTable dataTable = new DataTable();
            //    adapter.Fill(ds);
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {


            //        model.finalOutputRegistersList.Add(data);
            //    }
            //    con.Close();
            //    return model;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(_context.Database.GetConnectionString());
                var model = new FinalOutputRegisterListModel();
                model.finalOutputRegistersList = new List<FinalOutputRegisterViewModel>();
                SqlCommand cmd = new SqlCommand("Prc_Get_Preview_Final_Output_Register_KSAA_Template", con)
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
                        var data = new FinalOutputRegisterViewModel();
                        data.Id = (long)dataTable.Rows[i]["Id"];
                        data.Document_Type = (string)dataTable.Rows[i]["Document_Type"];
                        data.Invoice_Number = dataTable.Rows[i]["Invoice_Number"].ToString() ?? string.Empty; ;
                        //data.InvoiceDate = dataTable.Rows[i]["InvoiceDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["InvoiceDate"];
                        data.Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["Invoice_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Invoice_No = dataTable.Rows[i]["E_Invoice_No"].ToString() ?? string.Empty; ;
                        //data.EInvoiceDate = dataTable.Rows[i]["EInvoiceDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EInvoiceDate"];
                        data.E_Invoice_Date = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Invoice_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Invoice_Total_Amount = dataTable.Rows[i]["E_Invoice_Total_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Total_Amount"];
                        data.E_Invoice_Tax_Amount = dataTable.Rows[i]["E_Invoice_Tax_Amount"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Tax_Amount"];
                        data.E_Invoice_Amount_Different = dataTable.Rows[i]["E_Invoice_Amount_Different"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["E_Invoice_Amount_Different"];
                        data.E_Invoice_Tax_Different = (decimal)dataTable.Rows[i]["E_Invoice_Tax_Different"];
                        //data.EInvoiceAmountDifferent = dataTable.Rows[i]["EInvoiceAmountDifferent"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["EInvoiceAmountDifferent"];
                        data.Shipping_Bill_No = dataTable.Rows[i]["Shipping_Bill_No"].ToString() ?? string.Empty; ;
                        //data.ShippingBillDate = dataTable.Rows[i]["ShippingBillDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["ShippingBillDate"];
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
                        //data.Rate = (string)dataTable.Rows[i]["Rate"];
                        data.Rate = dataTable.Rows[i]["Rate"] == System.DBNull.Value ? 0 : (decimal)dataTable.Rows[i]["Rate"];
                        //data.Total_Tax = (decimal)dataTable.Rows[i]["Total_Tax"];
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
                        //data.AccountingDate = dataTable.Rows[i]["AccountingDate"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["AccountingDate"];
                        data.Accounting_Date = Convert.ToDateTime(dataTable.Rows[i]["Accounting_Date"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["Accounting_Date"]).ToString(DateTimeFormat.StandardDateTime);
                        data.Location_Code = (string)dataTable.Rows[i]["Location_Code"];
                        data.GL_Code = (string)dataTable.Rows[i]["GL_Code"];
                        data.E_Invoice_No_2 = (string)dataTable.Rows[i]["E_Invoice_No_2"];
                        //data.EInvoiceDate2 = dataTable.Rows[i]["EInvoiceDate2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EInvoiceDate2"];
                        data.E_Invoice_Date_2 = Convert.ToDateTime(dataTable.Rows[i]["E_Invoice_Date_2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["E_Invoice_Date_2"]).ToString(DateTimeFormat.StandardDateTime);
                        data.E_Way_Bill_No_2 = (string)dataTable.Rows[i]["E_Way_Bill_No_2"];
                        //data.EWayDate2 = dataTable.Rows[i]["EWayDate2"] == System.DBNull.Value ? null : (DateTime)dataTable.Rows[i]["EWayDate2"];
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
    }
}