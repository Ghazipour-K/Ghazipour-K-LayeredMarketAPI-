using System.Threading.Tasks;

namespace Market.Service
{
    public interface ICustomer
    {
        bool Login(string UserID, string Password);
        Task<bool> LoginAsync(string UserID, string Password);
    }
}
