using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Dto.UserServiceDto
{
    public class AddVoteDto
    {
        public string PersonalNumber { get; set; }
        public string Number { get; set; }
    }
}
