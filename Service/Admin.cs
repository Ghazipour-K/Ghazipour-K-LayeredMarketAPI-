﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Market.Repository;

namespace Market.Service
{
    public class Admin : IAdmin
    {
        private readonly IGenericRepository<AdminTable>  _genericAdminRepository = null;
        private readonly IAdminRepository _adminRepository = null;
        public Admin()
        {
            _genericAdminRepository = new GenericRepository<AdminTable>();
            _adminRepository = new AdminRepository();
        }

        public Admin(IGenericRepository<AdminTable> repository)
        {
            _genericAdminRepository = repository;
        }

        public Admin(AdminRepository repository)
        {
            _adminRepository = repository;
        }

        public bool Login(string UserID, string Password)
        {
            return _adminRepository.Login(UserID, Password);
        }
    }
}