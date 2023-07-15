using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.AddMovie;

public record AddMovieCommand (string Name, string Description,
    int Duration, string Image, DateTime RealiseDate,
    IEnumerable<int> Genres, IEnumerable<int> CastActor,
    IEnumerable<int> CastDirector) :IRequest<Result<AddMovieCommandResponse>>;

