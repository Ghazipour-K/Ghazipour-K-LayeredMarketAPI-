using System.Threading.Tasks;

namespace Market.Repository
{
    public interface IAdminRepository : IGenericRepository<AdminTable>
    {
        bool Login(string UserID, string Password);

        Task<bool> LoginAsync(string UserID, string Password);

    }
}
