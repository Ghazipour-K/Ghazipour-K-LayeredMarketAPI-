using System.Web.Http;
using Market.Service;

namespace Market.Controller
{
    public class CustomerController : ApiController
    {
        private readonly ICustomer _customerService = null;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }
        public IHttpActionResult PostLogin(CustomerLoginDTO customerDTO)
        {
            if (ModelState.IsValid && !(customerDTO is null))
            {
                if (_customerService.Login(customerDTO.ID, customerDTO.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}