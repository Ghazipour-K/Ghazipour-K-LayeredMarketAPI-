using System.Threading.Tasks;
using System.Web.Http;
using Market.Service;

namespace Market.Controller
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private readonly IAdmin _adminService = null;
        public AdminController(IAdmin adminService)
        {
            _adminService = adminService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostLoginAsync(AdminLoginCommand loginCommand)
        {
            if (ModelState.IsValid && !(loginCommand is null))
            {
                if (await _adminService.LoginAsync(loginCommand.ID, loginCommand.Pass))
                {
                    return Ok("Login Succecfull.");
                }
                else
                {
                    return NotFound();
                }
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}
