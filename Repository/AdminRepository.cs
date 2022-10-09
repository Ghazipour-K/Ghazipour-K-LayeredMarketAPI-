using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repository
{
    public class AdminRepository : GenericRepository<AdminTable>, IAdminRepository
    {
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
    }
}
