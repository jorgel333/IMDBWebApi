using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.AddMovie;

public record AddMovieCommand (string Name, string Description,
    int Duration, string Image, DateTime RealiseDate,
    ICollection<int> Genres, ICollection<int> CastActor,
    ICollection<int> CastDirector) :IRequest<Result<AddMovieCommandResponse>>;

