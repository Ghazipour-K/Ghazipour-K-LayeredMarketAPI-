using System;
using System.Web.Http;
using Market.Model;
using Market.Service;
using Market.Repository;
using Unity;
namespace Market.Controller
{
    public class ShoppingCardController : ApiController
    {
        public IHttpActionResult GetAllShoppingCards()
        {
            //return Ok(new ShoppingCard().GetAll());
            return Ok(UnityConfig.container.Resolve<ShoppingCard>().GetAll());
        }

        public IHttpActionResult GetShoppingCardByCustomerID(string customerID)
        {
            if (!ModelState.IsValid || customerID is null) return BadRequest("Bad request!");

            //return Ok(new ShoppingCard().GetShoppingCardByCustomerID(customerID));
            return Ok(UnityConfig.container.Resolve<ShoppingCard>().GetShoppingCardByCustomerID(customerID));

        }

        public IHttpActionResult PostAddItemToShoppingCard(ShoppingCardDTO shoppingCardDTO)
        {
            if (!ModelState.IsValid || shoppingCardDTO is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCard = UnityConfig.container.Resolve<ShoppingCard>();
                //var shoppingCard = new ShoppingCard(new GenericRepository<ShoppingCardTable>());
                var shoppingCardView = new ShoppingCardViewModel
                {
                    CustomerID = shoppingCardDTO.CustomerID,
                    DeliveryScheduleID = shoppingCardDTO.DeliveryScheduleID,
                    ProductID = shoppingCardDTO.ProductID,
                    Quantity = shoppingCardDTO.Quantity,
                    PurchasedDate = shoppingCardDTO.PurchasedDate
                };
                shoppingCard.Add(shoppingCardView);
                return Ok("Item added to shopping card!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
        
        public IHttpActionResult DeleteItemFromShoppingCard(DeleteShoppingCardItemDTO shoppingCardDTO)
        {
            if (!ModelState.IsValid || shoppingCardDTO is null) return BadRequest("Bad request!");

            try
            {
                var shoppingCard = UnityConfig.container.Resolve<ShoppingCard>();
                //var shoppingCard = new ShoppingCard(new GenericRepository<ShoppingCardTable>());
                var shoppingCardView = new ShoppingCardViewModel
                {
                    CustomerID = shoppingCardDTO.CustomerID,
                    DeliveryScheduleID = shoppingCardDTO.DeliveryScheduleID,
                };
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
