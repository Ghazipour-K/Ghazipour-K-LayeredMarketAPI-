using Market.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IDistributionSchedule
    {
        bool Find(string scheduleID);
        List<DistributionScheduleViewModel> GetAll();
        void Add(DistributionScheduleViewModel scheduleView);
    }
}
