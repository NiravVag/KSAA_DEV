using AutoMapper;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Entities;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Features.Master.Commands.AdvanceMappingCommand;
using KSAA.Master.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSAA.Master.Application.DTOs.Master.ListDTOs;

namespace KSAA.Master.Infrastructure.Shared.Services
{
	public class AdvanceMappingService : IAdvanceMappingService
    {
        private readonly IGenericRepositoryAsync<AdvanceMapping> _AdvanceMappingRepositoryAsync;
        private readonly IMapper _mapper;

        public AdvanceMappingService(IGenericRepositoryAsync<AdvanceMapping> AdvanceMappingRepositoryAsync, IMapper mapper)
        {
            _AdvanceMappingRepositoryAsync = AdvanceMappingRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<AdvanceMappingViewModel> AddAdvanceMapping(CreateAdvanceMappingCommand command)
        {
            var applicationAdvanceMapping = _mapper.Map<AdvanceMapping>(command);
            applicationAdvanceMapping.CreatedOn = DateTime.Now;
            applicationAdvanceMapping.IsActive = Domain.Entities.IsActive.Active;
            await _AdvanceMappingRepositoryAsync.AddAsync(applicationAdvanceMapping);

            return _mapper.Map<AdvanceMappingViewModel>(applicationAdvanceMapping);
        }

        public async Task DeleteAdvanceMapping(DeleteAdvanceMappingCommand command)
        {
            if (command.Id > 0)
            {
                var applicationAdvanceMapping = await _AdvanceMappingRepositoryAsync.FindById(command.Id);
                applicationAdvanceMapping.IsActive = Domain.Entities.IsActive.Delete;
                await _AdvanceMappingRepositoryAsync.UpdateAsync(applicationAdvanceMapping);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<AdvanceMappingViewModel> EditAdvanceMapping(UpdateAdvanceMappingCommand command)
        {
            var applicationAdvanceMapping = _mapper.Map<UpdateAdvanceMappingCommand>(command);
            applicationAdvanceMapping.IsActive = Domain.Entities.IsActive.Active;
            applicationAdvanceMapping.ModifiedOn = DateTime.Now;
            var applicationUser = await _AdvanceMappingRepositoryAsync.FindById(applicationAdvanceMapping.Id);
            _mapper.Map(command, applicationUser);

            await _AdvanceMappingRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<AdvanceMappingViewModel>(applicationUser);
        }

        public async Task<AdvanceMappingViewModel> GetAdvanceMappingById(long id)
        {
            var applicationAdvanceMapping = await _AdvanceMappingRepositoryAsync.FindById(id);
            return _mapper.Map<AdvanceMappingViewModel>(applicationAdvanceMapping);
        }

        public async Task<IEnumerable<AdvanceMappingListModel>> GetAdvanceMappingList()
        {
            var AdvanceMappingList = await _AdvanceMappingRepositoryAsync.GetAllAsync();
            //AdvanceMappingList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<AdvanceMappingViewModel>>(AdvanceMappingList).Where(x => x.IsActive != IsActive.Delete);

            var AdvanceMappings = AdvanceMappingList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new AdvanceMappingListModel()
                {
                    Id = y.Id,
                    CustomerCode = y.CustomerCode,
                    AdvanceMappingCode = y.AdvanceMappingCode,
                    GLAdvanceName = y.GLAdvanceName,
                    GLAdvanceCode = y.GLAdvanceCode,
                    LedgerMapping = y.LedgerMapping,
                    //Upload = y.Upload,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return AdvanceMappings;

        }
    }
}