using IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdateRegistrationData;
using IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdatePassword;
using IMDBWebApi.Application.Features.Administrator.Account.Disable;
using IMDBWebApi.Application.Features.Administrator.Account.Create;
using IMDBWebApi.Application.Features.Administrator.Account.Login;
using IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;
using IMDBWebApi.Application.Features.Administrator.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace IMDBWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ISender _sender;

        public AdminsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}", Name = "GetByAdmId")]
        public async Task<IResult> GetAdmById(int id, CancellationToken cancellationToken)
        {
            var request = new GetAdmByIdQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost]
        public async Task<IResult> CreateAdmAccount(CreateAccountAdmCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.CreatedAtRoute(result, "GetByAdmId", new {id = result.Value.Id}, result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DisableAdmAccount(int id, CancellationToken cancellationToken)
        {
            var request = new DisableAccountAdmCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id}/update-password")]
        public async Task<IResult> UpdatePasswordAdmAccount(int id, UpdatePasswordAdmRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdatePasswordAdmCommand(id, request.Password, request.ConfirmPassword);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id}/update-registration-data")]
        public async Task<IResult> UpdateregistrationDataAdmAccount(int id, UpdateRegistrationDataAdmRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateRegistrationDataAdmCommand(id, request.Name, request.UserName,
                request.Email, request.BirthDay);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost("login")]
        public async Task<IResult> LoginAdm(LoginAccountAdmCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
