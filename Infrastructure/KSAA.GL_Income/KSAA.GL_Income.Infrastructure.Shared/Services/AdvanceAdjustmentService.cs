using AutoMapper;
using KSAA.Domain.Entities.AdvanceRecAdj;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Queries;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Shared.Services
{
    public class AdvanceAdjustmentService : IAdvanceAdjustmentService
    {
        private readonly IAdvanceAdjustmentRepositoryAsync _advanceAdjustmentServiceRepositoryAsync;
        private readonly IGenericRepositoryAsync<AdvanceAdjustment> _genericRepositoryAsync;
        private readonly IMapper _mapper;

        public AdvanceAdjustmentService(IAdvanceAdjustmentRepositoryAsync advanceAdjustmentServiceRepositoryAsync, 
            IGenericRepositoryAsync<AdvanceAdjustment> genericRepositoryAsync,
            IMapper mapper)
        {
            _advanceAdjustmentServiceRepositoryAsync = advanceAdjustmentServiceRepositoryAsync;
            _genericRepositoryAsync = genericRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<AdvanceAdjustmentViewModel>> GetAdvanceAdjustmentList(string month, string year)
        {
            var listAdvanceAdjustment = await _advanceAdjustmentServiceRepositoryAsync.GetAdvanceAdjustmentAsync(month, year);
            return listAdvanceAdjustment;
        }

        public async Task<AdvanceAdjustmentViewModel> GetAdvanceAdjustmentById(long id, string month, string year)
        {
            //Step-1
            //AdvanceAdjustmentTagReceiptModel advSL = new AdvanceAdjustmentTagReceiptModel();
            //advSL.getAdvanceAdjustment = new AdvanceAdjustmentViewModel();
            //advSL.getSLRegisterData = new List<OutputRegisterViewModel>();

            //Step-2 Get Adv Rec Details
            ///advSL.getAdvanceAdjustment = await _advanceAdjustmentServiceRepositoryAsync.GetAdjustmentAmendmentById(id, month, year);
            var getAdvanceAdjustment = await _advanceAdjustmentServiceRepositoryAsync.GetAdjustmentAmendmentById(id, month, year);

            //Step-3 Get Invoice Details
            //advSL.getSLRegisterData = await _advanceAdjustmentServiceRepositoryAsync.GetSLInvoiceList(month, year);
            //var getSLRegisterData = await _advanceAdjustmentServiceRepositoryAsync.GetSLInvoiceList(month, year);

            //return advSL;

            return getAdvanceAdjustment;
        }

        public async Task<IEnumerable<OutputRegisterViewModel>> GetSLInvoiceList(string month, string year)
        {
            var getSLRegisterData = await _advanceAdjustmentServiceRepositoryAsync.GetSLInvoiceList(month, year);
            return getSLRegisterData;
        }

        public async Task<AdvanceAdjustmentTagReceiptModel> AddTagInvoiceById(AddTagInvoiceByIdCommand command)
        {
            var getSLRegisterData = await _advanceAdjustmentServiceRepositoryAsync.AddTagInvoiceById(command);
            return getSLRegisterData;
        }

        public async Task<OutputRegisterViewModel> GetSLInvoiceDetailById(long id, string month, string year)
        {
            var getSLInvoiceDetail = await _advanceAdjustmentServiceRepositoryAsync.GetSLInvoiceDetailById(id, month, year);
            return getSLInvoiceDetail;
        }
    }
}
