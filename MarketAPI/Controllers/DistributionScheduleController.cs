using System;
using System.Web.Http;
using Market.Model;
using Market.Service;
using Market.Repository;
using Unity;
namespace Market.Controller
{
    public class DistributionScheduleController : ApiController
    {
        public IHttpActionResult GetAllSchedules()
        {
            //return Ok(new DistributionSchedule(new GenericRepository<DistributionScheduleTable>()).GetAll());
            return Ok(UnityConfig.container.Resolve<DistributionSchedule>().GetAll());
        }

        public IHttpActionResult Post(DistributionScheduleDTO scheduleDTO)
        {
            if (!ModelState.IsValid || scheduleDTO is null) return BadRequest("Bad request!"); //Must check DistributionScheduleViewModel for required items and integrity -- checking scheduleView is null is just a sample

            try
            {
                var schedule = UnityConfig.container.Resolve<DistributionSchedule>();
                //var schedule = new DistributionSchedule(new GenericRepository<DistributionScheduleTable>());
                var scheduleView = new DistributionScheduleViewModel()
                {
                    ID=scheduleDTO.ID,
                    DeliveryDate=scheduleDTO.DeliveryDate,
                    StartingDeliveryHour=scheduleDTO.StartingDeliveryHour,
                    EndingDeliveryHour=scheduleDTO.EndingDeliveryHour
                };

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
