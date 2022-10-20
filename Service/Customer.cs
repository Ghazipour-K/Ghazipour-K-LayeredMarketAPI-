﻿using Market.Repository;

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
    }
}