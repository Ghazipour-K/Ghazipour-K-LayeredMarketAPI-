using Market.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IProduct
    {
        List<ProductViewModel> GetAll();
        bool Find(int PoductId);
        void Update(CreateProductViewModel productView);
        void Add(CreateProductViewModel productView);

        Task<bool> FindAsync(int PoductId);
        Task<List<ProductViewModel>> GetAllAsync();
        Task UpdateAsync(CreateProductViewModel productView);
        Task AddAsync(CreateProductViewModel productView);
        Task<ProductViewModel> GetByIDAsync(string PoductId);
    }
}
