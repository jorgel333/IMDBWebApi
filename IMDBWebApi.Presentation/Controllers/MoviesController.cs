using IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;
using IMDBWebApi.Application.Features.MoviesManagment.AddMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IMDBWebApi.Application.Features.MoviesManagment.GetMovieDetails;

namespace IMDBWebApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ISender _sender;

        public MoviesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:int}/movies-details")]
        public async Task<IResult> GetMoviesDetails(int id, CancellationToken cancellationToken)
        {
            var request = new GetMovieDetailsQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> CreateMovie(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
