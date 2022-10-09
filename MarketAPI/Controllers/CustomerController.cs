using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult PostLogin(CustomerViewModel customerView)
        {
            if (ModelState.IsValid && !(customerView is null))
            {
                var customer = new Customer();
                if (customer.Login(customerView.ID, customerView.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}