using System.Web.Http;
using Market.Model;
using Market.Service;
using Unity;

namespace Market.Controller
{
    public class AdminController : ApiController
    {
        private readonly IAdmin _adminService = null;
        public AdminController(IAdmin adminService)
        {
            _adminService = adminService;
        }

        public IHttpActionResult PostLogin(AdminLoginDTO loginDTO)
        {
            if (ModelState.IsValid && !(loginDTO is null))
            {
                if (_adminService.Login(loginDTO.ID, loginDTO.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}
