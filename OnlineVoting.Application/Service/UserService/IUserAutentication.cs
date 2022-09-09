namespace OnlineVoting.Api.Models.User

{
    using OnlineVoting.Data;
    using OnlineVoting.Infrastructure.Dto.UserServiceDto;

    public interface IUserAutentication
    {
        Task<ServiceResponce<int>> Registration(User user, string password);
        Task<ServiceResponce<string>>Login(UserLoginDto request);
        Task<bool> UserExist(string username);
        Task<ServiceResponce<string>> UpdateUserPassword(UserUpdatePasswordDto request);
       
        
    }
}
