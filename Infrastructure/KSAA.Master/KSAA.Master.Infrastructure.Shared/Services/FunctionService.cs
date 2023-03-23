using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.FunctionMaster;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.FunctionCommand;
using KSAA.Master.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Shared.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IGenericRepositoryAsync<Functions> _functionRepositoryAsync;
        private readonly IMapper _mapper;

        public FunctionService(IGenericRepositoryAsync<Functions> functionRepositoryAsync, IMapper mapper)
        {
            _functionRepositoryAsync = functionRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<FunctionViewModel> AddFunction(CreateFunctionCommand command)
        {
            var applicationFunction = _mapper.Map<Functions>(command);
            applicationFunction.IsActive = IsActive.Active;
            applicationFunction.CreatedBy = applicationFunction.CreatedBy;
            applicationFunction.CreatedOn = DateTime.Now;
            applicationFunction.ModifiedBy = applicationFunction.ModifiedBy;
            applicationFunction.ModifiedOn = DateTime.Now;
            await _functionRepositoryAsync.AddAsync(applicationFunction);

            return _mapper.Map<FunctionViewModel>(applicationFunction);
        }

        public async Task DeleteFunction(DeleteFunctionCommand command)
        {
            if (command.Id > 0)
            {
                var applicationFunction = await _functionRepositoryAsync.FindById(command.Id);
                applicationFunction.IsActive = IsActive.Delete;
                applicationFunction.ModifiedBy = applicationFunction.ModifiedBy;
                await _functionRepositoryAsync.UpdateAsync(applicationFunction);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<FunctionViewModel> EditFunction(UpdateFunctionCommand command)
        {
            var applicationFunction = _mapper.Map<UpdateFunctionCommand>(command);
            applicationFunction.IsActive = IsActive.Active;
            applicationFunction.ModifiedBy = applicationFunction.ModifiedBy;
            applicationFunction.ModifiedOn = DateTime.Now;
            var applicationUser = await _functionRepositoryAsync.FindById(applicationFunction.Id);
            _mapper.Map(command, applicationUser);

            await _functionRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<FunctionViewModel>(applicationUser);
        }

        public async Task<FunctionViewModel> GetFunctionById(long id)
        {
            var applicationFunction = await _functionRepositoryAsync.FindById(id);
            return _mapper.Map<FunctionViewModel>(applicationFunction);
        }

        public async Task<IEnumerable<FunctionListModel>> GetFunctionList()
        {
            var functionList = await _functionRepositoryAsync.GetAllAsync();
            //functionList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<FunctionViewModel>>(functionList).Where(x => x.IsActive != IsActive.Delete);

            var functions = functionList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new FunctionListModel()
                {
                    Id = y.Id,
                    FunctionCode = y.FunctionCode,
                    FunctionName = y.FunctionName,
                    ClientCode = y.ClientCode,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return functions;
        }
    }
}
