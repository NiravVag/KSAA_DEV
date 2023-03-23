using AutoMapper;
using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.FinalOutputRegister.Queries
{
    public class ExportFinalOutputQuery : IRequest<Response<FinalOutputRegisterListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class ExportFinalOutputQueryHandler : IRequestHandler<ExportFinalOutputQuery, Response<FinalOutputRegisterListModel>>
    {
        private readonly IFinalOutputRegisterService _finalOutputRegisterService;
        private readonly IMapper _mapper;

        public ExportFinalOutputQueryHandler(IFinalOutputRegisterService finalOutputRegisterService, IMapper mapper)
        {
            _finalOutputRegisterService = finalOutputRegisterService;
            _mapper = mapper;
        }

        public async Task<Response<FinalOutputRegisterListModel>> Handle(ExportFinalOutputQuery request, CancellationToken cancellationToken)
        {
            var finaloutputRegister = await _finalOutputRegisterService.ExportFinalOutputRegister(request.Month, request.Year);
            return new Response<FinalOutputRegisterListModel>(finaloutputRegister);
        }
    }
}