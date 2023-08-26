using IMDBWebApi.Application.Features.MoviesManagment.GetMovieDetails;
using IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;
using IMDBWebApi.Application.Features.MoviesManagment.AddMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IMDBWebApi.Application.Features.MoviesManagment.GetNextReleases;
using IMDBWebApi.Application.Features.MoviesManagment.GetTop250Movies;
using IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdateRegistrationData;
using IMDBWebApi.Application.Features.MoviesManagment.UpdateMovie.UpdateRegistrationDataMovie;
using IMDBWebApi.Application.Features.MoviesManagment.GetMovieByGenre;
using IMDBWebApi.Application.Features.MoviesManagment.DeleteMovie;

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

        [HttpGet("top250")]
        public async Task<IResult> GetTop250(CancellationToken cancellationToken)
        {
            var request = new GetTop250MoviesQuery();
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
        [HttpGet("next-releases")]
        public async Task<IResult> GetNextReleases(CancellationToken cancellationToken)
        {
            var request = new GetNextReleasesQuery();
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpGet("{id:int}/movie-details")]
        public async Task<IResult> GetMovieDetails(int id, CancellationToken cancellationToken)
        {
            var request = new GetMovieDetailsQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpGet("{id:int}/by-genre")]
        public async Task<IResult> GetByGenre(int id, CancellationToken cancellationToken)
        {
            var request = new GetMoviesByGenreQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IResult> CreateMovie(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IResult> UpdateMovie(int id, UpdateRegistrationDataMovieRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateRegistrationDataMovieCommand(id, request.Name, request.Description, request.Duration,
                request.ReleaseDate, request.Genres, request.CastActors, request.CastDirectors);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IResult> DeleteMovie(int id, CancellationToken cancellationToken)
        {
            var request = new DeleteMovieCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
