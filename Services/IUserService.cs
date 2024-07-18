namespace WideBot.Services
{
    public interface IUserService
    {
        Task<string> GetUserIdAsync();
        Task<string> GetUserNameAsync();
    }
}
