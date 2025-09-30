using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Application.DTOs.AuthDtos
{
    public class AuthResponceDto
    {

        public String Token {  get; set; } 
        public String Name { get; set; }  
        public String Email { get; set; }
        public DateTime ExpiresAt { get; set; } 

    }
}
