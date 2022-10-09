using System;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controllers
{
    public class ShoppingCardController : ApiController
    {
        public IHttpActionResult GetAllShoppingCards()
        {
            return Ok(new ShoppingCard().GetAll());
        }

        public IHttpActionResult GetShoppingCardByCustomerID(string customerID)
        {
            if (!ModelState.IsValid || customerID is null) return BadRequest("Bad request!");

            return Ok(new ShoppingCard().GetShoppingCardByCustomerID(customerID));
        }

        public IHttpActionResult PostAddItemToShoppingCard(ShoppingCardViewModel shoppingCardView)
        {
            if (!ModelState.IsValid || shoppingCardView is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCard = new ShoppingCard();
                shoppingCard.Add(shoppingCardView);
                return Ok("Item added to shopping card!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
        
        public IHttpActionResult DeleteItemFromShoppingCard(ShoppingCardViewModel shoppingCardView)
        {
            if (!ModelState.IsValid || shoppingCardView is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCard = new ShoppingCard();
                shoppingCard.Remove(shoppingCardView);
                return Ok("Item removed!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
