using AutoMapper;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.OutputRegister.Queries
{
    public class GetOutputRegisterQuery : IRequest<Response<List<OutputRegisterViewModel>>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetOutputRegisterQueryHandler : IRequestHandler<GetOutputRegisterQuery, Response<List<OutputRegisterViewModel>>>
    {
        private readonly IOutputRegisterService _outputRegisterService;
        private readonly IMapper _mapper;

        public GetOutputRegisterQueryHandler(IOutputRegisterService outputRegisterService, IMapper mapper)
        {
            _outputRegisterService = outputRegisterService;
            _mapper = mapper;
        }

        public async Task<Response<List<OutputRegisterViewModel>>> Handle(GetOutputRegisterQuery request, CancellationToken cancellationToken)
        {
            var outputRegisterGrid = await _outputRegisterService.GetOutputRegisterGrid(request.Month, request.Year);
            return new Response<List<OutputRegisterViewModel>>(outputRegisterGrid);
        }
    }
}
