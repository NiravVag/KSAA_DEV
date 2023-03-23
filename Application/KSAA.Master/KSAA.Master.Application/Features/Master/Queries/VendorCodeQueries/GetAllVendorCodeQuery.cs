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

namespace KSAA.Master.Application.Features.Master.Queries.VendorCodeQueries
{
    public class GetAllVendorCodeQuery : IRequest<Response<IEnumerable<VendorCodeListModel>>>
    {
    }

    public class GetAllVendorCodeQueryHandler : IRequestHandler<GetAllVendorCodeQuery, Response<IEnumerable<VendorCodeListModel>>>
    {
        private readonly IVendorCodeService _VendorCodeService;
        private readonly IMapper _mapper;

        public GetAllVendorCodeQueryHandler(IVendorCodeService VendorCodeService, IMapper mapper)
        {
            _VendorCodeService = VendorCodeService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<VendorCodeListModel>>> Handle(GetAllVendorCodeQuery request, CancellationToken cancellationToken)
        {
            var VendorCodeList = await _VendorCodeService.GetVendorCodeList();

            return new Response<IEnumerable<VendorCodeListModel>>(VendorCodeList);
        }
    }
}