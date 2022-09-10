using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Data
{
    public class Votes
    {
        public int Id { get; set; }
        public byte Vote { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public int CandidateId { get; set; }
        User user { get; set; } 
        Candidate candidate { get; set; }

    }
}
