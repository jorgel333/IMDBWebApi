using IMDBWebApi.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class CastActMovies : Entity
    {
        public int MovieId { get; private set; }
        public Movie? ActMovie { get; private set; }
        public int CastActId { get; private set; }
        public Cast? CastAct { get; private set; }
    }
}
