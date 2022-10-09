using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repository
{
    public interface IAdminRepository : IGenericRepository<AdminTable>
    {
        bool Login(string UserID, string Password);
    }
}
