using CleaningManagement.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CleaningManagement.DAL.Configuration
{
    public class CleaningPlanConfiguration : IEntityTypeConfiguration<CleaningPlan>
    {
        public void Configure(EntityTypeBuilder<CleaningPlan> builder)
        {
            builder.Property(cp => cp.Title).HasMaxLength(256).IsRequired();
            builder.Property(cp => cp.CustomerId).IsRequired();
            builder.Property(cp => cp.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(cp => cp.Description).HasMaxLength(512);

            builder.HasData
            (
                new CleaningPlan
                {
                    Id = new Guid("8c442581-c67a-41e5-8d2d-b1176de31087"),
                    Title = "Hotel Room Cleaning, double bed",
                    CustomerId = 123223,
                    Description = "This plan is meant to be used for double bed rooms.",
                    CreationDate = new DateTime(2015, 7, 20)
                }
            );
        }
    }
}
