using System;
using System.Threading.Tasks;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controller
{
    [RoutePrefix("api/distribution-schedule")]
    public class DistributionScheduleController : ApiController
    {
        private readonly IDistributionSchedule _distributionScheduleService = null;
        public DistributionScheduleController(IDistributionSchedule distributionScheduleService)
        {
            _distributionScheduleService = distributionScheduleService;
        }

        [Authorize(Roles = "Admin, User")]
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSchedulesAsync()
        {
            return Ok(await _distributionScheduleService.GetAllAsync());
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAddNewDistributionScheduleAsync(CreateDistributionScheduleCommand scheduleCommand)
        {
            if (!ModelState.IsValid || scheduleCommand is null) return BadRequest("Bad request!"); //Must check DistributionScheduleViewModel for required items and integrity -- checking scheduleView is null is just a sample

            try
            {
                var scheduleView = new CreateDistributionScheduleViewModel()
                {
                    DeliveryDate = scheduleCommand.DeliveryDate,
                    StartingDeliveryHour = scheduleCommand.StartingDeliveryHour,
                    EndingDeliveryHour = scheduleCommand.EndingDeliveryHour
                };

                await _distributionScheduleService.AddAsync(scheduleView);
                return Ok("Item added to schedules!");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
