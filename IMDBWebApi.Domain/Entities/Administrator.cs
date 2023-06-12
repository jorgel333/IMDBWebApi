using IMDBWebApi.Domain.Entities.Abstract;
namespace IMDBWebApi.Domain.Entities
{
    public sealed class Administrator : Account
    {
        public Administrator(string name, string userName, string email, string password, DateTime birthday) 
            : base(name, userName, email, password, birthday)
        {
        }
    }
}
