using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
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
    public class GetAllClientManagingDirectorQuery : IRequest<Response<IEnumerable<ClientManagingDirectorListModel>>>
    {
    }

    public class GetAllClientManagingDirectorQueryHandler : IRequestHandler<GetAllClientManagingDirectorQuery, Response<IEnumerable<ClientManagingDirectorListModel>>>
    {
        private readonly IClientManagingDirectorService _ClientManagingDirectorService;
        private readonly IMapper _mapper;

        public GetAllClientManagingDirectorQueryHandler(IClientManagingDirectorService ClientManagingDirectorService, IMapper mapper)
        {
            _ClientManagingDirectorService = ClientManagingDirectorService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ClientManagingDirectorListModel>>> Handle(GetAllClientManagingDirectorQuery request, CancellationToken cancellationToken)
        {
            var ClientManagingDirectorServiceList = await _ClientManagingDirectorService.GetClientManagingDirectorList();

            return new Response<IEnumerable<ClientManagingDirectorListModel>>(ClientManagingDirectorServiceList);
        }
    }
}
