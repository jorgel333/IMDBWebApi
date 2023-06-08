using IMDBWebApi.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class AssessmentRecord : Entity
    {
        public int Rate { get; set; }
        public DateTime EvaluationDate { get; set; }
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }
        public Guid CommonUserId { get; set; }
        public CommonUser? CommonUser { get; set; }
    }
}
