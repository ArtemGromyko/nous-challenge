using CleaningManagement.BLL.Contracts;
using CleaningManagement.DomainModel.Entities;
using CleaningManagement.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Services
{
    public class CleaningPlanService : ICleaningPlanService
    {
        private readonly ICleaningPlanRepository _cleaningPlanRepository;

        public CleaningPlanService(ICleaningPlanRepository cleaningPlanRepository)
        {
            _cleaningPlanRepository = cleaningPlanRepository;
        }

        public async Task<CleaningPlan> CreateCleaningPlanAsync(CleaningPlan cleaningPlan)
        {
           return await _cleaningPlanRepository.CreateCleaningPlanAsync(cleaningPlan);
        }

        public async Task DeleteCleaningPlanAsync(CleaningPlan cleaningPlan)
        {
            await _cleaningPlanRepository.DeleteCleaningPlanAsync(cleaningPlan);
        }

        public async Task<List<CleaningPlan>> GetAllCleaningPlansForCustomerAsync(int customerId)
        {
            return await _cleaningPlanRepository.GetAllCleaningPlansForCustomerAsync(customerId);
        }

        public async Task<CleaningPlan> GetCleaningPlanByIdAsync(Guid id)
        {
            return await _cleaningPlanRepository.GetCleaningPlanByIdAsync(id);
        }

        public async Task<CleaningPlan> GetCleaningPlanForCustomerByIdAsync(int customerId, Guid Id)
        {
            return await _cleaningPlanRepository.GetCleaningPlanForCustomerByIdAsync(customerId, Id);
        }

        public async Task UpdateCleaningPlanAsync(CleaningPlan cleaningPlan)
        {
            await _cleaningPlanRepository.UpdateCleaningPlanAsync(cleaningPlan);
        }
    }
}
