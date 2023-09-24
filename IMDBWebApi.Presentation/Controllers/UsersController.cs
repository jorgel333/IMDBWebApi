using IMDBWebApi.Application.Features.Users.Account.Edit.RegistrationData;
using IMDBWebApi.Application.Features.Users.Account.Edit.Password;
using IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;
using IMDBWebApi.Application.Features.Users.Account.Create;
using IMDBWebApi.Application.Features.CommonUser.Disable;
using IMDBWebApi.Application.Features.CommonUser.Login;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace IMDBWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;

        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IResult> CreateUser(CreateAccountUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost("login")]
        public async Task<IResult> LoginUser(LoginAccountUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id:int}/update-user-password")]
        public async Task<IResult> UpdatePasswordUserAccount(int id, UpdatePasswordAccountUserRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdatePasswordAccountUserCommand(id, request.Password, request.ConfirmPassword);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id:int}/update-user-registration-data")]
        public async Task<IResult> UpdateregistrationDataUserAccount(int id, UpdateRegistrationDataUserRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateRegistrationDataAccountUserCommand(id, request.Name, request.UserName,
                request.Email, request.BirthDay);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IResult> DisableUserAccount(int id, CancellationToken cancellationToken)
        {
            var request = new DisableAccountUserCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
