using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dtos
{
    public class UserLoginRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginRequestDto(string username,string password)
        {
            Password = password;
            Username = username;
        }
    }
}
