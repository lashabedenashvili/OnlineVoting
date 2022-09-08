using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Dto.UserServiceDto
{
    public class UserLoginDto
    {
        public string PersonalNumber { get; set; }=string.Empty;
        public string Password { get; set; } = string.Empty;


    }
}
