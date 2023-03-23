using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Queries.CompanyQueries
{
    public class GetCompanyByIdQuery : IRequest<Response<CompanyViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Response<CompanyViewModel>>
    {
        private readonly ICompanyService _CompanyService;
        private readonly IMapper _mapper;

        public GetCompanyByIdQueryHandler(ICompanyService CompanyService, IMapper mapper)
        {
            _CompanyService = CompanyService;
            _mapper = mapper;
        }
        public async Task<Response<CompanyViewModel>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var getPlantCodeById = await _CompanyService.GetCompanyById(request.Id);
            return new Response<CompanyViewModel>(getPlantCodeById);
        }
    }
}