using ApiForXamarin.Data;
using ApiForXamarin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForXamarin.Services
{
    public class UserService : IUserService
    {
        private readonly ApiForXamarinContext _context;

        public UserService(ApiForXamarinContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }
}
