using Market.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IShoppingCard
    {
        List<ShoppingCardViewModel> GetAll();
        bool Find(ShoppingCardViewModel shoppingCardView);
        List<ShoppingCardViewModel> GetShoppingCardByCustomerID(int customerID);
        void Update(ShoppingCardViewModel shoppingCardView);
        void Add(ShoppingCardViewModel shoppingCardView);
        void Remove(ShoppingCardViewModel shoppingCardView);

        Task<List<ShoppingCardViewModel>> GetAllAsync();
        Task<bool> FindAsync(ShoppingCardViewModel shoppingCardView);
        Task<List<ShoppingCardViewModel>> GetShoppingCardByCustomerIDAsync(int customerID);
        Task UpdateAsync(ShoppingCardViewModel shoppingCardView);
        Task AddAsync(ShoppingCardViewModel shoppingCardView);
        Task RemoveAsync(ShoppingCardViewModel shoppingCardView);

    }
}
