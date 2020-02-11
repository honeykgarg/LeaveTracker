using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveTracker.API.Models;
using LeaveTracker.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveTracker.API.Controllers
{
    [ApiController]
    [Route("api/employees/{empId}/leaves")]
    public class LeavesController : ControllerBase
    {
        private readonly ILeavesTrackerRepo _repo;
        public LeavesController(ILeavesTrackerRepo leavesTrackerRepo)
        {
            _repo = leavesTrackerRepo;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Leave>> GetLeavesForEmployee(string empId)
        {
            bool empExists = _repo.EmployeeExists(empId);
            if (!empExists)
            {
                return NotFound();
            }
            var leavesFromRepo = _repo.GetLeaves(empId);

            if(leavesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(leavesFromRepo);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
