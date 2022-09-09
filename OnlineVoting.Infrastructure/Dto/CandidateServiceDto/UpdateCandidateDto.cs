using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Dto.CandidateServiceDto
{
    public class UpdateCandidateDto
    {

        public string Name { get; set; }
       
        public string Surname { get; set; } 
       
        public string Number { get; set; } 
        
        public string PoliticalGroup { get; set; } 
        
        public string PersonalNumber { get; set; }
    }
}
