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

        public IHttpActionResult PostLogin(AdminLoginDTO adminDTO)
        {
            if (ModelState.IsValid && !(adminDTO is null))
            {
                if (_adminService.Login(adminDTO.ID, adminDTO.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}
