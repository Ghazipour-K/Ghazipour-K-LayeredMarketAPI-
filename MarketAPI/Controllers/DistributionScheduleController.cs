using System;
using System.Threading.Tasks;
using System.Web.Http;
using Market.Model;
using Market.Service;

namespace Market.Controller
{
    [RoutePrefix("api/DistributionSchedule")]
    public class DistributionScheduleController : ApiController
    {
        private readonly IDistributionSchedule _distributionScheduleService = null;
        public DistributionScheduleController(IDistributionSchedule distributionScheduleService)
        {
            _distributionScheduleService = distributionScheduleService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSchedulesAsync()
        {
            return Ok(await _distributionScheduleService.GetAllAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAddNewDistributionScheduleAsync(AddNewDistributionScheduleDTO scheduleDTO)
        {
            if (!ModelState.IsValid || scheduleDTO is null) return BadRequest("Bad request!"); //Must check DistributionScheduleViewModel for required items and integrity -- checking scheduleView is null is just a sample

            try
            {
                var scheduleView = new DistributionScheduleViewModel()
                {
                    ID = scheduleDTO.ID,
                    DeliveryDate = scheduleDTO.DeliveryDate,
                    StartingDeliveryHour = scheduleDTO.StartingDeliveryHour,
                    EndingDeliveryHour = scheduleDTO.EndingDeliveryHour
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
