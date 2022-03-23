using CleaningManagement.DAL.Contracts;
using CleaningManagement.DomainModel.Entities;
using CleaningManagement.DomainModel.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleaningManagement.DAL.Repositories
{
    public class CleaningPlanRepository : RepositoryBase<CleaningPlan>, ICleaningPlanRepository
    {
        public CleaningPlanRepository(CleaningManagementDbContext cleaningManagementDbContext) : 
            base(cleaningManagementDbContext) { }

        public async Task CreateCleaningPlanAsync(CleaningPlan cleaningPlan)
        {
            await CreateAsync(cleaningPlan);
        }

        public async Task DeleteCleaningPlanAsync(CleaningPlan cleaningPlan)
        {
            await DeleteAsync(cleaningPlan);
        }

        public async Task<List<CleaningPlan>> GetAllCleaningPlansForCustomerAsync(int customerId) =>
            await FindByCondition(cp => cp.CustomerId.Equals(customerId)).ToListAsync();

        public async Task<CleaningPlan> GetCleaningPlanByIdAsync(Guid id) =>
            await FindByCondition(cp => cp.Id.Equals(id)).SingleOrDefaultAsync();
    }
}
