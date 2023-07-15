using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class CastActMovies : Entity
    {
        public int MovieActId { get; set; }
        public Movie? MovieAct { get; set; }
        public int CastActId { get; set; }
        public Cast? CastAct { get; set; }
    }
}
