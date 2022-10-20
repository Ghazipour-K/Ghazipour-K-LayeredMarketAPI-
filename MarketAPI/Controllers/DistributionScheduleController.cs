using System;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controller
{
    public class DistributionScheduleController : ApiController
    {
        private readonly IDistributionSchedule _distributionScheduleService = null;
        public DistributionScheduleController(IDistributionSchedule distributionScheduleService)
        {
            _distributionScheduleService = distributionScheduleService;
        }
        public IHttpActionResult GetAllSchedules()
        {
            return Ok(_distributionScheduleService.GetAll());
        }

        public IHttpActionResult Post(DistributionScheduleDTO scheduleDTO)
        {
            if (!ModelState.IsValid || scheduleDTO is null) return BadRequest("Bad request!"); //Must check DistributionScheduleViewModel for required items and integrity -- checking scheduleView is null is just a sample

            try
            {
                var scheduleView = new DistributionScheduleViewModel()
                {
                    ID=scheduleDTO.ID,
                    DeliveryDate=scheduleDTO.DeliveryDate,
                    StartingDeliveryHour=scheduleDTO.StartingDeliveryHour,
                    EndingDeliveryHour=scheduleDTO.EndingDeliveryHour
                };

                _distributionScheduleService.Add(scheduleView);
                return Ok("Item added to schedules!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
