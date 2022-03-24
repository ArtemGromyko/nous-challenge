using System;

namespace CleaningManagement.DomainModel.Entities
{
    public class CleaningPlan
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
