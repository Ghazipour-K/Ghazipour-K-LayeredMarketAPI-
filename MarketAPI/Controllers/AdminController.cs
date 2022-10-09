using System.Web.Http;
using Market.Model;
using Market.Service;
namespace Market.Controllers
{
    public class AdminController : ApiController
    {

        public IHttpActionResult PostLogin(AdminViewModel adminView)
        {
            if (ModelState.IsValid && !(adminView is null))
            {
                var admin = new Admin();
                if (admin.Login(adminView.ID, adminView.Pass))
                    return Ok("Login Succecfull.");
                else
                    return NotFound();
            }
            else
                return BadRequest("Bad Request.");
        }
    }
}
