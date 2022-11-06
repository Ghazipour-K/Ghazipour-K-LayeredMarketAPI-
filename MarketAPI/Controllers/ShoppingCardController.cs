using System;
using System.Threading.Tasks;
using System.Web.Http;
using Market.Model;
using Market.Service;
namespace Market.Controller
{
    //[RoutePrefix("api/ShoppingCard")]
    public class ShoppingCardController : ApiController
    {
        private readonly IShoppingCard _shoppingCardService = null;
        public ShoppingCardController(IShoppingCard shoppingCardService)
        {
            _shoppingCardService = shoppingCardService;
        }

        [Route("api/ShoppingCard")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllShoppingCardsAsycn()
        {
            return Ok(await _shoppingCardService.GetAllAsync());
        }

        [Route("api/Customer/{customerID}/ShoppingCard")]
        [HttpGet]
        public async Task<IHttpActionResult> GetShoppingCardByCustomerIDAsync(string customerID)
        {
            if (!ModelState.IsValid || customerID is null) return BadRequest("Bad request!");

            return Ok(await _shoppingCardService.GetShoppingCardByCustomerIDAsync(customerID));
        }

        [Route("api/ShoppingCard")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAddItemToShoppingCardAsync(AddItemToShoppingCardCommand shoppingCardCommand)
        {
            if (!ModelState.IsValid || shoppingCardCommand is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCardView = new ShoppingCardViewModel
                {
                    CustomerID = shoppingCardCommand.CustomerID,
                    DeliveryScheduleID = shoppingCardCommand.DeliveryScheduleID,
                    ProductID = shoppingCardCommand.ProductID,
                    Quantity = shoppingCardCommand.Quantity,
                    PurchasedDate = shoppingCardCommand.PurchasedDate
                };
                await _shoppingCardService.AddAsync(shoppingCardView);
                return Ok("Item added to shopping card!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [Route("api/ShoppingCard")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteItemFromShoppingCardAsync(DeleteItemFromShoppingCardCommand shoppingCardCommand)
        {
            if (!ModelState.IsValid || shoppingCardCommand is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCardView = new ShoppingCardViewModel
                {
                    CustomerID = shoppingCardCommand.CustomerID,
                    ProductID = shoppingCardCommand.ProductID
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
