using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Domain.Entities.Abstract
{
    public abstract class Account : Entity
    {
        public string? Name { get; protected set; }
        public string? Email { get; protected set; }
        public string? Password { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public string? NickName { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
