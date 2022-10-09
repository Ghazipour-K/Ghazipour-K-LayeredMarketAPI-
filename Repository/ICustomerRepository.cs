using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repository
{
    public interface ICustomerRepository: IGenericRepository<CustomerTable>
    {
        bool Login(string UserID, string Password);
    }
}
