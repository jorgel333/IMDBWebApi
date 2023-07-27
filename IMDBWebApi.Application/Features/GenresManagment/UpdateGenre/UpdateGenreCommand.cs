using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.UpdateGenre;

public record UpdateGenreCommand(int GenreId, string Name) : IRequest<Result>;
    
    

