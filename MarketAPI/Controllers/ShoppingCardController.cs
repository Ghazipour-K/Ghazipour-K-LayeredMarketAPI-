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
        [Authorize(Roles ="Admin, User")]
        [Route("api/shopping-card")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllShoppingCardsAsycn()
        {
            return Ok(await _shoppingCardService.GetAllAsync());
        }

        [Authorize(Roles = "Admin, User")]
        [Route("api/customer/{customerID}/shopping-card")]
        [HttpGet]
        public async Task<IHttpActionResult> GetShoppingCardByCustomerIDAsync(int customerID)
        {
            if (!ModelState.IsValid) return BadRequest("Bad request!");

            return Ok(await _shoppingCardService.GetShoppingCardByCustomerIDAsync(customerID));
        }

        [Authorize(Roles = "Admin, User")]
        [Route("api/shopping-card")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAddItemToShoppingCardAsync(AddItemToShoppingCardCommand shoppingCardCommand)
        {
            if (!ModelState.IsValid || shoppingCardCommand is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCardView = new ShoppingCardViewModel
                {
                    UserID = shoppingCardCommand.CustomerID,
                    ProductID = shoppingCardCommand.ProductID,
                    DeliveryScheduleID = shoppingCardCommand.DeliveryScheduleID,
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

        [Authorize(Roles = "Admin, User")]
        [Route("api/shopping-card")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteItemFromShoppingCardAsync(DeleteItemFromShoppingCardCommand shoppingCardCommand)
        {
            if (!ModelState.IsValid || shoppingCardCommand is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCardView = new ShoppingCardViewModel
                {
                    UserID = shoppingCardCommand.CustomerID,
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
