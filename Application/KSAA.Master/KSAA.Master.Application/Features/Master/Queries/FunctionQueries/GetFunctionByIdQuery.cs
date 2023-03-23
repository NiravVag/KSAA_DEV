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

namespace KSAA.Master.Application.Features.Master.Queries.FunctionQueries
{
    public class GetFunctionByIdQuery : IRequest<Response<FunctionViewModel>>
    {
        public int Id { get; set; }
    }
    public class GetFunctionByIdQueryByHandler : IRequestHandler<GetFunctionByIdQuery, Response<FunctionViewModel>>
    {
        private readonly IFunctionService _functionService;
        private readonly IMapper _mapper;

        public GetFunctionByIdQueryByHandler(IFunctionService functionService, IMapper mapper)
        {
            _functionService = functionService;
            _mapper = mapper;
        }
        public async Task<Response<FunctionViewModel>> Handle(GetFunctionByIdQuery request, CancellationToken cancellationToken)
        {
            var functionById = await _functionService.GetFunctionById(request.Id);
            return new Response<FunctionViewModel>(functionById);
        }
    }
}
