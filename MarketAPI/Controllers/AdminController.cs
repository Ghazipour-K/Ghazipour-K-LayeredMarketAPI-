using System.Web.Http;
using Market.Model;
using Market.Service;
using Market.Repository;
using Unity;

namespace Market.Controller
{
    public class AdminController : ApiController
    {

        public IHttpActionResult PostLogin(AdminDTO adminDTO)
        {
            if (ModelState.IsValid && !(adminDTO is null))
            {
                var admin = UnityConfig.container.Resolve<Admin>();
                //var admin = new Admin(new AdminRepository());
                if (admin.Login(adminDTO.ID, adminDTO.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}
