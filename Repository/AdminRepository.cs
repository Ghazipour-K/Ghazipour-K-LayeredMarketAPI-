using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Repository
{
    public class AdminRepository : GenericRepository<UserTable>, IAdminRepository
    {
        public AdminRepository(MarketEntities market) : base(market)
        {
        }

        public UserTable Login(string UserName, string Password)
        {
            var result = _market.UserTables.Where(c => c.UserName == UserName && c.UserPassword == Password).FirstOrDefault();

            return result;
        }

        public async Task<UserTable> LoginAsync(string UserName, string Password)
        {
            var result = await _market.UserTables.Where(c => c.UserName == UserName && c.UserPassword == Password).FirstOrDefaultAsync();

            return result;
        }
    }
}
