using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.GSTR;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ComparisonReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Services
{
    public interface IComparisonReportService
    {
        Task<ComparisonReportSLEInvoiceListModel> GetComparisonReportSheetSLEInvoice(string month, string year, string action);
        Task<ComparisonReportSLEWayListModel> GetComparisonReportSheetSLEWay(string month, string year, string action);
        Task<ComparisonReportSLEInvoiceListModel> GenComparisonSheetSLEInvoice(GenComparisonSheetCommand command);
        Task<ComparisonReportSLEWayListModel> UpdateComparisonSheetSLEWay(UpdateComparisonSheetCommand command);
        Task<HttpResponseMessage> UpdateSLEInvoiceAction(UpdateSLEInvoiceActionCommand command);
        Task<HttpResponseMessage> UpdateSLEWayAction(UpdateSLEWayActionCommand command);
        Task<List<CompairsonReportsSLEInvoiceEWay>> GetPreviewSLDocumentList(string month, string year, string action);
    }
}
