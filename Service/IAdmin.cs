using Market.Repository;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IAdmin
    {
        UserTable Login(string UserName, string Password);

        Task<UserTable> LoginAsync(string UserName, string Password);
    }
}
