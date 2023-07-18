using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.DeleteMovie;
public record DeleteMovieCommand(int Id) : IRequest<Result>;
    

