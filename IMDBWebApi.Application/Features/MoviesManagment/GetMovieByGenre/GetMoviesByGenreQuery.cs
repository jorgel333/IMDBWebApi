using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetMovieByGenre;

public record GetMoviesByGenreQuery(int GenreId) : IRequest<Result<IEnumerable<GetMoviesByGenreQueryResponse>>>;
