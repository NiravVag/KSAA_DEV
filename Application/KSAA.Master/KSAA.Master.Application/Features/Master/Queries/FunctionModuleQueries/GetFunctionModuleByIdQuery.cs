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

namespace KSAA.Master.Application.Features.Master.Queries.FunctionModuleQueries
{
    public class GetFunctionModuleByIdQuery : IRequest<Response<FunctionModuleViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetFunctionModuleByIdQueryHandler : IRequestHandler<GetFunctionModuleByIdQuery, Response<FunctionModuleViewModel>>
    {
        private readonly IFunctionModuleService _functionModuleService;
        private readonly IMapper _mapper;

        public GetFunctionModuleByIdQueryHandler(IFunctionModuleService functionModuleService, IMapper mapper)
        {
            _functionModuleService = functionModuleService;
            _mapper = mapper;
        }
        public async Task<Response<FunctionModuleViewModel>> Handle(GetFunctionModuleByIdQuery request, CancellationToken cancellationToken)
        {
            var functionById = await _functionModuleService.GetFunctionModuleById(request.Id);
            return new Response<FunctionModuleViewModel>(functionById);
        }
    }
}
