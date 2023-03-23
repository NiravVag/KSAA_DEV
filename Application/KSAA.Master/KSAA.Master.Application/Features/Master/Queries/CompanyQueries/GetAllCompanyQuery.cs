using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
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
    public class GetAllCompanyQuery : IRequest<Response<IEnumerable<CompanyListModel>>>
    {
    }

    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, Response<IEnumerable<CompanyListModel>>>
    {
        private readonly ICompanyService _CompanyService;
        private readonly IMapper _mapper;

        public GetAllCompanyQueryHandler(ICompanyService CompanyService, IMapper mapper)
        {
            _CompanyService = CompanyService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<CompanyListModel>>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var CompanyList = await _CompanyService.GetCompanyList();

            return new Response<IEnumerable<CompanyListModel>>(CompanyList);
        }
    }
}
