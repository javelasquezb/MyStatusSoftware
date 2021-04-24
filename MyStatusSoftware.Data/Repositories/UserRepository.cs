using Microsoft.EntityFrameworkCore;
using MyStatusSoftware.Data.Entities;
using MyStatusSoftware.Data.Repositories.IRepositories;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatusSoftware.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistByEmail(User user) => await this._context.Users.AnyAsync(u => u.Email == user.Email);

        public async Task<User> Login(User user) => await _context.Users
            .Where(u => (u.Email == user.Email || u.UserName == user.UserName) && u.Password == user.Password && u.IsEnable)
            .FirstOrDefaultAsync();
    }
}
