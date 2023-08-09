using ApiForXamarin.Data.Models;

namespace ApiForXamarin.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);

    }
}
