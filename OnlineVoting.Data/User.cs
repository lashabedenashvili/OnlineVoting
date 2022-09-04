using System.ComponentModel.DataAnnotations;

namespace OnlineVoting.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name{ get; set; }=string.Empty;
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }=string.Empty;
        [Required]
        [MaxLength(50)]
        public string PrivateNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt{ get; set; }

    }
}