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

namespace KSAA.Master.Application.Features.Master.Queries.FunctionQueries
{
    public class GetAllFunctionQuery : IRequest<Response<IEnumerable<FunctionListModel>>>
    {
    }
    public class GetAllFunctionQueryHandler : IRequestHandler<GetAllFunctionQuery, Response<IEnumerable<FunctionListModel>>>
    {
        private readonly IFunctionService _functionService;
        private readonly IMapper _mapper;

        public GetAllFunctionQueryHandler(IFunctionService functionService, IMapper mapper)
        {
            _functionService = functionService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<FunctionListModel>>> Handle(GetAllFunctionQuery request, CancellationToken cancellationToken)
        {
            var functionList = await _functionService.GetFunctionList();

            return new Response<IEnumerable<FunctionListModel>>(functionList);
        }
    }
}

