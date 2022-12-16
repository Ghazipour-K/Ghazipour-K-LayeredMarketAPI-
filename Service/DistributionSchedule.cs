using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Model;
using Market.Repository;

namespace Market.Service
{
    public class DistributionSchedule : IDistributionSchedule
    {
        private readonly IGenericRepository<DistributionScheduleTable> _genericDistributionScheduleRepository = null;

        public DistributionSchedule(IGenericRepository<DistributionScheduleTable> repository)
        {
            _genericDistributionScheduleRepository = repository;
        }

        public bool Find(int scheduleID)
        {
            var result = _genericDistributionScheduleRepository.GetById(scheduleID) == null ? false : true;

            return result;
        }

        public List<DistributionScheduleViewModel> GetAll()
        {
            List<DistributionScheduleViewModel> distributionSchedules;
            distributionSchedules = _genericDistributionScheduleRepository.GetAll()
                .Select(
                s => new DistributionScheduleViewModel
                {
                    DistributionScheduleID = s.ID,
                    DeliveryDate = s.DeliveryDate,
                    StartingDeliveryHour = s.StartingDeliveryHour,
                    EndingDeliveryHour = s.EndingDeliveryHour
                }).ToList();
            return distributionSchedules;
        }

        public void Add(CreateDistributionScheduleViewModel scheduleView)
        {

            var schedule = new DistributionScheduleTable
            {
                DeliveryDate = scheduleView.DeliveryDate,
                StartingDeliveryHour = scheduleView.StartingDeliveryHour,
                EndingDeliveryHour = scheduleView.EndingDeliveryHour
            };

            _genericDistributionScheduleRepository.Insert(schedule);
            _genericDistributionScheduleRepository.Save();
        }

        public async Task<bool> FindAsync(int scheduleID)
        {
            var result = await _genericDistributionScheduleRepository.GetByIdAsync(scheduleID) == null ? false : true;

            return result;
        }

        public async Task<List<DistributionScheduleViewModel>> GetAllAsync()
        {
            List<DistributionScheduleViewModel> distributionSchedules;
            try
            {
                distributionSchedules = (await _genericDistributionScheduleRepository.GetAllAsync())
                    .Select(
                    s => new DistributionScheduleViewModel
                    {
                        DistributionScheduleID = s.ID,
                        DeliveryDate = s.DeliveryDate,
                        StartingDeliveryHour = s.StartingDeliveryHour,
                        EndingDeliveryHour = s.EndingDeliveryHour
                    }).ToList();
                return distributionSchedules;
            }
            catch
            {
                throw new Exception("Error on fetching data!");
            }
        }

        public async Task AddAsync(CreateDistributionScheduleViewModel scheduleView)
        {
            try
            {
                var schedule = new DistributionScheduleTable
                {
                    DeliveryDate = scheduleView.DeliveryDate,
                    StartingDeliveryHour = scheduleView.StartingDeliveryHour,
                    EndingDeliveryHour = scheduleView.EndingDeliveryHour
                };

                _genericDistributionScheduleRepository.Insert(schedule);
                await _genericDistributionScheduleRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}