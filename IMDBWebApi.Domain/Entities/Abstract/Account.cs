using IMDBWebApi.Domain.Validation;

namespace IMDBWebApi.Domain.Entities.Abstract
{
    public abstract class Account : Entity
    {
        public string? Name { get; protected set; }
        public string? UserName { get; protected set; }
        public string? Email { get; protected set; }
        public byte[]? PasswordHashSalt { get; protected set; }
        public byte[]? PasswordSalt { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public bool IsDeleted { get; protected set; }


        protected Account(string name, string userName, string email, byte[] passwordHashSalt,
            byte [] passwordSalt, DateTime birthday)
        {
            ValidateDomain(name, userName, email, passwordHashSalt, passwordSalt, birthday);
            IsDeleted = false;
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }

        public void Update(string name, string userName, string email, byte[] passwordHashSalt,
            byte [] passwordSalt, DateTime birthday)
        {
            ValidateDomain(name, userName, email, passwordHashSalt, passwordSalt, birthday);
        }

        protected void ValidateDomain(string name, string userName, string email, 
            byte [] passwordHashSalt, byte [] passwordSalt,  DateTime birthday)
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

            DomainExceptionValidation.When(passwordHashSalt.Length <= 0
                                            , "Invalid. Password is required!");

            DomainExceptionValidation.When(passwordSalt.Length <= 0
                                            , "Invalid. Password is required!");

            DomainExceptionValidation.When(birthday > DateTime.Now, "Invalid release date value!");

            Name = name;
            UserName = userName;
            Email = email;
            PasswordHashSalt = passwordHashSalt;
            PasswordSalt = passwordSalt;
            Birthday = birthday;
        }
    }
}
