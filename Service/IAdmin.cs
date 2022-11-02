using System.Threading.Tasks;

namespace Market.Service
{
    public interface IAdmin
    {
        bool Login(string UserID, string Password);
        Task<bool> LoginAsync(string UserID, string Password);
    }
}
