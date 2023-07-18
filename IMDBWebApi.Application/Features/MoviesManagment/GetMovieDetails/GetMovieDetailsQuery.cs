using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetMovieDetails;

public record GetMovieDetailsQuery(int Id): IRequest<Result<GetMovieDetailsQueryResponse>>;
