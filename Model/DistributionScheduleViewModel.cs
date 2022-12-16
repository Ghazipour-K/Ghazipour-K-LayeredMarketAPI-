using System;

namespace Market.Model
{
    public class DistributionScheduleViewModel
    {
        public int DistributionScheduleID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public TimeSpan StartingDeliveryHour { get; set; }
        public TimeSpan EndingDeliveryHour { get; set; }
    }
}