using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Domain.Enums;

namespace GymSystem.Domain.Entities
{
   
        public class User 
        {
            public int Id { get; set; }
            public string Name { get; set; }

            [DataType(DataType.EmailAddress)]    
            public string Email { get; set; }

            [DataType(DataType.Password)]
            public string PasswordHash { get; set; }
            public UserRole Role { get; set; } 
            public DateTime CreatedAt { get; set; }
            public bool IsActive { get; set; }
        }
    
}
