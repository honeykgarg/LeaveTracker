using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveTracker.API.Models
{
    public enum LeaveStatus
    {
        Approved, 
        Pending,
        Rejected
    }

    public class Leave
    {

        [Key]
        public Guid LeaveEntryId { get; set; }

        [Required]
        public DateTime LeaveStartDate { get; set; }
        [Required]
        public DateTime LeaveEndDate { get; set; }
        [Required]
        public DateTime LeaveEntryAddedOrUpdatedTime { get; set; }

        [Required]
        public LeaveStatus Status { get; set; }
        
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }

        public string EmpId { get; set; }
    }
}
