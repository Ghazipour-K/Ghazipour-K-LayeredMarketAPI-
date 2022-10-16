using System;
using System.Web.Http;
using Market.Model;
using Market.Repository;
using Market.Service;
using Unity;

namespace Market.Controller
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            //return Ok(new Product(new GenericRepository<ProductTable>()).GetAll());
            return Ok(UnityConfig.container.Resolve<Product>().GetAll());

        }

        public IHttpActionResult PostAddProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid || productDTO is null) return BadRequest("Bad Request!");

            try
            {
                var product = UnityConfig.container.Resolve<Product>();
                //var product = new Product(new GenericRepository<ProductTable>());
                var productView = new ProductViewModel
                {
                    ID = productDTO.ID,
                    Name = productDTO.Name,
                    Quantity = productDTO.Quantity,
                    Price = productDTO.Price
                };
            

                if (product.Find(productDTO.ID))
                {
                    
                       
                    product.Update(productView);
                    return Ok("Product updated.");
                }
                else
                {
                    product.Add(productView);
                    return Ok("Product added.");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
