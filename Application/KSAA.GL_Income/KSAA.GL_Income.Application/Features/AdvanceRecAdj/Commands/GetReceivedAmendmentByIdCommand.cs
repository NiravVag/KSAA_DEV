using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands
{
    public class GetReceivedAmendmentByIdCommand : IRequest<Response<HttpResponseMessage>>
    {
        public long Id { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class AddReceivedAmendmentCommandHandler : IRequestHandler<GetReceivedAmendmentByIdCommand, Response<HttpResponseMessage>>
    {
        private readonly IAdvaceReceivedService _advaceReceivedService;

        public AddReceivedAmendmentCommandHandler(IAdvaceReceivedService advaceReceivedService)
        {
            _advaceReceivedService = advaceReceivedService;
        }
        public async Task<Response<HttpResponseMessage>> Handle(GetReceivedAmendmentByIdCommand request, CancellationToken cancellationToken)
        {
            var addReceivedAmendment = await _advaceReceivedService.AddReceivedAmendment(request);
            return new Response<HttpResponseMessage>(addReceivedAmendment);
        }
    }
}
