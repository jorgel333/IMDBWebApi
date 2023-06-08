using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Domain.Entities.Abstract
{
    public abstract class Account : Entity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }
        public string? NickName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
