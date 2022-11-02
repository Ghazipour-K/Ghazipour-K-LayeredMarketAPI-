using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Repository
{
    public class AdminRepository : GenericRepository<AdminTable>, IAdminRepository
    {
        public AdminRepository(MarketEntities market) : base(market)
        {
        }

        public bool Login(string UserID, string Password)
        {
            var result = _market.AdminTables.Where(a => a.ID.ToLower() == UserID.ToLower() && a.Pass == Password).FirstOrDefault();

            if (result != null)
            {
                return true;//Login Succecfull
            }
            else
            {
                return false;//Invalid Credentials
            }
        }

        public async Task<bool> LoginAsync(string UserID, string Password)
        {
            var result = await _market.AdminTables.Where(a => a.ID.ToLower() == UserID.ToLower() && a.Pass == Password).FirstOrDefaultAsync();

            if (result != null)
            {
                return true;//Login Succecfull
            }
            else
            {
                return false;//Invalid Credentials
            }
        }
    }
}
