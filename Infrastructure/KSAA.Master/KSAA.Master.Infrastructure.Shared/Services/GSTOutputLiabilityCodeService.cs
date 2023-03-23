using AutoMapper;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Entities;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Features.Master.Commands.GSTOutputLiabilityCodesCommand;
using KSAA.Master.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSAA.Master.Application.DTOs.Master.ListDTOs;

namespace KSAA.Master.Infrastructure.Shared.Services
{
	public class GSTOutputLiabilityCodeService : IGSTOutputLiabilityCodesService
    {
        private readonly IGenericRepositoryAsync<GSTOutputLiabilityCodes> _GSTOutputLiabilityCodesRepositoryAsync;
        private readonly IMapper _mapper;

        public GSTOutputLiabilityCodeService(IGenericRepositoryAsync<GSTOutputLiabilityCodes> GSTOutputLiabilityCodesRepositoryAsync, IMapper mapper)
        {
            _GSTOutputLiabilityCodesRepositoryAsync = GSTOutputLiabilityCodesRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<GSTOutputLiabilityCodesViewModel> AddGSTOutputLiabilityCodes(CreateGSTOutputLiabilityCodesCommand command)
        {
            var applicationGSTOutputLiabilityCodes = _mapper.Map<GSTOutputLiabilityCodes>(command);
            applicationGSTOutputLiabilityCodes.CreatedOn = DateTime.Now;
            applicationGSTOutputLiabilityCodes.IsActive = IsActive.Active;
            await _GSTOutputLiabilityCodesRepositoryAsync.AddAsync(applicationGSTOutputLiabilityCodes);

            return _mapper.Map<GSTOutputLiabilityCodesViewModel>(applicationGSTOutputLiabilityCodes);
        }

        public async Task DeleteGSTOutputLiabilityCodes(DeleteGSTOutputLiabilityCodesCommand command)
        {
            if (command.Id > 0)
            {
                var applicationGSTOutputLiabilityCodes = await _GSTOutputLiabilityCodesRepositoryAsync.FindById(command.Id);
                applicationGSTOutputLiabilityCodes.IsActive = IsActive.Delete;
                await _GSTOutputLiabilityCodesRepositoryAsync.UpdateAsync(applicationGSTOutputLiabilityCodes);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<GSTOutputLiabilityCodesViewModel> EditGSTOutputLiabilityCodes(UpdateGSTOutputLiabilityCodesCommand command)
        {
            var applicationGSTOutputLiabilityCodes = _mapper.Map<UpdateGSTOutputLiabilityCodesCommand>(command);
            applicationGSTOutputLiabilityCodes.IsActive = IsActive.Active;
            applicationGSTOutputLiabilityCodes.ModifiedOn = DateTime.Now;
            var applicationUser = await _GSTOutputLiabilityCodesRepositoryAsync.FindById(applicationGSTOutputLiabilityCodes.Id);
            _mapper.Map(command, applicationUser);

            await _GSTOutputLiabilityCodesRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<GSTOutputLiabilityCodesViewModel>(applicationUser);
        }

        public async Task<GSTOutputLiabilityCodesViewModel> GetGSTOutputLiabilityCodesById(long id)
        {
            var applicationGSTOutputLiabilityCodes = await _GSTOutputLiabilityCodesRepositoryAsync.FindById(id);
            return _mapper.Map<GSTOutputLiabilityCodesViewModel>(applicationGSTOutputLiabilityCodes);
        }

        public async Task<IEnumerable<GSTOutputLiabilityCodesListModel>> GetGSTOutputLiabilityCodesList()
        {
            var AdvanceMappingList = await _GSTOutputLiabilityCodesRepositoryAsync.GetAllAsync();
            //GSTOutputLiabilityCodesList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<GSTOutputLiabilityCodesViewModel>>(GSTOutputLiabilityCodesList).Where(x => x.IsActive != IsActive.Delete);

            var AdvanceMappings = AdvanceMappingList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new GSTOutputLiabilityCodesListModel()
                {
                    Id = y.Id,
                    CustomerCode = y.CustomerCode,
                    GLLiabilityName = y.GLLiabilityName,
                    GLLiabilityCode = y.GLLiabilityCode,
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