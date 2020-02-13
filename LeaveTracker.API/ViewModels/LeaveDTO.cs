using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveTracker.API.ViewModels
{
    public class LeaveDto

    {
        
        public Guid LeaveEntryId { get; set; }

        
        public DateTime LeaveStartDate { get; set; }
        
        
        public DateTime LeaveEndDate { get; set; }

        
        public string LeaveReason { get; set; }

        
        public string IsHalfDayLeave { get; set; }

        public string EmpId { get; set; }

    }
}
