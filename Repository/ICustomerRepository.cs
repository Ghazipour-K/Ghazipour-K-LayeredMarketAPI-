using System.Threading.Tasks;

namespace Market.Repository
{
    public interface ICustomerRepository: IGenericRepository<CustomerTable>
    {
        bool Login(string UserID, string Password);

        Task<bool> LoginAsync(string UserID, string Password);
    }
}
