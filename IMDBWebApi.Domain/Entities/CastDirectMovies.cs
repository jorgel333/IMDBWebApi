using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class CastDirectMovies : Entity
    {
        public int MovieDirectId { get; set; }
        public Movie? MovieDirect { get; set; }
        public int CastDirectorId { get; set; }
        public Casts? CastDirector { get; set; }
    }
}