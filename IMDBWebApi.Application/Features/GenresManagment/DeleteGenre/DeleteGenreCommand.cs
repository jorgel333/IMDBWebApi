using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.DeleteGenre;

public record DeleteGenreCommand(int GnereId) : IRequest<Result>;
