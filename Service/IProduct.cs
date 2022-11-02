using Market.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IProduct
    {
        List<ProductViewModel> GetAll();
        bool Find(string PoductId);
        void Update(ProductViewModel productView);
        void Add(ProductViewModel productView);

        Task<bool> FindAsync(string PoductId);
        Task<List<ProductViewModel>> GetAllAsync();
        Task UpdateAsync(ProductViewModel productView);
        Task AddAsync(ProductViewModel productView);
    }
}
