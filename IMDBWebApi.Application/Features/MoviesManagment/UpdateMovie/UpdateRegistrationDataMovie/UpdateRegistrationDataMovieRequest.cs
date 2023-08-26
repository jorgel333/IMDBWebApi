namespace IMDBWebApi.Application.Features.MoviesManagment.UpdateMovie.UpdateRegistrationDataMovie;

public record UpdateRegistrationDataMovieRequest(string Name,
    string Description,
    int Duration,
    DateTime ReleaseDate,
    IEnumerable<int> Genres,
    IEnumerable<int> CastActors,
    IEnumerable<int> CastDirectors);
