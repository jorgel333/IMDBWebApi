using FluentResults;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.GetAllGenres;

public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, Result<IEnumerable<GetAllGenresQueryResponse>>>
{
    private readonly IGenreRepository _genreRepository;

    public GetAllGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Result<IEnumerable<GetAllGenresQueryResponse>>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _genreRepository.GetAll(cancellationToken);

        if (genres.Any() is false)
            return Result.Ok(Enumerable.Empty<GetAllGenresQueryResponse>());

        return Result.Ok(genres.Select(g => new GetAllGenresQueryResponse(g.Id, g.Name!)));
    }
}
