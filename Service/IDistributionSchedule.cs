using Market.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IDistributionSchedule
    {
        bool Find(int scheduleID);
        List<DistributionScheduleViewModel> GetAll();
        void Add(CreateDistributionScheduleViewModel scheduleView);

        Task<bool> FindAsync(int scheduleID);
        Task<List<DistributionScheduleViewModel>> GetAllAsync();
        Task AddAsync(CreateDistributionScheduleViewModel scheduleView);
    }
}
