using System.Threading.Tasks;
using System.Web.Http;
using Market.Service;

namespace Market.Controller
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomer _customerService = null;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostLoginAsync(CustomerLoginCommand loginCommand)
        {
            if (ModelState.IsValid && !(loginCommand is null))
            {
                if (await _customerService.LoginAsync(loginCommand.ID, loginCommand.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}