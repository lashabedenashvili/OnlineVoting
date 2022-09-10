using System.ComponentModel.DataAnnotations;

namespace OnlineVoting.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name{ get; set; }=string.Empty;
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }=string.Empty;
        [Required]
        [MaxLength(15)]
        public string PersonalNumber { get; set; } = string.Empty;
       
        public byte[] ?PasswordHash { get; set; }
        
        public byte[] ?PasswordSalt{ get; set; }
        public List<Votes> vote { get; set; } = new List<Votes>();

    }
}