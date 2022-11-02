using System.Threading.Tasks;
using System.Web.Http;
using Market.Service;

namespace Market.Controller
{
    public class AdminController : ApiController
    {
        private readonly IAdmin _adminService = null;
        public AdminController(IAdmin adminService)
        {
            _adminService = adminService;
        }

        public async Task<IHttpActionResult> PostLoginAsync(AdminLoginDTO loginDTO)
        {
            if (ModelState.IsValid && !(loginDTO is null))
            {
                if (await _adminService.LoginAsync(loginDTO.ID, loginDTO.Pass))
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
