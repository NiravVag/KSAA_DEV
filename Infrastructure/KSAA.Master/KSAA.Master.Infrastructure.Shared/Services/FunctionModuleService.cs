using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.FunctionModuleCommand;
using KSAA.Master.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Shared.Services
{
    public class FunctionModuleService : IFunctionModuleService
    {
        private readonly IGenericRepositoryAsync<FunctionModule> _functionModuleRepositoryAsync;
        private readonly IMapper _mapper;

        public FunctionModuleService(IGenericRepositoryAsync<FunctionModule> functionModuleRepositoryAsync, IMapper mapper)
        {
            _functionModuleRepositoryAsync = functionModuleRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<FunctionModuleViewModel> AddFunctionModule(CreateFunctionModuleCommand command)
        {
            var applicationFunctionModule = _mapper.Map<FunctionModule>(command);
            applicationFunctionModule.IsActive = IsActive.Active;
            applicationFunctionModule.CreatedBy = applicationFunctionModule.CreatedBy;
            applicationFunctionModule.CreatedOn = DateTime.Now;
            applicationFunctionModule.ModifiedBy = applicationFunctionModule.ModifiedBy;
            applicationFunctionModule.ModifiedOn = DateTime.Now;
            await _functionModuleRepositoryAsync.AddAsync(applicationFunctionModule);

            return _mapper.Map<FunctionModuleViewModel>(applicationFunctionModule);
        }

        public async Task DeleteFunctionModule(DeleteFunctionModuleCommand command)
        {
            if (command.Id > 0)
            {
                var applicationFunctionModule = await _functionModuleRepositoryAsync.FindById(command.Id);
                applicationFunctionModule.IsActive = IsActive.Delete;
                applicationFunctionModule.ModifiedBy = applicationFunctionModule.ModifiedBy;
                await _functionModuleRepositoryAsync.UpdateAsync(applicationFunctionModule);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<FunctionModuleViewModel> EditFunctionModule(UpdateFunctionModuleCommand command)
        {
            var applicationFunctionModule = _mapper.Map<UpdateFunctionModuleCommand>(command);
            applicationFunctionModule.IsActive = IsActive.Active;
            applicationFunctionModule.ModifiedBy = applicationFunctionModule.ModifiedBy;
            applicationFunctionModule.ModifiedOn = DateTime.Now;
            var applicationUser = await _functionModuleRepositoryAsync.FindById(applicationFunctionModule.Id);
            _mapper.Map(command, applicationUser);

            await _functionModuleRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<FunctionModuleViewModel>(applicationUser);
        }

        public async Task<FunctionModuleViewModel> GetFunctionModuleById(long id)
        {
            var applicationFunction = await _functionModuleRepositoryAsync.FindById(id);
            return _mapper.Map<FunctionModuleViewModel>(applicationFunction);
        }

        public async Task<IEnumerable<FunctionModuleListModel>> GetFunctionModuleList()
        {
            var functionModuleList = _functionModuleRepositoryAsync.GetAllQueryable();
            var functions=await functionModuleList.Where(x=>x.IsActive!=IsActive.Delete)
                .Select(y=>new FunctionModuleListModel()
                {
                    Id = y.Id,
                    FunctionId = y.FunctionId,
                    FunctionName = y.Function.FunctionName,
                    ModuleName = y.ModuleName,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).AsNoTracking().ToListAsync();
            return functions;
        }
    }
}
