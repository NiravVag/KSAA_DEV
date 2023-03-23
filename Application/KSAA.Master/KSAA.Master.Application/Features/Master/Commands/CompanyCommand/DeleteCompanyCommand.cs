using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.CompanyCommand
{
    public class DeleteCompanyCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyService _CompanyService;
        public DeleteCompanyCommandHandler(ICompanyService CompanyService)
        {
            _CompanyService = CompanyService;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await _CompanyService.DeleteCompany(request);
            return Unit.Value;

        }
    }
}