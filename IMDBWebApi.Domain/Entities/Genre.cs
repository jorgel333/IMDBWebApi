using IMDBWebApi.Domain.Entities.Abstract;
using IMDBWebApi.Domain.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class Genre : Entity
    {
        public string? Name { get; private set; }
        public IEnumerable<GenreMovies>? Movies { get; set; }

        public Genre(string name) 
        {
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name)
                                            , "Invalid. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid. minimum 3 characters");

            Name = name;
        }
    }
}
