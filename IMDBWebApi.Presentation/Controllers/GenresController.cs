using IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;
using IMDBWebApi.Application.Features.GenresManagment.AddGenre;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace IMDBWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ISender _sender;

        public GenresController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IResult> CreateGenre(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
