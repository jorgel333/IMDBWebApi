using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class Admin : Account
    {
        public Admin(string name, string userName, string email, byte[] passwordHashSalt, 
            byte[] passwordSalt, DateTime birthday) : 
            base(name, userName, email, passwordHashSalt, passwordSalt, birthday)
        {
            IsDeleted = false;
        }
    }
}
