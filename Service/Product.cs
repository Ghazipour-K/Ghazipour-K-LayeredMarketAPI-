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
                        ProductID = p.ID,
                        ProductName = p.Name,
                        ProductPrice = p.Price
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
                    ProductID = p.ID,
                    ProductName = p.Name,
                    ProductPrice = p.Price
                }).ToList();

                return productList;
            }
            catch
            {
                throw new Exception("Error on fetching data!");
            }
        }

        public bool Find(int productId)
        {
            var result = _genericProductRepository.GetById(productId) == null ? false : true;

            return result;

        }

        public async Task<bool> FindAsync(int poductId)
        {
            var result = await _genericProductRepository.GetByIdAsync(poductId) == null ? false : true;

            return result;
        }

        public void Update(CreateProductViewModel productView)
        {
            try
            {
                var product = new ProductTable
                {
                    Name = productView.ProductName,
                    Price = productView.ProductPrice,
                };
                _genericProductRepository.Update(product);
                _genericProductRepository.Save();
            }
            catch
            {
                throw new Exception("Error on update!");
            }
        }

        public async Task UpdateAsync(CreateProductViewModel productView)
        {
            try
            {
                var product = new ProductTable
                {
                    Name = productView.ProductName,
                    Price = productView.ProductPrice,
                };
                _genericProductRepository.Update(product);
                await _genericProductRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Error on update!");
            }
        }

        public void Add(CreateProductViewModel productView)
        {

            var product = new ProductTable
            {
                Name = productView.ProductName,
                Price = productView.ProductPrice,
            };
            _genericProductRepository.Insert(product);
            _genericProductRepository.Save();
        }


        public async Task AddAsync(CreateProductViewModel productView)
        {

            var product = new ProductTable
            {
                Name = productView.ProductName,
                Price = productView.ProductPrice,
            };
            _genericProductRepository.Insert(product);
            await _genericProductRepository.SaveAsync();
        }

        public async Task<ProductViewModel> GetByIDAsync(string productId)
        {
            try
            {
                var p = await _genericProductRepository.GetByIdAsync(productId);
                if (p != null)
                {
                    ProductViewModel product = new ProductViewModel
                    {
                        ProductID = p.ID,
                        ProductName = p.Name,
                        ProductPrice = p.Price,
                    };

                    return product;
                }
                else
                    //throw new KeyNotFoundException("Item not found!");
                    return null;
            }
            catch
            {
                throw new Exception("Error on fetching data!");
            }
        }
    }
}