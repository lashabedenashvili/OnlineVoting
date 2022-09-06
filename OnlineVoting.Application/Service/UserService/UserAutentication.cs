using OnlineVoting.Domein;


namespace OnlineVoting.Api.Models.User
{
    using Microsoft.EntityFrameworkCore;
    using OnlineVoting.Data;
    public class UserAutentication : IUserAutentication
    {
        private readonly IContext _context;

        public UserAutentication(IContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponce<string>> Login(string personalnumber, string password)
        {
            var response=new ServiceResponce<string>();
            var user = await _context.users.FirstOrDefaultAsync(x => x.PersonalNumber.Equals(personalnumber));
            if(user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success=false;
                response.Message = "Password is not correct.";
            }
            return response;
        }

        public async Task<ServiceResponce<int>> Registration(User user, string password)
        {
            var response = new ServiceResponce<int>();
            if (await UserExist(user.PersonalNumber))
            {
                response.Success = false;
                response.Message = "User already exist.";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] paswwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = paswwordSalt;
            _context.users.Add(user);
            _context.saveChanges();
            response.Success = true;
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExist(string personalNumber)
        {
            return await _context.users.AnyAsync(x => x.PersonalNumber.Equals(personalNumber));
        }

        

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
