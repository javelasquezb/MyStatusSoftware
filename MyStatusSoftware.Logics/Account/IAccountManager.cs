using MyStatusSoftware.Common.Proccess;
using MyStatusSoftware.Data.Entities;
using System.Threading.Tasks;

namespace MyStatusSoftware.Logics.Account
{
    public interface IAccountManager
    {
        Task<Response> Login(User user);
    }
}
