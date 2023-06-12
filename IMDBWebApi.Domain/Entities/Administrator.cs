using IMDBWebApi.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
