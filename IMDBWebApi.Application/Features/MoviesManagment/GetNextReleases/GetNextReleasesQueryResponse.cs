namespace IMDBWebApi.Application.Features.MoviesManagment.GetNextReleases;

public record GetNextReleasesQueryResponse(
    int Id, 
    string Name,
    double RatingAverage,
    DateTime ReleaseDate,
    IEnumerable<string> Genres,
    IEnumerable<string> Actors, 
    IEnumerable<string> Directors);