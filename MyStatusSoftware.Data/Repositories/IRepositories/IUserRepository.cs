using MyStatusSoftware.Data.Entities;
using System.Threading.Tasks;

namespace MyStatusSoftware.Data.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Login(User user);

        Task<bool> ExistByEmail(User user);
    }
}
