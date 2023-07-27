namespace IMDBWebApi.Application.Features.MoviesManagment.GetMovieByGenre;

public record GetMoviesByGenreQueryResponse(
    int Id, 
    string Name, 
    double RatingAverage, 
    IEnumerable<string> Genres,
    IEnumerable<string> Actors, 
    IEnumerable<string> Directors);