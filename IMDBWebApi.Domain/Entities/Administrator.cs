﻿using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Domain.Entities
{
    public sealed class Administrator : Account
    {
        public Administrator(string name, string userName, string email, byte[] passwordHashSalt, 
            byte[] passwordSalt, DateTime birthday) : 
            base(name, userName, email, passwordHashSalt, passwordSalt, birthday)
        {
        }
    }
}
