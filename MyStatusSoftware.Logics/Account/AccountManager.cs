using MyStatusSoftware.Common.Proccess;
using MyStatusSoftware.Data.Entities;
using MyStatusSoftware.Data.Repositories.IRepositories;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyStatusSoftware.Logics.Account
{
    public class AccountManager : IAccountManager
    {
        private readonly IUserRepository _userRepository;

        public AccountManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response> Login(User user)
        {
            Response result = new Response();
            try
            {
                var userLogin = await _userRepository.Login(user);
                if (userLogin != null)
                {
                    result.Success = true;
                    result.Result = JsonConvert.SerializeObject(userLogin);
                }
                else
                {
                    result.Msg = "Usuario y/o contraseña son invalidos";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error procesando su solicitud");
            }
            return result;
        }
    }
}
