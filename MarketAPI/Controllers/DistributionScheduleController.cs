using System;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controllers
{
    public class DistributionScheduleController : ApiController
    {
        public IHttpActionResult GetAllSchedules()
        {
            return Ok(new DistributionSchedule().GetAll());
        }

        public IHttpActionResult Post(DistributionScheduleViewModel scheduleView)
        {
            if (!ModelState.IsValid || scheduleView is null) return BadRequest("Bad request!"); //Must check DistributionScheduleViewModel for required items and integrity -- checking scheduleView is null is just a sample

            try
            {
                var schedule = new DistributionSchedule();
                schedule.Add(scheduleView);
                return Ok("Item added to schedules!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
