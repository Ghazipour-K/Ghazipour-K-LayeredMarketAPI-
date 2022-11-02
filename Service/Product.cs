using Market.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Market.Repository;
using System.Threading.Tasks;

namespace Market.Service
{
    public class Product : IProduct
    {
        private readonly IGenericRepository<ProductTable> _genericProductRepository = null;

        public Product(IGenericRepository<ProductTable> repository)
        {
            _genericProductRepository = repository;
        }

        public List<ProductViewModel> GetAll()
        {
            try
            {
                List<ProductViewModel> products;

                products = _genericProductRepository.GetAll()
                    .Select(p => new ProductViewModel
                    {
                        ID = p.ID.Trim(),
                        Name = p.Name,
                        Price = p.Price
                    }).ToList();

                return products;
            }
            catch
            {
                throw new Exception("Error on fetching data!");
            }
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            try
            {
                var products = await _genericProductRepository.GetAllAsync();

                var productList = products.Select(p => new ProductViewModel
                {
                    ID = p.ID.Trim(),
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

                return productList;
            }
            catch 
            {
                throw new Exception("Error on fetching data!");
            }
        }

        public bool Find(string productId)
        {
            var result = _genericProductRepository.GetById(productId) == null ? false : true;

            return result;

        }

        public async Task<bool> FindAsync(string poductId)
        {
            var result = await _genericProductRepository.GetByIdAsync(poductId) == null ? false : true;

            return result;
        }

        public void Update(ProductViewModel productView)
        {
            try
            {
                var product = new ProductTable
                {
                    ID = productView.ID,
                    Name = productView.Name,
                    Price = productView.Price,
                };
                _genericProductRepository.Update(product);
                _genericProductRepository.Save();
            }
            catch
            {
                throw new Exception("Error on update!");
            }
        }

        public async Task UpdateAsync(ProductViewModel productView)
        {
            try
            {
                var product = new ProductTable
                {
                    ID = productView.ID,
                    Name = productView.Name,
                    Price = productView.Price,
                };
                _genericProductRepository.Update(product);
                await _genericProductRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Error on update!");
            }
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
                };
                _genericProductRepository.Insert(product);
                _genericProductRepository.Save();
            }
        }


        public async Task AddAsync(ProductViewModel productView)
        {
            if (await FindAsync(productView.ID))
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
                };
                _genericProductRepository.Insert(product);
                await _genericProductRepository.SaveAsync();
            }
        }

        
    }
}