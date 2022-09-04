namespace OnlineVoting.Api.Models.User

{
    using OnlineVoting.Data;
    public interface IUserAutentication
    {
        Task<ServiceResponce<int>> Registration(User user, string password);
        Task<ServiceResponce<string>>Login(string username, string password);
        Task<ServiceResponce<bool>> UserExist(string username);
        Task<ServiceResponce<bool>>PersonNotExistDatabase(User user);
    }
}
