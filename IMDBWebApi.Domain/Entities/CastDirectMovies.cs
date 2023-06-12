using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class CastDirectMovies : Entity
    {
        public int MovieId { get; set; }
        public Movie? DitectorMovie { get; set; }
        public int CastDirectorId { get; set; }
        public Cast? CastDirector { get; set; }
    }
}