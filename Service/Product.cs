using Market.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Market.Repository;
namespace Market.Service
{
    public class Product : IProduct
    {
        private readonly IGenericRepository<ProductTable> _genericProductRepository = null;
        public Product()
        {
            _genericProductRepository = new GenericRepository<ProductTable>();
        }

        public List<ProductViewModel> GetAll()
        {
            List<ProductViewModel> products;

            products = _genericProductRepository.GetAll()
                .Select(p => new ProductViewModel
                {
                    ID = p.ID.Trim(),
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Price = p.Price
                }).ToList();

            return products;
        }

        public bool Find(string productId)
        {
            var result = _genericProductRepository.GetById(productId) == null ? false : true;

            return result;

        }

        public void Update(ProductViewModel productView)
        {
            var product = new ProductTable
            {
                ID = productView.ID,
                Name = productView.Name,
                Price = productView.Price,
                Quantity = productView.Quantity
            };
            _genericProductRepository.Update(product);
            _genericProductRepository.Save();
        }

        public void Add(ProductViewModel productView)
        {
            if (Find(productView.ID))
            {
                throw new Exception("Product already exists!");
            }
            else
            {
                var product = new ProductTable
                {
                    ID = productView.ID,
                    Name = productView.Name,
                    Price = productView.Price,
                    Quantity = productView.Quantity
                };
                _genericProductRepository.Insert(product);
                _genericProductRepository.Save();
            }
        }
    }
}