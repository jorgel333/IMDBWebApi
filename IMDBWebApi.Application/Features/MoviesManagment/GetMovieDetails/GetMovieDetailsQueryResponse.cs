namespace IMDBWebApi.Application.Features.MoviesManagment.GetMovieDetails;

public record GetMovieDetailsQueryResponse(
    int MovieId,
    string Name,
    string Description,
    int Duration,
    int TotalVotes,
    double RatingAverage,
    string Image,
    IEnumerable<string> Actors,
    IEnumerable<string> Directors,
    IEnumerable<string> Genres);