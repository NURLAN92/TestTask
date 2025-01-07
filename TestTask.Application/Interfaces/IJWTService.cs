using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Interfaces
{
    public interface IJWTService
    {
        public string GenerateJwtToken(Guid id, string email);
    }
}
