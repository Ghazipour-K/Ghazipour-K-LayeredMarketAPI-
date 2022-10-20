using System;
using System.Web.Http;
using Market.Model;
using Market.Service;
namespace Market.Controller
{
    public class ShoppingCardController : ApiController
    {
        private readonly IShoppingCard _shoppingCardService = null;
        public ShoppingCardController(IShoppingCard shoppingCardService)
        {
            _shoppingCardService = shoppingCardService;
        }
        public IHttpActionResult GetAllShoppingCards()
        {
            return Ok(_shoppingCardService.GetAll());
        }

        public IHttpActionResult GetShoppingCardByCustomerID(string customerID)
        {
            if (!ModelState.IsValid || customerID is null) return BadRequest("Bad request!");

            return Ok(_shoppingCardService.GetShoppingCardByCustomerID(customerID));
        }

        public IHttpActionResult PostAddItemToShoppingCard(ShoppingCardDTO shoppingCardDTO)
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
                _shoppingCardService.Add(shoppingCardView);
                return Ok("Item added to shopping card!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        public IHttpActionResult DeleteItemFromShoppingCard(ShoppingCardItemDeleteDTO shoppingCardDTO)
        {
            if (!ModelState.IsValid || shoppingCardDTO is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCardView = new ShoppingCardViewModel
                {
                    CustomerID = shoppingCardDTO.CustomerID,
                };
                _shoppingCardService.Remove(shoppingCardView);
                return Ok("Item removed!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
