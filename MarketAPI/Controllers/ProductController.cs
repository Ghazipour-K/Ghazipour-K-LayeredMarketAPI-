using System;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            return Ok(new Product().GetAll());
        }

        public IHttpActionResult PostAddProduct(ProductViewModel productView)
        {
            if (!ModelState.IsValid || productView is null) return BadRequest("Bad Request!");

            try
            {
                var product = new Product();
                if (product.Find(productView.ID))
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
