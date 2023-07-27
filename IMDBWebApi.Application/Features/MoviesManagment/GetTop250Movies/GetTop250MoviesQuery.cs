using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetTop250Movies;

public record GetTop250MoviesQuery() : IRequest<Result<IEnumerable<GetTop205MoviesQueryResponse>>>;
