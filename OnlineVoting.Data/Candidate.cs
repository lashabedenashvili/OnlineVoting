using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Data
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Number { get; set; }= string.Empty;


    }
}
