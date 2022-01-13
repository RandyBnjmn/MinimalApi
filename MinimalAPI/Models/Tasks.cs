using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required]
        public string Task { get; set; } = String.Empty;
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public string Description { get; set; } = String.Empty;
    
    }
}
