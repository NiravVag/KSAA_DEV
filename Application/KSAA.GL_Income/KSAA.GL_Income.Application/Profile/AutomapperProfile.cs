using AutoMapper;
using KSAA.Domain.Entities.AdvanceRecAdj;
using KSAA.Domain.Entities.FinalOutputRegister;
using KSAA.Domain.Entities.GL_Income;
using KSAA.Domain.Entities.OutputRegister;
using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ComparisonReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            
            CreateMap<GL_IncomeData, GL_IncomeViewModel>()
                .ForMember(x => x.Income_Booking_Resp_GL_ID, opt => opt.MapFrom(x => x.Income_Booking_Resp_GL_ID))
                .ReverseMap();

            CreateMap<GenComparisonSheetCommand, ComparisonReportSLEInvoice>();
            CreateMap<ComparisonReportSLEInvoice, ComparisonReportSLEInvoiceViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();
            CreateMap<UpdateComparisonSheetCommand, ComparisonReportSLEWay>();
            CreateMap<ComparisonReportSLEWay, ComparisonReportSLEInvoiceViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<ComparisonReportSLEInvoice, ComparisonReportSLEInvoiceViewModel>()
                .ForMember(x => x.E_Invoice_Bill_No, opt => opt.MapFrom(x => x.E_Invoice_Bill_No))
                .ForMember(x => x.E_invoice_Bill_Date, opt => opt.MapFrom(x => x.E_invoice_Bill_Date))
                .ForMember(x => x.Invoice_Number, opt => opt.MapFrom(x => x.Invoice_Number))
                .ForMember(x => x.Invoice_Date, opt => opt.MapFrom(x => x.Invoice_Date))
                .ForMember(x => x.Invoice_Value, opt => opt.MapFrom(x => x.Invoice_Value))
                .ForMember(x => x.Taxable_Value_E_Invoice, opt => opt.MapFrom(x => x.Taxable_Value_E_Invoice))
                .ForMember(x => x.Total_Tax_E_Invoice, opt => opt.MapFrom(x => x.Total_Tax_E_Invoice))
                .ForMember(x => x.Invoice_Number_SL, opt => opt.MapFrom(x => x.Invoice_Number_SL))
                .ForMember(x => x.Invoice_Date_SL, opt => opt.MapFrom(x => x.Invoice_Date_SL))
                .ForMember(x => x.Taxable_Value_SL, opt => opt.MapFrom(x => x.Taxable_Value_SL))
                .ForMember(x => x.Total_Tax_SL, opt => opt.MapFrom(x => x.Total_Tax_SL))
                .ForMember(x => x.Taxable_Value_Diff_Invoice, opt => opt.MapFrom(x => x.Taxable_Value_Diff_Invoice))
                .ForMember(x => x.Tax_Value_Diff_Invoice, opt => opt.MapFrom(x => x.Tax_Value_Diff_Invoice))
                .ForMember(x => x.Tax_Value_Diff_Invoice, opt => opt.MapFrom(x => x.Tax_Value_Diff_Invoice))
                .ForMember(x => x.Remarks_E_Invoice, opt => opt.MapFrom(x => x.Remarks_E_Invoice))
                .ForMember(x => x.Actions_E_Invoice, opt => opt.MapFrom(x => x.Actions_E_Invoice))
                .ReverseMap();

            CreateMap<ComparisonReportSLEWay, ComparisonReportSLEWayViewModel>()
                .ForMember(x => x.E_way_Bill_No, opt => opt.MapFrom(x => x.E_way_Bill_No))
                .ForMember(x => x.E_way_Bill_Date, opt => opt.MapFrom(x => x.E_way_Bill_Date))
                .ForMember(x => x.E_Way_Invoice_Number, opt => opt.MapFrom(x => x.E_Way_Invoice_Number))
                .ForMember(x => x.E_Way_Invoice_Date, opt => opt.MapFrom(x => x.E_Way_Invoice_Date))
                .ForMember(x => x.Invoice_Value_E_Way, opt => opt.MapFrom(x => x.Invoice_Value_E_Way))
                .ForMember(x => x.E_Way_Taxable_Value, opt => opt.MapFrom(x => x.E_Way_Taxable_Value))
                .ForMember(x => x.E_Way_Total, opt => opt.MapFrom(x => x.E_Way_Total))
                .ForMember(x => x.Taxable_Value_Diff_E_Way, opt => opt.MapFrom(x => x.Taxable_Value_Diff_E_Way))
                .ForMember(x => x.Tax_Value_Diff_E_Way, opt => opt.MapFrom(x => x.Tax_Value_Diff_E_Way))
                .ForMember(x => x.Remarks_E_Way, opt => opt.MapFrom(x => x.Remarks_E_Way))
                .ForMember(x => x.Actions_E_Way, opt => opt.MapFrom(x => x.Actions_E_Way))
                .ReverseMap();

            CreateMap<AdvanceReceived, AdvanceReceivedListModule>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<AddReceivedAmendmentByIdCommand, AdvanceAmendment>();
            CreateMap<AdvanceAmendment, AdvanceAmendmentViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<OutputRegister, OutputRegisterViewModel>()
               .ForMember(x => x.DocumentType, opt => opt.MapFrom(x => x.DocumentType))
               .ForMember(x => x.InvoiceNumber, opt => opt.MapFrom(x => x.InvoiceNumber))
               .ForMember(x => x.InvoiceDate, opt => opt.MapFrom(x => x.InvoiceDate))
               .ForMember(x => x.E_InvoiceNo, opt => opt.MapFrom(x => x.E_InvoiceNo))
               .ForMember(x => x.EInvoiceDate, opt => opt.MapFrom(x => x.EInvoiceDate))
               .ForMember(x => x.EInvoiceTotalAmount, opt => opt.MapFrom(x => x.EInvoiceTotalAmount))
               .ForMember(x => x.EInvoiceTaxAmount, opt => opt.MapFrom(x => x.EInvoiceTaxAmount))
               .ForMember(x => x.EInvoiceAmountDifferent, opt => opt.MapFrom(x => x.EInvoiceAmountDifferent))
               .ForMember(x => x.EInvoiceTaxDifferent, opt => opt.MapFrom(x => x.EInvoiceTaxDifferent))
               .ForMember(x => x.ShippingBillNo, opt => opt.MapFrom(x => x.ShippingBillNo))
               .ForMember(x => x.ShippingBillDate, opt => opt.MapFrom(x => x.ShippingBillDate))
               .ForMember(x => x.HSNCode, opt => opt.MapFrom(x => x.HSNCode))
               .ForMember(x => x.Quantity, opt => opt.MapFrom(x => x.Quantity))
               .ForMember(x => x.UniqueQuantityCode, opt => opt.MapFrom(x => x.UniqueQuantityCode))
               .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
               .ForMember(x => x.PartyName, opt => opt.MapFrom(x => x.PartyName))
               .ForMember(x => x.GSTIN, opt => opt.MapFrom(x => x.GSTIN))
               .ForMember(x => x.ReverseCharge, opt => opt.MapFrom(x => x.ReverseCharge))
               .ForMember(x => x.PlaceOfSupplyStateName, opt => opt.MapFrom(x => x.PlaceOfSupplyStateName))
               .ForMember(x => x.Exchange_RateAsPerNotifications, opt => opt.MapFrom(x => x.Exchange_RateAsPerNotifications))
               .ForMember(x => x.Exchange_Rate_As_Per_Shipping_Bill, opt => opt.MapFrom(x => x.Exchange_Rate_As_Per_Shipping_Bill))
               .ForMember(x => x.TaxableValue, opt => opt.MapFrom(x => x.TaxableValue))
               .ForMember(x => x.Rate, opt => opt.MapFrom(x => x.Rate))
               .ForMember(x => x.TotalTax, opt => opt.MapFrom(x => x.TotalTax))
               .ForMember(x => x.CentralTax, opt => opt.MapFrom(x => x.CentralTax))
               .ForMember(x => x.StateUTTax, opt => opt.MapFrom(x => x.StateUTTax))
               .ForMember(x => x.IntegratedTax, opt => opt.MapFrom(x => x.IntegratedTax))
               .ForMember(x => x.CessAmount, opt => opt.MapFrom(x => x.CessAmount))
               .ForMember(x => x.TotalInvoiceValue_Rs, opt => opt.MapFrom(x => x.TotalInvoiceValue_Rs))
               .ForMember(x => x.VehicleNo, opt => opt.MapFrom(x => x.VehicleNo))
               .ForMember(x => x.EWayBillNo, opt => opt.MapFrom(x => x.EWayBillNo))
               .ForMember(x => x.DispatchLocationCode, opt => opt.MapFrom(x => x.DispatchLocationCode))
               .ForMember(x => x.PortCode, opt => opt.MapFrom(x => x.PortCode))
               .ForMember(x => x.VoucherNo, opt => opt.MapFrom(x => x.VoucherNo))
               .ForMember(x => x.AccountingDate, opt => opt.MapFrom(x => x.AccountingDate))
               .ForMember(x => x.LocationCode, opt => opt.MapFrom(x => x.LocationCode))
               .ForMember(x => x.GL_Code, opt => opt.MapFrom(x => x.GL_Code))
               .ForMember(x => x.EInvoiceNo2, opt => opt.MapFrom(x => x.EInvoiceNo2))
               .ForMember(x => x.EInvoiceDate2, opt => opt.MapFrom(x => x.EInvoiceDate2))
               .ForMember(x => x.EWayBillNo2, opt => opt.MapFrom(x => x.EWayBillNo2))
               .ForMember(x => x.EWayDate2, opt => opt.MapFrom(x => x.EWayDate2))
               .ReverseMap();

            CreateMap<AdvanceAdjustment, AdvanceAdjustmentViewModel>()
                //.ForMember(x => x.AdvanceReceivedId, opt => opt.MapFrom(x => x.AdvanceReceivedId))
                .ForMember(x => x.ClientCode, opt => opt.MapFrom(x => x.ClientCode))
                .ForMember(x => x.EmployeeCode, opt => opt.MapFrom(x => x.EmployeeCode))
                .ForMember(x => x.InvoiceNumber, opt => opt.MapFrom(x => x.InvoiceNumber))
                .ForMember(x => x.ReceiptNumber, opt => opt.MapFrom(x => x.ReceiptNumber))
                .ForMember(x => x.Dateofadjustment, opt => opt.MapFrom(x => x.Dateofadjustment))
                .ForMember(x => x.GSTIN, opt => opt.MapFrom(x => x.GSTIN))
                .ForMember(x => x.POS, opt => opt.MapFrom(x => x.POS))
                .ForMember(x => x.Typeofsupply, opt => opt.MapFrom(x => x.Typeofsupply))
                .ForMember(x => x.TaxableValue, opt => opt.MapFrom(x => x.TaxableValue))
                .ForMember(x => x.Rate, opt => opt.MapFrom(x => x.Rate))
                .ForMember(x => x.CessPercentage, opt => opt.MapFrom(x => x.CessPercentage))
                .ForMember(x => x.CGST, opt => opt.MapFrom(x => x.CGST))
                .ForMember(x => x.SGST, opt => opt.MapFrom(x => x.SGST))
                .ForMember(x => x.IGST, opt => opt.MapFrom(x => x.IGST))
                .ForMember(x => x.Cess, opt => opt.MapFrom(x => x.Cess))
                .ForMember(x => x.TotalTax, opt => opt.MapFrom(x => x.TotalTax))
                .ForMember(x => x.TotalreceiptValue, opt => opt.MapFrom(x => x.TotalreceiptValue))
                .ReverseMap();
        }
    }
}
