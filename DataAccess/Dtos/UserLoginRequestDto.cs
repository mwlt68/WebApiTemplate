using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dtos
{
    public class UserLoginRequestDto
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
