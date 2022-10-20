using System.Linq;

namespace Market.Repository
{
    public class CustomerRepository : GenericRepository<CustomerTable>, ICustomerRepository
    {
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
    }
}
