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

namespace KSAA.Master.Application.Features.Master.Queries.FunctionModuleQueries
{
    public class GetAllFunctionModuleQuery : IRequest<Response<IEnumerable<FunctionModuleListModel>>>
    {
    }

    public class GetAllFunctionModuleQueryHandler : IRequestHandler<GetAllFunctionModuleQuery, Response<IEnumerable<FunctionModuleListModel>>>
    {
        private readonly IFunctionModuleService _functionModuleService;
        private readonly IMapper _mapper;

        public GetAllFunctionModuleQueryHandler(IFunctionModuleService functionModuleService, IMapper mapper)
        {
            _functionModuleService = functionModuleService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<FunctionModuleListModel>>> Handle(GetAllFunctionModuleQuery request, CancellationToken cancellationToken)
        {
            var functionList = await _functionModuleService.GetFunctionModuleList();
            return new Response<IEnumerable<FunctionModuleListModel>>(functionList);
        }
    }
}
