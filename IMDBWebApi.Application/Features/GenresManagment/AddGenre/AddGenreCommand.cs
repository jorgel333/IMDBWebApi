using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.AddGenre;

public record AddGenreCommand(string Name) : IRequest<Result<AddGenreCommandResponse>>;
