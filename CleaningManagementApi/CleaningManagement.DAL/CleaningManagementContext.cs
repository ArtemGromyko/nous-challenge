using CleaningManagement.DAL.Configuration;
using CleaningManagement.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleaningManagement.DAL
{
    public class CleaningManagementDbContext : DbContext
    {
        public DbSet<CleaningPlan> CleaningPlans { get; set; }

        public string DbPath { get; }

        public CleaningManagementDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CleaningPlanConfiguration());
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase("CleaningContext");
    }
}