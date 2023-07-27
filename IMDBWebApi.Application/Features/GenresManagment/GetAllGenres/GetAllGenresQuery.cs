using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.GetAllGenres;


public record GetAllGenresQuery() : IRequest<Result<IEnumerable<GetAllGenresQueryResponse>>>;
