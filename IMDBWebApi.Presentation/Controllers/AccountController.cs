using IMDBWebApi.Application.Features.Administrator.Account.Create;
using IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;
using IMDBWebApi.Application.Features.Administrator.GetById;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IMDBWebApi.Application.Features.Administrator.Account.Disable;

namespace IMDBWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IResult> GetById(int id, CancellationToken cancellationToken)
        {
            var request = new GetAdmByIdQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost]
        public async Task<IResult> CreateAdm(CreateAccountAdmCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.CreatedAtRoute(result, "GetById", result.Value.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DisableAdm(DisableAccountAdmCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
