using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Repository
{
    public class CustomerRepository : GenericRepository<CustomerTable>, ICustomerRepository
    {
        public CustomerRepository(MarketEntities market) : base(market)
        {
        }

        public bool Login(string UserID, string Password)
        {
            var result = _market.CustomerTables.Where(c => c.ID.ToLower() == UserID && c.Pass == Password).FirstOrDefault();

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
            var result = await _market.CustomerTables.Where(c => c.ID.ToLower() == UserID && c.Pass == Password).FirstOrDefaultAsync();

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
