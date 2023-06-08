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
        public Guid MovieId { get; set; }
        public Movie? ActMovie { get; set; }
        public Guid CastActId { get; set; }
        public Cast? CastAct { get; set; }
    }
}
