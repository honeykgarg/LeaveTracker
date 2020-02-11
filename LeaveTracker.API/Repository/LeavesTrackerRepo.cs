using LeaveTracker.API.DbContexts;
using LeaveTracker.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveTracker.API.Repository
{
    public class LeavesTrackerRepo : ILeavesTrackerRepo
    {
        private readonly LeaveTrackerDbContext _context;

        public LeavesTrackerRepo(LeaveTrackerDbContext leaveTrackerDbContext)
        {
            _context = leaveTrackerDbContext;
        }

        public void AddLeave(string EmpId, Leave leave)
        {
            throw new NotImplementedException();
        }

        public void DeleteLeave(Leave leave)
        {
            throw new NotImplementedException();
        }

        public bool EmployeeExists(string EmpId)
        {
            if (EmpId == null)
            {
                throw new ArgumentNullException(nameof(EmpId));
            }
            return _context.Employees.Any(e => e.EmpId == EmpId);
        }

        public Employee GetEmployee(string EmpId)
        {
            if(EmpId == null)
            {
                throw new ArgumentNullException(nameof(EmpId));
            }
            return _context.Employees.FirstOrDefault(e => e.EmpId == EmpId);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList<Employee>();
        }

        public Leave GetLeave(string EmpId, Guid LeaveEntryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Leave> GetLeaves(string EmpId)
        {
           if(EmpId == null)
            {
                throw new ArgumentNullException(nameof(EmpId));
            }
            return _context.Leaves.Where(l => l.EmpId == EmpId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLeave(Leave leave)
        {
            throw new NotImplementedException();
        }
    }
}
