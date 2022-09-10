using OnlineVoting.Domein;


namespace OnlineVoting.Api.Models.User
{
    using Microsoft.EntityFrameworkCore;
    using OnlineVoting.Data;
    using OnlineVoting.Infrastructure.Dto;
    using OnlineVoting.Infrastructure.Dto.UserServiceDto;

    public class UserAutentication : IUserAutentication
    {
        private readonly IContext _context;

        public UserAutentication(IContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponce<string>> Login(UserLoginDto request)
       {


            var response = new ServiceResponce<string>();
            var user = await _context.users.FirstOrDefaultAsync(x => x.PersonalNumber.Equals(request.PersonalNumber));

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Password is not correct.";
            }
            else
                response.Data = user.Name;
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

        public async Task<ServiceResponce<string>> UpdateUserPassword(UserUpdatePasswordDto request)
        {
            var response = new ServiceResponce<string>();
            var user = await _context.users.FirstOrDefaultAsync(b => b.PersonalNumber == request.PersonalNumber);

            if (user == null)
            {
                response.Success = false;
                response.Message = "User doesnot exist.";
                return response;
            }

            if ( !VerifyPasswordHash(request.OdlPassword, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Old password is incorect.";
                return response;
            }
            else
            {
                CreatePasswordHash(request.NewPassword, out byte[] passwordhash, out byte[] passwordsalt);
                user.PasswordHash = passwordhash;
                user.PasswordSalt = passwordsalt;
                _context.users.Update(user);
                _context.saveChanges();
            }
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
