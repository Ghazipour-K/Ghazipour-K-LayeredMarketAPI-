﻿using System;

namespace Market.Controller
{
    public class CreateDistributionScheduleCommand
    {
        public DateTime DeliveryDate { get; set; }
        public TimeSpan StartingDeliveryHour { get; set; }
        public TimeSpan EndingDeliveryHour { get; set; }
    }
}