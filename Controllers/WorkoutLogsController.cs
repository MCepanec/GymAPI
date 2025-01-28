using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymAPI.Models;

namespace GymAPI.Controllers
{
    [Route("api/v1/members/{memberId}/workoutlogs")]
    [ApiController]
    public class WorkoutLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkoutLogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutLog>>> GetWorkoutLog()
        {
            return await _context.WorkoutLog.ToListAsync();
        }

        // GET: api/WorkoutLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutLog>> GetWorkoutLog(int id)
        {
            var workoutLog = await _context.WorkoutLog.FindAsync(id);

            if (workoutLog == null)
            {
                return NotFound();
            }

            return workoutLog;
        }

        // PUT: api/WorkoutLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutLog(int id, WorkoutLog workoutLog)
        {
            if (id != workoutLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(workoutLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkoutLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutLog>> PostWorkoutLog(WorkoutLog workoutLog)
        {
            _context.WorkoutLog.Add(workoutLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutLog", new { id = workoutLog.Id }, workoutLog);
        }

        // DELETE: api/WorkoutLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutLog(int id)
        {
            var workoutLog = await _context.WorkoutLog.FindAsync(id);
            if (workoutLog == null)
            {
                return NotFound();
            }

            _context.WorkoutLog.Remove(workoutLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutLogExists(int id)
        {
            return _context.WorkoutLog.Any(e => e.Id == id);
        }
    }
}
