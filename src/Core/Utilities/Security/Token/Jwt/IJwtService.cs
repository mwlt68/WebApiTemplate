using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Token.Jwt
{
    public interface IJwtService
    {
        public String CreateToken(int userId);
    }
}
