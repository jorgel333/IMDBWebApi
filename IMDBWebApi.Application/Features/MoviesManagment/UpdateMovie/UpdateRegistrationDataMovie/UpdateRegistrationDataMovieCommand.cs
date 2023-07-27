using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.UpdateMovie.UpdateRegistrationDataMovie;

public record UpdateRegistrationDataMovieCommand(int MovieId,
    string Name,
    string Description,
    int Duration,
    DateTime ReleaseDate,
    IEnumerable<int> Genres,
    IEnumerable<int> CastActors,
    IEnumerable<int> CastDirectors) : IRequest<Result>;
