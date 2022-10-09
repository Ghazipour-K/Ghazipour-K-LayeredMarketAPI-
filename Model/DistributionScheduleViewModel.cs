using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market.Model
{
    public class DistributionScheduleViewModel
    {
        public string ID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public TimeSpan StartingDeliveryHour { get; set; }
        public TimeSpan EndingDeliveryHour { get; set; }
    }
}