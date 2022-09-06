using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Dto
{
    public class UserRegistrationDto
    {
     
        public string Name { get; set; } = string.Empty;
      
        public string Surname { get; set; } = string.Empty;
      
        public string PersonalNumber { get; set; } = string.Empty;

        public string Password { get; set; }
    }
}
