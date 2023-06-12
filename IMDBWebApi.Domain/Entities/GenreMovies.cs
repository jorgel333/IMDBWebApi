using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class GenreMovies : Entity
    {
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
