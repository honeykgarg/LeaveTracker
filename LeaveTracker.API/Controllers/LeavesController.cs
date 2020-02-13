using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveTracker.API.Models;
using LeaveTracker.API.ViewModels;
using LeaveTracker.API.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveTracker.API.Controllers
{
    [ApiController]
    [Route("api/employees/{empId}/leaves")]
    public class LeavesController : ControllerBase
    {
        private readonly ILeavesTrackerRepo _repo;
        private readonly IMapper _mapper;
        public LeavesController(ILeavesTrackerRepo leavesTrackerRepo, IMapper mapper)
        {
            _repo = leavesTrackerRepo;
            _mapper = mapper;        }

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
        [HttpGet("{leaveId}", Name ="GetLeaveForEmployee")]
        public ActionResult<Leave> GetLeaveForEmployee(string empId, Guid leaveId)
        {
            bool empExists = _repo.EmployeeExists(empId);
            if (!empExists)
            {
                return NotFound();
            }
            var leaveFromRepo = _repo.GetLeave(empId, leaveId);
            if (leaveFromRepo == null)
            {
                return NotFound();
            }

            return Ok(leaveFromRepo);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<LeaveDto> AddLeaveForEmployee(string empId, [FromBody] LeaveDto leaveDto)
        {
            //if(leaveDto == null)
            //{
            //    return NotFound();
            //}

            if(!_repo.EmployeeExists(empId))
            {
                //need to send custom error message in response -- pending
                return NotFound();
            }
            var entityLeave = _mapper.Map<Leave>(leaveDto);

            _repo.AddLeave(empId, entityLeave);
            _repo.Save();

            var leaveToReturn = _mapper.Map<LeaveDto>(entityLeave);

            return CreatedAtRoute("GetLeaveForEmployee",
                        new { empId = empId, leaveId = leaveToReturn.LeaveEntryId },
                        leaveToReturn);
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
