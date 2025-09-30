using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GymSystem.Domain.Entities;

namespace GymSystem.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
