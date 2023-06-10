using IMDBWebApi.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Domain.Entities
{
    public class Genre : Entity
    {
        public string? Name { get; private set; }
        public IEnumerable<Movie>? Movies { get; set; }
    }
}
