using IMDBWebApi.Domain.Entities.Abstract;
using IMDBWebApi.Domain.Validation;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class Cast : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime DateBirth { get; private set; }
        public IEnumerable<CastActMovies>? ActedMovies { get; set; }
        public IEnumerable<CastDirectMovies>? DirectedMovies { get; set; }

        public Cast(string name, string description, DateTime dateBirth)
        {
            ValidateDomain(name, description, dateBirth);
        }

        public void Update(string name, string description, DateTime dateBirth)
        {
            ValidateDomain(name, description, dateBirth);
        }
        private void ValidateDomain(string name, string description, DateTime dateBirth)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name)
                                            , "Invalid. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid. minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description)
                                            , "Invalid. Descripition is required!");

            DomainExceptionValidation.When(description.Length < 20, "Invalid. minimum 20 characters");

            DomainExceptionValidation.When(dateBirth > DateTime.Now, "Invalid release date value!");

            Name = name;
            Description = description;
            DateBirth = dateBirth;

        }
    }
}
