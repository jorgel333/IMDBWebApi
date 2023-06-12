using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class CastActMovies : Entity
    {
        public int MovieActId { get; private set; }
        public Movie? MovieAct { get; private set; }
        public int CastActId { get; private set; }
        public Cast? CastAct { get; private set; }
    }
}
