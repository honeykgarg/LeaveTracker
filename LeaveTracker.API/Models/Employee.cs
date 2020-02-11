using System.ComponentModel.DataAnnotations;

namespace LeaveTracker.API.Models
{
    public class Employee
    {
        [Key]
        public string EmpId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

    }
}
