using Market.Model;
using System.Collections.Generic;

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
