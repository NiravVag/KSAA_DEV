using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand;
using KSAA.Master.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Shared.Services
{
    public class GLIncome_MappingService : IGLIncome_MappingService
    {
        private readonly IGenericRepositoryAsync<GLIncome_Mapping> _GLIncome_MappingRepositoryAsync;
        private readonly IMapper _mapper;

        public GLIncome_MappingService(IGenericRepositoryAsync<GLIncome_Mapping> GLIncome_MappingRepositoryAsync, IMapper mapper)
        {
            _GLIncome_MappingRepositoryAsync = GLIncome_MappingRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<GLIncome_MappingViewModel> AddGLIncome_Mapping(CreateGLIncome_MappingCommand command)
        {
            var applicationGLIncome_Mapping = _mapper.Map<GLIncome_Mapping>(command);
            applicationGLIncome_Mapping.CreatedOn = DateTime.Now;
            applicationGLIncome_Mapping.IsActive = IsActive.Active;
            await _GLIncome_MappingRepositoryAsync.AddAsync(applicationGLIncome_Mapping);

            return _mapper.Map<GLIncome_MappingViewModel>(applicationGLIncome_Mapping);
        }

        public async Task DeleteGLIncome_Mapping(DeleteGLIncome_MappingCommand command)
        {
            if (command.Id > 0)
            {
                var applicationGLIncome_Mapping = await _GLIncome_MappingRepositoryAsync.FindById(command.Id);
                applicationGLIncome_Mapping.IsActive = IsActive.Delete;
                await _GLIncome_MappingRepositoryAsync.UpdateAsync(applicationGLIncome_Mapping);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<GLIncome_MappingViewModel> EditGLIncome_Mapping(UpdateGLIncome_MappingCommand command)
        {
            var applicationGLIncome_Mapping = _mapper.Map<UpdateGLIncome_MappingCommand>(command);
            applicationGLIncome_Mapping.IsActive = IsActive.Active;
            applicationGLIncome_Mapping.ModifiedOn = DateTime.Now;
            var applicationUser = await _GLIncome_MappingRepositoryAsync.FindById(applicationGLIncome_Mapping.Id);
            _mapper.Map(command, applicationUser);

            await _GLIncome_MappingRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<GLIncome_MappingViewModel>(applicationUser);
        }

        public async Task<GLIncome_MappingViewModel> GetGLIncome_MappingById(long id)
        {
            var applicationGLIncome_Mapping = await _GLIncome_MappingRepositoryAsync.FindById(id);
            return _mapper.Map<GLIncome_MappingViewModel>(applicationGLIncome_Mapping);
        }

        public async Task<IEnumerable<GLIncome_MappingListModel>> GetGLIncome_MappingList()
        {
            var GLIncomeMappingList = await _GLIncome_MappingRepositoryAsync.GetAllAsync();
            //GLIncome_MappingList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<GLIncome_MappingViewModel>>(GLIncome_MappingList).Where(x => x.IsActive != IsActive.Delete);

            var glIncomeMappings = GLIncomeMappingList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new GLIncome_MappingListModel()
                {
                    Id = y.Id,
                    GLIncomeCode = y.GLIncomeCode,
                    GLIncomeDescription = y.GLIncomeDescription,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return glIncomeMappings;

        }
    }
}
