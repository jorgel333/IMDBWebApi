using IMDBWebApi.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class Cast : Entity
    {
        public string? Name { get; private set; }
        public string? Description {get; private set; }
        public DateTime DateBirth { get; private set; }
        public IEnumerable<CastActMovies>? ActedMovies { get; set; }
        public IEnumerable<CastDirectMovies>? DirectedMovies { get; set; }
    }
}
