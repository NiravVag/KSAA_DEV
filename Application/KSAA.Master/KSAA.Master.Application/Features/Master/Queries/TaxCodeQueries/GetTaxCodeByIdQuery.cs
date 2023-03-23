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

namespace KSAA.Master.Application.Features.Master.Queries.TaxCodeQueries
{
    public class GetTaxCodeByIdQuery : IRequest<Response<TaxCodeViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetTaxCodeByIdQueryHandler : IRequestHandler<GetTaxCodeByIdQuery, Response<TaxCodeViewModel>>
    {
        private readonly ITaxCodeService _taxCodeService;
        private readonly IMapper _mapper;

        public GetTaxCodeByIdQueryHandler(ITaxCodeService taxCodeService, IMapper mapper)
        {
            _taxCodeService = taxCodeService;
            _mapper = mapper;
        }
        public async Task<Response<TaxCodeViewModel>> Handle(GetTaxCodeByIdQuery request, CancellationToken cancellationToken)
        {
            var getPlantCodeById = await _taxCodeService.GetTaxCodeById(request.Id);
            return new Response<TaxCodeViewModel>(getPlantCodeById);
        }
    }
}
