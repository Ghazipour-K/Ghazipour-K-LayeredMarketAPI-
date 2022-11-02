using Market.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IDistributionSchedule
    {
        bool Find(string scheduleID);
        List<DistributionScheduleViewModel> GetAll();
        void Add(DistributionScheduleViewModel scheduleView);

        Task<bool> FindAsync(string scheduleID);
        Task<List<DistributionScheduleViewModel>> GetAllAsync();
        Task AddAsync(DistributionScheduleViewModel scheduleView);
    }
}
