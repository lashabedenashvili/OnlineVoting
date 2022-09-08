using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Dto.UserServiceDto
{
    public class UserUpdatePasswordDto
    {
        public string PersonalNumber  { get; set; }=string.Empty;
        public string OdlPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        
    }
}
