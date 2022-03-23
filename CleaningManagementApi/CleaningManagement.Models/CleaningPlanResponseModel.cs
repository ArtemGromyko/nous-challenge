using System;

namespace CleaningManagement.Models
{
    public class CleaningPlanResponseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime CreationdDate { get; set; } = DateTime.UtcNow;
    }
}
