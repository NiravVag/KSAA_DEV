using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface ICustomerCodeService
    {
        Task<CustomerCodeViewModel> AddCustomerCode(CreateCustomerCodeCommand command);

        Task<CustomerCodeViewModel> EditCustomerCode(UpdateCustomerCodeCommand command);

        Task<IEnumerable<CustomerCodeListModel>> GetCustomerCodeList();

        Task<CustomerCodeViewModel> GetCustomerCodeById(long id);

        Task DeleteCustomerCode(DeleteCustomerCodeCommand command);
    }
}
