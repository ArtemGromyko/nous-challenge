using CleaningManagement.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleaningManagement.DomainModel.Repositories
{
    public interface ICleaningPlanRepository
    {
        Task CreateCleaningPlanAsync(CleaningPlan cleaningPlan);
        Task<List<CleaningPlan>> GetAllCleaningPlansForCustomerAsync(int customerId);
        Task<CleaningPlan> GetCleaningPlanByIdAsync(Guid id);
        Task DeleteCleaningPlanAsync(CleaningPlan cleaningPlan);
    }
}
