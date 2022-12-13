using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dtos
{
    public class UserLoginResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
