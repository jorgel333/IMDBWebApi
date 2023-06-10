using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class CastDirectMovies : Entity
    {
        public Guid MovieId { get; set; }
        public Movie? DitectorMovie { get; set; }
        public Guid CastDirectorId { get; set; }
        public Cast? CastDirector { get; set; }
    }
}