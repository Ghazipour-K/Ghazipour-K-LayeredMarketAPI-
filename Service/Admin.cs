using Market.Repository;
using System.Threading.Tasks;

namespace Market.Service
{
    public class Admin : IAdmin
    {
        private readonly IGenericRepository<UserTable>  _genericAdminRepository = null;
        private readonly IAdminRepository _adminRepository = null;
        
        public Admin(IGenericRepository<UserTable> repository)
        {
            _genericAdminRepository = repository;
        }

        public Admin(AdminRepository repository)
        {
            _adminRepository = repository;
        }

        public UserTable Login(string UserName, string Password)
        {
            return _adminRepository.Login(UserName, Password);
        }

        public async Task<UserTable> LoginAsync(string UserName, string Password)
        {
            return await _adminRepository.LoginAsync(UserName, Password);
        }
    }
}