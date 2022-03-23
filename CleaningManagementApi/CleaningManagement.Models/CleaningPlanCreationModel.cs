using System.ComponentModel.DataAnnotations;

namespace CleaningManagement.Models
{
    internal class CleaningPlanCreationModel
    {
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
    }
}
