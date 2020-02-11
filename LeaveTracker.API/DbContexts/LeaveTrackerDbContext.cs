using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using LeaveTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveTracker.API.DbContexts
{
    public class LeaveTrackerDbContext : DbContext
    {
        public LeaveTrackerDbContext(DbContextOptions<LeaveTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    EmpId = "1801942",
                    Name = "Honey Kumar",
                    EmailId = "hkumar25@dxc.com"
                },
                new Employee()
                {
                    EmpId = "1801943",
                    Name = "Honey Garg",
                    EmailId = "hkumar27@dxc.com"
                }
            );
            modelBuilder.Entity<Leave>().HasData(
                new Leave()
                {
                    LeaveEntryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    LeaveStartDate = new DateTime(2020, 2, 20),
                    LeaveEndDate = new DateTime(2020, 2, 21),
                    LeaveEntryAddedOrUpdatedTime = DateTime.Now,
                    Status = LeaveStatus.Pending,
                    EmpId = "1801942"
                }) ;
            base.OnModelCreating(modelBuilder);

        }


    }
}
