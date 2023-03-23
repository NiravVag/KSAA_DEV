using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Commands.TaxCodeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface ITaxCodeService
    {
        Task<TaxCodeViewModel> AddTaxCode(CreateTaxCodeCommand command);

        Task<TaxCodeViewModel> EditTaxCode(UpdateTaxCodeCommand command);

        Task<IEnumerable<TaxCodeListModel>> GetTaxCodeList();

        Task<TaxCodeViewModel> GetTaxCodeById(long id);

        Task DeleteTaxCode(DeleteTaxCodeCommand command);
    }
}