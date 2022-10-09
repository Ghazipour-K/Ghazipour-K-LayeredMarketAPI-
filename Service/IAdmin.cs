using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service
{
    interface IAdmin
    {
        bool Login(string UserID, string Password);
    }
}
