using System;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controller
{
    public class ProductController : ApiController
    {
        private readonly IProduct _productService = null;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            return Ok(_productService.GetAll());
        }

        public IHttpActionResult PostAddProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid || productDTO is null) return BadRequest("Bad Request!");

            try
            {
                var productView = new ProductViewModel
                {
                    ID = productDTO.ID,
                    Name = productDTO.Name,
                    Price = productDTO.Price
                };


                if (_productService.Find(productDTO.ID))
                {
                    return BadRequest("Product already exists.");
                }
                else
                {
                    _productService.Add(productView);
                    return Ok("Product added successfully.");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
