using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Data
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }=string.Empty;
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; } = string.Empty;
        [Required]
        [MaxLength(15)]
        public string Number { get; set; }= string.Empty;
        [Required]
        [MaxLength(100)]
        public string  PoliticalGroup { get; set; }=string.Empty ;
        [Required]
        [MaxLength(15)]
        public string PersonalNumber { get; set; } = string.Empty;
        public List<Votes> vote { get; set; } = new List<Votes>();





    }
}
