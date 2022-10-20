using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Find(string scheduleID)
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
                    ID = s.ID,
                    DeliveryDate = s.DeliveryDate,
                    StartingDeliveryHour = s.StartingDeliveryHour,
                    EndingDeliveryHour = s.EndingDeliveryHour
                }).ToList();
            return distributionSchedules;
        }

        public void Add(DistributionScheduleViewModel scheduleView)
        {
            if (Find(scheduleView.ID))
            {
                throw new Exception("Schedule already exists!");
            }
            else
            {
                var schedule = new DistributionScheduleTable
                {
                    ID = scheduleView.ID,
                    DeliveryDate = scheduleView.DeliveryDate,
                    StartingDeliveryHour = scheduleView.StartingDeliveryHour,
                    EndingDeliveryHour = scheduleView.EndingDeliveryHour
                };

                _genericDistributionScheduleRepository.Insert(schedule);
                _genericDistributionScheduleRepository.Save();
            }
        }
    }
}