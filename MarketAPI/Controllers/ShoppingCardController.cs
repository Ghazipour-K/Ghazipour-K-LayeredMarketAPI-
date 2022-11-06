using System;
using System.Threading.Tasks;
using System.Web.Http;
using Market.Model;
using Market.Service;
namespace Market.Controller
{
    [RoutePrefix("api/ShoppingCard")]
    public class ShoppingCardController : ApiController
    {
        private readonly IShoppingCard _shoppingCardService = null;
        public ShoppingCardController(IShoppingCard shoppingCardService)
        {
            _shoppingCardService = shoppingCardService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllShoppingCardsAsycn()
        {
            return Ok(await _shoppingCardService.GetAllAsync());
        }

        [Route("{customerID}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetShoppingCardByCustomerIDAsync(string customerID)
        {
            if (!ModelState.IsValid || customerID is null) return BadRequest("Bad request!");

            return Ok(await _shoppingCardService.GetShoppingCardByCustomerIDAsync(customerID));
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAddItemToShoppingCardAsync(AddItemToShoppingCardCommand shoppingCardDTO)
        {
            if (!ModelState.IsValid || shoppingCardDTO is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCardView = new ShoppingCardViewModel
                {
                    CustomerID = shoppingCardDTO.CustomerID,
                    DeliveryScheduleID = shoppingCardDTO.DeliveryScheduleID,
                    ProductID = shoppingCardDTO.ProductID,
                    Quantity = shoppingCardDTO.Quantity,
                    PurchasedDate = shoppingCardDTO.PurchasedDate
                };
                await _shoppingCardService.AddAsync(shoppingCardView);
                return Ok("Item added to shopping card!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [Route("")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteItemFromShoppingCardAsync(DeleteItemFromShoppingCardCommand shoppingCardDTO)
        {
            if (!ModelState.IsValid || shoppingCardDTO is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCardView = new ShoppingCardViewModel
                {
                    CustomerID = shoppingCardDTO.CustomerID,
                    ProductID = shoppingCardDTO.ProductID
                };
                await _shoppingCardService.RemoveAsync(shoppingCardView);
                return Ok("Item removed!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
