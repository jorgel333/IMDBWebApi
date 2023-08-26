using IMDBWebApi.Application.Features.Cast.Create;
using IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDBWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly ISender _sender;

        public CastsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IResult> CreateCast(CreateCastCommand request,CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
