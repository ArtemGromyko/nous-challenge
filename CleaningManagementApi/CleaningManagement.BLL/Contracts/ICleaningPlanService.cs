using CleaningManagement.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Contracts
{
    public interface ICleaningPlanService
    {
        Task<CleaningPlan> CreateCleaningPlanAsync(CleaningPlan cleaningPlan);
        Task<List<CleaningPlan>> GetAllCleaningPlansForCustomerAsync(int customerId);
        Task<CleaningPlan> GetCleaningPlanByIdAsync(Guid id);
        Task DeleteCleaningPlanAsync(CleaningPlan cleaningPlan);
        Task UpdateCleaningPlanAsync(CleaningPlan cleaningPlan);
        Task<CleaningPlan> GetCleaningPlanForCustomerByIdAsync(int customerId, Guid Id);
    }
}
