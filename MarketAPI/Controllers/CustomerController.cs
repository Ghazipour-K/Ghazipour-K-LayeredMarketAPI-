using System.Web.Http;
using Market.Model;
using Market.Service;
using Market.Repository;
using Unity;

namespace Market.Controller
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult PostLogin(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid && !(customerDTO is null))
            {
                var customer = UnityConfig.container.Resolve<Customer>();
                //var customer = new Customer(new CustomerRepository());
                if (customer.Login(customerDTO.ID, customerDTO.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}