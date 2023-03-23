using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand;
using KSAA.Master.Application.Interfaces.Repositories;
using KSAA.Master.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Shared.Services
{
    public class CustomerCodeService : ICustomerCodeService
    {
        private readonly IGenericRepositoryAsync<CustomerCode> _CustomerCodeRepositoryAsync;
        private readonly IMapper _mapper;

        public CustomerCodeService(IGenericRepositoryAsync<CustomerCode> CustomerCodeRepositoryAsync, IMapper mapper)
        {
            _CustomerCodeRepositoryAsync = CustomerCodeRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<CustomerCodeViewModel> AddCustomerCode(CreateCustomerCodeCommand command)
        {
            var applicationCustomerCode = _mapper.Map<CustomerCode>(command);
            applicationCustomerCode.CreatedOn = DateTime.Now;
            applicationCustomerCode.IsActive = IsActive.Active;
            await _CustomerCodeRepositoryAsync.AddAsync(applicationCustomerCode);

            return _mapper.Map<CustomerCodeViewModel>(applicationCustomerCode);
        }

        public async Task DeleteCustomerCode(DeleteCustomerCodeCommand command)
        {
            if (command.Id > 0)
            {
                var applicationCustomerCode = await _CustomerCodeRepositoryAsync.FindById(command.Id);
                applicationCustomerCode.IsActive = IsActive.Delete;
                await _CustomerCodeRepositoryAsync.UpdateAsync(applicationCustomerCode);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<CustomerCodeViewModel> EditCustomerCode(UpdateCustomerCodeCommand command)
        {
            var applicationCustomerCode = _mapper.Map<UpdateCustomerCodeCommand>(command);
            applicationCustomerCode.IsActive = IsActive.Active;
            applicationCustomerCode.ModifiedOn = DateTime.Now;
            var applicationUser = await _CustomerCodeRepositoryAsync.FindById(applicationCustomerCode.Id);
            _mapper.Map(command, applicationUser);

            await _CustomerCodeRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<CustomerCodeViewModel>(applicationUser);
        }

        public async Task<CustomerCodeViewModel> GetCustomerCodeById(long id)
        {
            var applicationCustomerCode = await _CustomerCodeRepositoryAsync.FindById(id);
            return _mapper.Map<CustomerCodeViewModel>(applicationCustomerCode);
        }

        public async Task<IEnumerable<CustomerCodeListModel>> GetCustomerCodeList()
        {
            var CustomerCodeList = await _CustomerCodeRepositoryAsync.GetAllAsync();
            //CustomerCodeList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<CustomerCodeViewModel>>(CustomerCodeList).Where(x => x.IsActive != IsActive.Delete);

            var customerCodes = CustomerCodeList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new CustomerCodeListModel()
                {
                    Id = y.Id,
                    Customer_Code = y.Customer_Code,
                    GSTN = y.GSTN,
                    Name = y.Name,
                    Location = y.Location,
                    Address = y.Address,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return customerCodes;

        }
    }
}