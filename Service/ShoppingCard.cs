using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Model;
using Market.Repository;

namespace Market.Service
{
    public class ShoppingCard : IShoppingCard
    {
        private IGenericRepository<ShoppingCardTable> _genericShoppingCardRepository = null;

        public ShoppingCard(IGenericRepository<ShoppingCardTable> repository)
        {
            _genericShoppingCardRepository = repository;
        }

        public List<ShoppingCardViewModel> GetAll()
        {
            List<ShoppingCardViewModel> shoppingCards;

            shoppingCards = _genericShoppingCardRepository.GetAll()
                .Select(c => new ShoppingCardViewModel
                {
                    CustomerID = c.CID.Trim(),
                    ProductID = c.PID.Trim(),
                    DeliveryScheduleID = c.SID.Trim(),
                    Quantity = c.Quantity,
                    PurchasedDate = c.PurchasedDate
                }).ToList();

            return shoppingCards;
        }

        public bool Find(ShoppingCardViewModel shoppingCardView)
        {
            return _genericShoppingCardRepository.GetAll()
                .Where
                (
                p => p.CID == shoppingCardView.CustomerID &&
                p.PID == shoppingCardView.ProductID
                ).Count() != 0;
        }

        public List<ShoppingCardViewModel> GetShoppingCardByCustomerID(string customerID)
        {
            List<ShoppingCardViewModel> customerShoppingCard;

            customerShoppingCard = _genericShoppingCardRepository.GetAll()
                .Where(s => s.CID == customerID)
                .Select(s => new ShoppingCardViewModel
                {
                    CustomerID = s.CID.Trim(),
                    ProductID = s.PID.Trim(),
                    DeliveryScheduleID = s.SID.Trim(),
                    Quantity = s.Quantity,
                    PurchasedDate = s.PurchasedDate
                }).ToList();

            return customerShoppingCard;
        }
        public void Update(ShoppingCardViewModel shoppingCardView)
        {
            var shoppingCard = _genericShoppingCardRepository.GetAll().Where(p => p.CID == shoppingCardView.CustomerID && p.PID == shoppingCardView.ProductID).FirstOrDefault();

            if (shoppingCard is null)
            {
                throw new Exception("Entity not found to update!");
            }
            else
            {
                shoppingCard.Quantity += shoppingCardView.Quantity; //before adding, data integrity must be checked over Quantity
            }

            _genericShoppingCardRepository.Update(shoppingCard);
            _genericShoppingCardRepository.Save();
        }

        public void Add(ShoppingCardViewModel shoppingCardView)
        {
            if (Find(shoppingCardView))
            {
                throw new Exception("Item already exists in shopping card!");
            }
            else
            {
                var shoppingCard = new ShoppingCardTable
                {
                    CID = shoppingCardView.CustomerID,
                    PID = shoppingCardView.ProductID,
                    SID = shoppingCardView.DeliveryScheduleID,
                    PurchasedDate = DateTime.Now,
                    Quantity = shoppingCardView.Quantity
                };
                _genericShoppingCardRepository.Insert(shoppingCard);
                _genericShoppingCardRepository.Save();
            }
        }

        public void Remove(ShoppingCardViewModel shoppingCardView)
        {
            var item = _genericShoppingCardRepository.GetAll()
                .Where(p =>
                p.CID == shoppingCardView.CustomerID &&
                p.PID == shoppingCardView.ProductID
                ).FirstOrDefault();

            if (!(item is null))
            {
                _genericShoppingCardRepository.Delete(item);
                _genericShoppingCardRepository.Save();
            }
            else
            {
                throw new Exception("Item not found to remove!");
            }
        }

        public async Task<List<ShoppingCardViewModel>> GetAllAsync()
        {
            List<ShoppingCardViewModel> shoppingCards;

            shoppingCards = (await _genericShoppingCardRepository.GetAllAsync())
                .Select(c => new ShoppingCardViewModel
                {
                    CustomerID = c.CID.Trim(),
                    ProductID = c.PID.Trim(),
                    DeliveryScheduleID = c.SID.Trim(),
                    Quantity = c.Quantity,
                    PurchasedDate = c.PurchasedDate
                }).ToList();

            return shoppingCards;
        }

        public async Task<bool> FindAsync(ShoppingCardViewModel shoppingCardView)
        {
            return (await _genericShoppingCardRepository.GetAllAsync())
                .Where
                (
                p => p.CID == shoppingCardView.CustomerID &&
                p.PID == shoppingCardView.ProductID
                ).Count() != 0;
        }

        public async Task<List<ShoppingCardViewModel>> GetShoppingCardByCustomerIDAsync(string customerID)
        {
            List<ShoppingCardViewModel> customerShoppingCard;

            customerShoppingCard = (await _genericShoppingCardRepository.GetAllAsync())
                .Where(s => s.CID == customerID)
                .Select(s => new ShoppingCardViewModel
                {
                    CustomerID = s.CID.Trim(),
                    ProductID = s.PID.Trim(),
                    DeliveryScheduleID = s.SID.Trim(),
                    Quantity = s.Quantity,
                    PurchasedDate = s.PurchasedDate
                }).ToList();

            return customerShoppingCard;
        }

        public async Task UpdateAsync(ShoppingCardViewModel shoppingCardView)
        {
            var shoppingCard = (await _genericShoppingCardRepository.GetAllAsync())
                .Where(p => p.CID == shoppingCardView.CustomerID && p.PID == shoppingCardView.ProductID).FirstOrDefault();

            if (shoppingCard is null)
            {
                throw new Exception("Entity not found to update!");
            }
            else
            {
                shoppingCard.Quantity += shoppingCardView.Quantity; //before adding, data integrity must be checked over Quantity
            }

            _genericShoppingCardRepository.Update(shoppingCard);
            await _genericShoppingCardRepository.SaveAsync();
        }

        public async Task AddAsync(ShoppingCardViewModel shoppingCardView)
        {
            if (await FindAsync(shoppingCardView))
            {
                throw new Exception("Item already exists in shopping card!");
            }
            else
            {
                var shoppingCard = new ShoppingCardTable
                {
                    CID = shoppingCardView.CustomerID,
                    PID = shoppingCardView.ProductID,
                    SID = shoppingCardView.DeliveryScheduleID,
                    PurchasedDate = DateTime.Now,
                    Quantity = shoppingCardView.Quantity
                };
                _genericShoppingCardRepository.Insert(shoppingCard);
                await _genericShoppingCardRepository.SaveAsync();
            }
        }

        public async Task RemoveAsync(ShoppingCardViewModel shoppingCardView)
        {
            var item = (await _genericShoppingCardRepository.GetAllAsync())
                .Where(p =>
                p.CID == shoppingCardView.CustomerID &&
                p.PID == shoppingCardView.ProductID
                ).FirstOrDefault();

            if (!(item is null))
            {
                _genericShoppingCardRepository.Delete(item);
                await _genericShoppingCardRepository.SaveAsync();
            }
            else
            {
                throw new Exception("Item not found to remove!");
            }
        }
    }
}