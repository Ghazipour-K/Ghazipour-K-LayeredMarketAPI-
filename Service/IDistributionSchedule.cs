using Market.Model;
using System.Collections.Generic;

namespace Market.Service
{
    public interface IDistributionSchedule
    {
        bool Find(string scheduleID);
        List<DistributionScheduleViewModel> GetAll();
        void Add(DistributionScheduleViewModel scheduleView);
    }
}
