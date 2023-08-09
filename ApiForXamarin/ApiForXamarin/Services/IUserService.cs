using ApiForXamarin.Data.Models;

namespace ApiForXamarin.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}
