using LeaveTracker.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveTracker.API.Repository
{
    public interface ILeavesTrackerRepo
    {

        public IEnumerable<Employee> GetEmployees();
        public Employee GetEmployee(string EmpId);
        public bool EmployeeExists(string EmpId);


        public IEnumerable<Leave> GetLeaves(string EmpId);
        public Leave GetLeave(string EmpId, Guid LeaveEntryId);
        public void AddLeave(string EmpId, Leave leave);
        public void UpdateLeave(Leave leave);
        public void DeleteLeave(Leave leave);

        bool Save();
    }
}
