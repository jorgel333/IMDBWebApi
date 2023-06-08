using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class Movie : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public int TotalVotes { get; set; }
        public double RatingAverage { get; set; }
        public string? Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<AssessmentRecord>? Assessments { get; set; }
        public IEnumerable<CastActMovies>? ActorMovies { get; set; }
        public IEnumerable<CastDirectMovies>? DirectorMovies { get; set; }
    }
}
