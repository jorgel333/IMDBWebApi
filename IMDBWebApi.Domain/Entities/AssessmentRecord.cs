using IMDBWebApi.Domain.Entities.Abstract;
using IMDBWebApi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class AssessmentRecord : Entity
    {
        public int Rate { get; private set; }
        public DateTime EvaluationDate { get; private set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int CommonUserId { get; set; }
        public CommonUser? CommonUser { get; set; }

        public AssessmentRecord(int rate)
        {
            ValidateDomain(rate);
            EvaluationDate = DateTime.Now;
        }

        public void Update(int rate)
        {
            ValidateDomain(rate);
        }
        private void ValidateDomain(int rate)
        {
            DomainExceptionValidation.When(rate < 0, "Rating cannot be lees than 0");
            DomainExceptionValidation.When(rate > 5, "Rating cannot be greather than 5");

            Rate = rate;
        }
    }
}
