using System.Threading.Tasks;

namespace Market.Repository
{
    public interface ICustomerRepository: IGenericRepository<UserTable>
    {
        UserTable Login(string UserName, string Password);

        Task<UserTable> LoginAsync(string UserName, string Password);
    }
}
