using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class User : Account
    {
        public User(string name, string userName, string email, byte[] passwordHashSalt, 
            byte[] passwordSalt, DateTime birthday) : 
            base(name, userName, email, passwordHashSalt, passwordSalt, birthday)
        {
            IsDeleted = false;
        }

        public IEnumerable<AssessmentRecord>? Assessments { get; set; }
        
    }
}
