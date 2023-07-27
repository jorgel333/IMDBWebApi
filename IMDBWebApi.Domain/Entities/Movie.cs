using IMDBWebApi.Domain.Entities.Abstract;
using IMDBWebApi.Domain.Validation;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class Movie : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public int Duration { get; private set; }
        public int TotalVotes { get; private set; }
        public double RatingAverage { get; private set; }
        public string? Image { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public IEnumerable<AssessmentRecord>? Assessments { get; set; }
        public IEnumerable<CastActMovies>? ActorMovies { get; set; }
        public IEnumerable<CastDirectMovies>? DirectorMovies { get; set; }
        public IEnumerable<GenreMovies>? GenresMovies { get; set; }

        public Movie(string name, string description, int duration, string image, DateTime releaseDate)
        {
            ValidateDomain(name, description, duration);
            ReleaseDate = releaseDate;
            Image = image;
            RatingAverage = 0;
            TotalVotes = 0;
        }
        public void Update(string name, string description, int duration, DateTime releaseDate,
            IEnumerable<GenreMovies> genres, IEnumerable<CastActMovies> castActors, IEnumerable<CastDirectMovies> castDirectors)
        {
            ValidateDomain(name, description, duration);
            ReleaseDate = releaseDate;
            GenresMovies = genres;
            ActorMovies = castActors; 
            DirectorMovies = castDirectors;
        }
        public void AttRatingAverage()
        {
            TotalVotes++;
            RatingAverage = Assessments!.Select(x => x.Rate).Average();
        }
        private void ValidateDomain(string name, string description, int duration)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid. minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Invalid. Descripition is required!");

            DomainExceptionValidation.When(description.Length < 20, "Invalid. Description minimum 20 characters");
            
            DomainExceptionValidation.When(description.Length > 500, "Invalid. Description maximum 500 characters");

            DomainExceptionValidation.When(duration <= 0 , "Invalid duration value!");

            Name = name;
            Description = description;
            Duration = duration;
        }
    }
}
