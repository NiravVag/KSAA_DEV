using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientManagingDirectorQueries
{
    public class GetClientManagingDirectorByIdQuery : IRequest<Response<ClientManagingDirectorViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetClientManagingDirectorByIdQueryHandler : IRequestHandler<GetClientManagingDirectorByIdQuery, Response<ClientManagingDirectorViewModel>>
    {
        private readonly IClientManagingDirectorService _ClientManagingDirectorService;
        private readonly IMapper _mapper;

        public GetClientManagingDirectorByIdQueryHandler(IClientManagingDirectorService ClientManagingDirectorService, IMapper mapper)
        {
            _ClientManagingDirectorService = ClientManagingDirectorService;
            _mapper = mapper;
        }
        public async Task<Response<ClientManagingDirectorViewModel>> Handle(GetClientManagingDirectorByIdQuery request, CancellationToken cancellationToken)
        {
            var getClientAuthorizedSignatoryById = await _ClientManagingDirectorService.GetClientManagingDirectorById(request.Id);
            return new Response<ClientManagingDirectorViewModel>(getClientAuthorizedSignatoryById);
        }
    }
}