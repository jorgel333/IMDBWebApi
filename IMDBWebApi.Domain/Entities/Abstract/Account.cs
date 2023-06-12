using IMDBWebApi.Domain.Validation;

namespace IMDBWebApi.Domain.Entities.Abstract
{
    public abstract class Account : Entity
    {
        public string? Name { get; protected set; }
        public string? UserName { get; protected set; }
        public string? Email { get; protected set; }
        public string? Password { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public bool IsDeleted { get; protected set; }


        protected Account(string name, string userName, string email, string password, 
            DateTime birthday)
        {
            ValidateDomain(name, userName, email, password, birthday);
            IsDeleted = false;
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }

        public void Update(string name, string userName, string email, string password,
            DateTime birthday)
        {
            ValidateDomain(name, userName, email, password, birthday);
        }

        protected void ValidateDomain(string name, string userName, string email, string password, DateTime birthday)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name)
                                            , "Invalid. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid. minimum 3 characters");
            
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(userName)
                                            , "Invalid. User name is required!");

            DomainExceptionValidation.When(userName.Length < 3, "Invalid. minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email)
                                            , "Invalid. Email is required!");

            DomainExceptionValidation.When(email.Length > 250, "Invalid. minimum 20 characters");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(password)
                                            , "Invalid. Password is required!");

            DomainExceptionValidation.When(password.Length < 6, "Invalid, minimum 8 characters");
            
            DomainExceptionValidation.When(password.Length > 32, "Invalid, maximum 32 characters");

            DomainExceptionValidation.When(birthday > DateTime.Now, "Invalid release date value!");

            Name = name;
            UserName = userName;
            Email = email;
            Password = password;
            Birthday = birthday;
        }
    }
}
