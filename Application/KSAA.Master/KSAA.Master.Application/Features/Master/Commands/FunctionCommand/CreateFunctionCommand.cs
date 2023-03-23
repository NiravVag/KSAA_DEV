using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.FunctionCommand
{
    public class CreateFunctionCommand : IRequest<Response>
    {
        [Required]
        public string? FunctionName { get; set; }
        [Required]
        public string? FunctionCode { get; set; }
        [Required]
        public string? ClientCode { get; set; }

        /*public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }*/
    }
    public class CreateFunctionCommandHandler : IRequestHandler<CreateFunctionCommand, Response>
    {
        private readonly IFunctionService _functionService;
        public CreateFunctionCommandHandler(IFunctionService functionService)
        {
            _functionService = functionService;
        }
        public async Task<Response> Handle(CreateFunctionCommand request, CancellationToken cancellationToken)
        {
            var documentObject = await _functionService.AddFunction(request);
            return new Response("Function Add Successfully");
        }
    }
}
