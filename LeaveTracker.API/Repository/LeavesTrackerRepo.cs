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
            if (String.IsNullOrWhiteSpace(EmpId))
            {
                throw new ArgumentNullException(nameof(EmpId));
            };

            if (LeaveEntryId == null)
            {
                throw new ArgumentNullException(nameof(LeaveEntryId));
            };

            var leave = _context.Leaves.FirstOrDefault(l => l.LeaveEntryId == LeaveEntryId && l.EmpId == EmpId);

             //List<int> enumValues =  default(LeaveStatus).GetType().GetEnumValues();
            

            return leave;

        }

        public IEnumerable<Leave> GetLeaves(string EmpId)
        {
           if(EmpId == null)
            {
                throw new ArgumentNullException(nameof(EmpId));
            }
            return _context.Leaves.Where(l => l.EmpId == EmpId).ToList();
        }

        public void AddLeave(string empId, Leave leave)
        {
            if(empId == null)
            {
                throw new ArgumentNullException(nameof(empId));
            }
            if(leave == null)
            {
                throw new ArgumentNullException(nameof(leave));
            }

            leave.EmpId = empId;

            leave.LeaveEntryAddedOrUpdatedTime = DateTime.Now;

            leave.Status = LeaveStatus.Pending;

            _context.Leaves.Add(leave);

        }

        public void DeleteLeave(Leave leave)
        {
            _context.Leaves.Remove(leave);
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
