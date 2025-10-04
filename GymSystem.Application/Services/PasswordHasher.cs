using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Application.Services
{
    public class PasswordHasher
    {

        public String HashPassword(String password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword( string  password  ,String HashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, HashPassword);
        }


         
    }
}
