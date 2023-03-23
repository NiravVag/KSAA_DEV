using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Repositories
{
    public interface IComparisonReportRepositoryAsync
    {
        Task<ComparisonReportSLEInvoiceListModel> GetComparisonReportSheetSLEInvoiceAsync(string month, string year,string action);
        Task<ComparisonReportSLEWayListModel> GetComparisonReportSheetSLEWayAsync(string month, string year,string action);
        Task<ComparisonReportSLEInvoiceListModel> GenComparisonSheetSLEInvoice(string month, string year);
        Task<ComparisonReportSLEWayListModel> UpdateComparisonSheetSLEWay(string month, string year);
        Task<HttpResponseMessage> UpdateSLEInvoiceAction(string action, int id, string updateType, int year);
        Task<HttpResponseMessage> UpdateSLEWayAction(string action, int id, string updateType, int year);
        Task<List<CompairsonReportsSLEInvoiceEWay>> GetPreviewSLDocumentList(string month, string year,string action);
    }
}
