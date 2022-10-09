using Market.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IShoppingCard
    {
        List<ShoppingCardViewModel> GetAll();
        bool Find(ShoppingCardViewModel shoppingCardView);
        List<ShoppingCardViewModel> GetShoppingCardByCustomerID(string customerID);
        void Update(ShoppingCardViewModel shoppingCardView);
        void Add(ShoppingCardViewModel shoppingCardView);
        void Remove(ShoppingCardViewModel shoppingCardView);

    }
}
