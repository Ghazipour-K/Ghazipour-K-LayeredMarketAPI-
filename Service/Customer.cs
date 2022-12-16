using Market.Repository;
using System.Threading.Tasks;

namespace Market.Service
{
    public class Customer:ICustomer
    {
        private readonly IGenericRepository<UserTable> _genericCustomerRepository = null;
        private readonly ICustomerRepository _customerRepository = null;

        public Customer(IGenericRepository<UserTable> repository)
        {
            _genericCustomerRepository = repository;
        }

        public Customer(CustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public UserTable Login(string UserName, string Password)
        {
            return _customerRepository.Login(UserName, Password);
        }

        public async Task<UserTable> LoginAsync(string UserName, string Password)
        {
            return await _customerRepository.LoginAsync(UserName, Password);

        }
    }
}