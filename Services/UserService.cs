
using Microsoft.AspNetCore.Identity;
using WideBot.Mycontext;

namespace WideBot.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        public UserService(IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _contextAccessor = contextAccessor;
            this.userManager = userManager;
        }

        // get user id from Login session 
        public async Task<string> GetUserIdAsync()
        {
            var userid = await userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            return userid.Id;
        }

        public async Task<string> GetUserNameAsync()
        {
            var username = await userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            return username.UserName;
        }
    }
}
