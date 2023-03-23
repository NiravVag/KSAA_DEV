using KSAA.Domain.Entities.GL_Income;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ComparisonReport;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Shared.Services
{
    public class ComparisonReportService : IComparisonReportService
    {
        private readonly IComparisonReportRepositoryAsync _comparisonReportRepositoryAsync;
        private readonly IGenericRepositoryAsync<ComparisonReportSLEInvoice> _comparisonReportSLEInvoiceRepository;
        private readonly IGenericRepositoryAsync<ComparisonReportSLEWay> _comparisonReportSLEWayRepository;

        public ComparisonReportService(IComparisonReportRepositoryAsync comparisonReportRepositoryAsync, 
            IGenericRepositoryAsync<ComparisonReportSLEInvoice> comparisonReportSLEInvoiceRepository,
            IGenericRepositoryAsync<ComparisonReportSLEWay> comparisonReportSLEWayRepository)
        {
            _comparisonReportRepositoryAsync = comparisonReportRepositoryAsync;
            _comparisonReportSLEInvoiceRepository = comparisonReportSLEInvoiceRepository;
            _comparisonReportSLEWayRepository = comparisonReportSLEWayRepository;
        }

        public async Task<ComparisonReportSLEInvoiceListModel> GetComparisonReportSheetSLEInvoice(string month, string year, string action)
        {
            var slComparisonReportSheet = await _comparisonReportRepositoryAsync.GetComparisonReportSheetSLEInvoiceAsync(month, year, action);
            return slComparisonReportSheet;
        }
        public async Task<ComparisonReportSLEInvoiceListModel> GenComparisonSheetSLEInvoice(GenComparisonSheetCommand command)
        {
            var genComparisonSheet = await _comparisonReportRepositoryAsync.GenComparisonSheetSLEInvoice(command.Month, command.Year);
            return genComparisonSheet;
        }


        public async Task<ComparisonReportSLEWayListModel> GetComparisonReportSheetSLEWay(string month, string year, string action)
        {
            var slComparisonReportSheetEWay = await _comparisonReportRepositoryAsync.GetComparisonReportSheetSLEWayAsync(month, year, action);
            return slComparisonReportSheetEWay;
        }
        public async Task<ComparisonReportSLEWayListModel> UpdateComparisonSheetSLEWay(UpdateComparisonSheetCommand command)
        {
            var updateComparisonSheet = await _comparisonReportRepositoryAsync.UpdateComparisonSheetSLEWay(command.Month, command.Year);
            return updateComparisonSheet;
        }

        public async Task<HttpResponseMessage> UpdateSLEInvoiceAction(UpdateSLEInvoiceActionCommand command)
        {
            var updateComparisonSheet = await _comparisonReportRepositoryAsync.UpdateSLEInvoiceAction(command.Action, command.Id, command.UpdateType, command.Year);
            return updateComparisonSheet;
        }

        public async Task<HttpResponseMessage> UpdateSLEWayAction(UpdateSLEWayActionCommand command)
        {
            var updateComparisonSheet = await _comparisonReportRepositoryAsync.UpdateSLEWayAction(command.Action, command.Id, command.UpdateType, command.Year);
            return updateComparisonSheet;
        }

        public async Task<List<CompairsonReportsSLEInvoiceEWay>> GetPreviewSLDocumentList(string month, string year, string action)
        {
            var previewSLDocumentReport = await _comparisonReportRepositoryAsync.GetPreviewSLDocumentList(month, year, action);
            return previewSLDocumentReport;
        }

    }
}
