using System;
using System.Threading.Tasks;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controller
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProduct _productService = null;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "Admin, User")]
        [Route("{productId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductByIDAsync(string productId)
        {
            try
            {
                return Ok(await _productService.GetByIDAsync(productId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin, User")]
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductsAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostCreateProductAsync(CreateProductCommand productCommand)
        {
            if (!ModelState.IsValid || productCommand is null) return BadRequest("Bad Request!");

            try
            {
                var productView = new CreateProductViewModel
                {
                    ProductName = productCommand.Name,
                    ProductPrice = productCommand.Price
                };
                
                await _productService.AddAsync(productView);
                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
