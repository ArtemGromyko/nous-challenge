using System.ComponentModel.DataAnnotations;

namespace CleaningManagement.Models
{
    public class CleaningPlanUpdateModel
    {
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        public int CustomerId { get; set; }
    }
}
