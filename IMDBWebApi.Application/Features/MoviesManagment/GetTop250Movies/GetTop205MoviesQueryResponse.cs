namespace IMDBWebApi.Application.Features.MoviesManagment.GetTop250Movies;

public record GetTop205MoviesQueryResponse(
    int Id, 
    string Name, 
    double RatingAverage,
    IEnumerable<string> Genres, 
    IEnumerable<string> Actors, 
    IEnumerable<string> Directors);