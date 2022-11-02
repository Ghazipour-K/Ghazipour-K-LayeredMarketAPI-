using Market.Repository;
using System.Threading.Tasks;

namespace Market.Service
{
    public class Customer:ICustomer
    {
        private readonly IGenericRepository<CustomerTable> _genericCustomerRepository = null;
        private readonly ICustomerRepository _customerRepository = null;

        public Customer(IGenericRepository<CustomerTable> repository)
        {
            _genericCustomerRepository = repository;
        }

        public Customer(CustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public bool Login(string UserID, string Password)
        {
            return _customerRepository.Login(UserID, Password);
        }

        public async Task<bool> LoginAsync(string UserID, string Password)
        {
            return await _customerRepository.LoginAsync(UserID, Password);

        }
    }
}