using IMDBWebApi.Domain.Entities.Abstract;
using IMDBWebApi.Domain.Validation;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class AssessmentRecord : Entity
    {
        public int Rate { get; private set; }
        public DateTime EvaluationDate { get; private set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int CommonUserId { get; set; }
        public User? CommonUser { get; set; }

        public AssessmentRecord(int rate, int commonUserId, int movieId)
        {
            ValidateDomain(rate);
            EvaluationDate = DateTime.Today;
            CommonUserId = commonUserId;
            MovieId = movieId;
        }

        public void Update(int rate)
        {
            ValidateDomain(rate);
        }
        private void ValidateDomain(int rate)
        {
            DomainExceptionValidation.When(rate < 0, "Rating cannot be lees than 0");
            DomainExceptionValidation.When(rate > 10, "Rating cannot be greather than 5");

            Rate = rate;
        }
    }
}
