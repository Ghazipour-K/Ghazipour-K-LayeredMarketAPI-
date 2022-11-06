using System.Threading.Tasks;
using System.Web.Http;
using Market.Service;

namespace Market.Controller
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomer _customerService = null;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostLoginAsync(CustomerLoginCommand loginDTO)
        {
            if (ModelState.IsValid && !(loginDTO is null))
            {
                if (await _customerService.LoginAsync(loginDTO.ID, loginDTO.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}