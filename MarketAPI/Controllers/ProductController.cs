using System;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> GetAllProductsAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }

        public async Task<IHttpActionResult> PostAddProductAsync(AddNewProductDTO productDTO)
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


                if (await _productService.FindAsync(productDTO.ID))
                {
                    return BadRequest("Product already exists.");
                }
                else
                {
                    await _productService.AddAsync(productView);
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
