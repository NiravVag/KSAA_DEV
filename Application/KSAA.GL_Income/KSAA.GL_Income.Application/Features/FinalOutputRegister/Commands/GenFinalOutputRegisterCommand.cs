using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.FinalOutputRegister.Commands
{
    public class GenFinalOutputRegisterCommand : IRequest<Response<FinalOutputRegisterListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GenFinalOutputRegisterCommandHandler : IRequestHandler<GenFinalOutputRegisterCommand, Response<FinalOutputRegisterListModel>>
    {
        private readonly IFinalOutputRegisterService _finalOutputRegister;

        public GenFinalOutputRegisterCommandHandler(IFinalOutputRegisterService finalOutputRegister)
        {
            _finalOutputRegister = finalOutputRegister;
        }
        public async Task<Response<FinalOutputRegisterListModel>> Handle(GenFinalOutputRegisterCommand request, CancellationToken cancellationToken)
        {
            var comparisonGen = await _finalOutputRegister.GenFinalOutputRegister(request);
            return new Response<FinalOutputRegisterListModel>(comparisonGen);
        }
    }
}