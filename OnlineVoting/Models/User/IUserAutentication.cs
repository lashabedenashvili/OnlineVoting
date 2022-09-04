namespace OnlineVoting.Api.Models.User

{
    using OnlineVoting.Data;
    public interface IUserAutentication
    {
        Task<ServiceResponce<int>> Registration(User user, string password);
        Task<ServiceResponce<string>>Login(string personalnumber, string password);
        Task<bool> UserExist(string username);
        
    }
}
