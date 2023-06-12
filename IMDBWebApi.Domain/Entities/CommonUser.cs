using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class CommonUser : Account
    {

        public IEnumerable<AssessmentRecord>? Assessments { get; set; }

        public CommonUser(string name, string userName, string email, string password, DateTime birthday) 
            : base(name, userName, email, password, birthday)
        {
        }
        
    }
}
