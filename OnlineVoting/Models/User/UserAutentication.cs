using OnlineVoting.Domein;


namespace OnlineVoting.Api.Models.User
{
    using OnlineVoting.Data;
    public class UserAutentication : IUserAutentication
    {
        private readonly IContext _context;

        public UserAutentication(IContext context)
        {
            _context = context;
        }

       
        public Task<ServiceResponce<string>> Login(string username, string password)
        {
            
        }

        public Task<ServiceResponce<bool>> PersonNotExistDatabase(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponce<int>> Registration(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponce<bool>> UserExist(string username)
        {
            throw new NotImplementedException();
        }
        private void CreatePasswordHash(string password, byte[]passwordHash, byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
