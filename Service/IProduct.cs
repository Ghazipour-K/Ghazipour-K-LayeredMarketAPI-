using Market.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IProduct
    {
        List<ProductViewModel> GetAll();
        bool Find(string PoductId);
        void Update(ProductViewModel productView);
        void Add(ProductViewModel productView);
    }
}
