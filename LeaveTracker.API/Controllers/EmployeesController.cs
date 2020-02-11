using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveTracker.API.Models;
using LeaveTracker.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveTracker.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILeavesTrackerRepo _repo;

        public EmployeesController(ILeavesTrackerRepo leavesTrackerRepo)
        {
            _repo = leavesTrackerRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(_repo.GetEmployees());
        }

        [HttpGet("{empId}")]
        public ActionResult<Employee> GetEmployee(string empId)
        {
            if(empId == null)
            {
                return NotFound(); 
            }
            var empFromRepo = _repo.GetEmployee(empId);
            if (empFromRepo == null) {
                return NotFound();
            }
            return Ok(empFromRepo);
        }



    }
}