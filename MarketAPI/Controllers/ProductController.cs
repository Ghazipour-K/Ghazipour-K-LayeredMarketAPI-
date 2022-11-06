using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
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

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductsAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostCreateProductAsync(CreateProductCommand productCommand)
        {
            if (!ModelState.IsValid || productCommand is null) return BadRequest("Bad Request!");

            try
            {
                var productView = new ProductViewModel
                {
                    ID = productCommand.ID,
                    Name = productCommand.Name,
                    Price = productCommand.Price
                };


                if (await _productService.FindAsync(productCommand.ID))
                {
                    return BadRequest("Product already exists.");
                }
                else
                {
                    await _productService.AddAsync(productView);
                    return Ok("Product added successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
