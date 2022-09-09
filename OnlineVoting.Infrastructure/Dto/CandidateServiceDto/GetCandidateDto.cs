using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Dto.CandidateServiceDto
{
    public class GetCandidateDto
    {     
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string PoliticalGroup { get; set; } = string.Empty;
    }
}
