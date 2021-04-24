using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyStatusSoftware.Data.Entities;
using System.Threading.Tasks;

namespace MyStatusSoftware.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public SeedDb(DataContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CreateUserSuperAdmin();
        }

        private async Task CreateUserSuperAdmin()
        {
            var user = new User
            {
                Email = _configuration["Admin"]
            };
            if (!await this._context.Users.AnyAsync(u => u.Email == user.Email))
            {
                user.FirstName = "Super Admin";
                user.LastName = "MyStatusSoftware";
                user.Password = "MStatuss.21";
                user.UserType = Common.Enums.UserType.SuperAdmin;
                await this._context.AddAsync(user);
                await this._context.SaveChangesAsync();
            }
        }
    }
}
