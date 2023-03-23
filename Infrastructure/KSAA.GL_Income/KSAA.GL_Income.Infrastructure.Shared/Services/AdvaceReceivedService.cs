using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.AdvanceRecAdj;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.Master.Application.DTOs.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Shared.Services
{
    public class AdvaceReceivedService : IAdvaceReceivedService
    {
        private readonly IAdvaceReceivedRepositoryAsync _advanceReceivedRepositoryAsync;
        private readonly IGenericRepositoryAsync<AdvanceReceived> _advanceReceivedGenericRepositoryAsync;
        private readonly IGenericRepositoryAsync<AdvanceAmendment> _advanceAmendmentRepositoryAsync;
        private readonly IMapper _mapper;
        public AdvaceReceivedService(IAdvaceReceivedRepositoryAsync advanceReceivedRepositoryAsync, 
            IGenericRepositoryAsync<AdvanceReceived> advanceReceivedGenericRepositoryAsync,
            IGenericRepositoryAsync<AdvanceAmendment> advanceAmendmentRepositoryAsync, 
            IMapper mapper)
        {
            _advanceReceivedRepositoryAsync = advanceReceivedRepositoryAsync;
            _advanceReceivedGenericRepositoryAsync = advanceReceivedGenericRepositoryAsync;
            _advanceAmendmentRepositoryAsync = advanceAmendmentRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<AdvanceReceivedListModule> GetAdvaceReceivedModuleList(string month, string year)
        {
            var advanceReceivedList = await _advanceReceivedRepositoryAsync.GetAdvaceReceivedModuleList(month, year);
            return advanceReceivedList;
        }

        public async Task<CommonRequestViewModel> GetAdvReceivedMonthYearList()
        {
            var monthyearList = await _advanceReceivedGenericRepositoryAsync.GetAllAsync();
            var months = monthyearList.Select(x => x.Month).Distinct().ToList();
            var years = monthyearList.Select(x => x.Year).Distinct().ToList();

            return new CommonRequestViewModel()
            {
                Months = months,
                Years = years
            };
        }

        public async Task<HttpResponseMessage> AddReceivedAmendment(GetReceivedAmendmentByIdCommand command)
        {
            var updateComparisonSheet = await _advanceReceivedRepositoryAsync.AddReceivedAmendment(command.Id, command.Month, command.Year);
            return updateComparisonSheet;
        }

        public async Task<AdvanceAmendmentViewModel> AddReceivedAmendmentById(AddReceivedAmendmentByIdCommand command)
        {
            var addReceivedAmendment = _mapper.Map<AdvanceAmendment>(command);
            addReceivedAmendment.IsActive = IsActive.Active;
            addReceivedAmendment.CreatedBy = addReceivedAmendment.CreatedBy;
            addReceivedAmendment.CreatedOn = DateTime.Now;
            addReceivedAmendment.ModifiedBy = addReceivedAmendment.ModifiedBy;
            addReceivedAmendment.ModifiedOn = DateTime.Now;
            await _advanceAmendmentRepositoryAsync.AddAsync(addReceivedAmendment);
            
            //if (command.AdvanceReceivedId > 0)
            //{
            //    var updateAdvanceReceived = await _advanceReceivedGenericRepositoryAsync.FindByIdAsync(command.AdvanceReceivedId.ToString());
            //    await _advanceReceivedRepositoryAsync.UpdateAdvanceReceivedById(command.AdvanceReceivedId, command.Month, command.Year);
            //}

            var updateAdvanceReceived = await _advanceReceivedRepositoryAsync.UpdateAdvanceReceivedById(command.AdvanceReceivedId,command.Month, command.Year);

            return _mapper.Map<AdvanceAmendmentViewModel>(addReceivedAmendment);
        }

        public async Task<List<AdvanceAmendmentViewModel>> GetPreviewAddAmendmentByIdList(long id, string month, string year)
        {
            var previewAddAmendment = await _advanceReceivedRepositoryAsync.GetPreviewAddAmendmentByIdList(id, month, year);
            return previewAddAmendment;
        }
    }
}
