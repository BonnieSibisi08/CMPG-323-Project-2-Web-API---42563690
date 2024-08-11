using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_2_Web_API___42563690.Data;
using Project_2_Web_API___42563690.Repository.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Buffers.Text;


namespace Project_2_Web_API___42563690.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTelemetriesController : ControllerBase
    {
        private readonly TelemetryContext _context;

        public JobTelemetriesController(TelemetryContext context)
        {
            _context = context;
        }

        // GET: api/JobTelemetries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetJobTelemetries()
        {
            return await _context.JobTelemetries.ToListAsync();
        }

        // GET: api/JobTelemetries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            return jobTelemetry;
        }

        // PUT: api/JobTelemetries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //GET method that will retrieve one Telemetry from the database based on the ID parsed through
        public async Task<IActionResult> PutJobTelemetry(int id, JobTelemetry jobTelemetry)
        {
            if (id != jobTelemetry.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTelemetry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
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

        // POST: api/JobTelemetries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            _context.JobTelemetries.Add(jobTelemetry);
            // Save the changes to the database
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobTelemetry", new { id = jobTelemetry.Id }, jobTelemetry);
        }

        // PATCH: api/JobTelemetry/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(int id, [FromBody] JsonPatchDocument<JobTelemetry> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (jobTelemetry == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(jobTelemetry, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
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


        // DELETE: api/JobTelemetries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (jobTelemetry == null)
            {
                return NotFound();
            }

            _context.JobTelemetries.Remove(jobTelemetry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //method that checks if a Telemetry exists(based on the ID parsed through) before editing or deleting an item
        private bool JobTelemetryExists(int id)
        {
            return _context.JobTelemetries.Any(e => e.Id == id);
        }

        //GET method
        [HttpGet("GetProjectSavings")]
        public async Task<IActionResult> GetProjectSavings(Guid projectId, DateTime startDate, DateTime endDate)
        {
            // Validate the input dates
            if (startDate > endDate)
            {
                return BadRequest("Start date cannot be greater than end date.");
            }

            // Query the telemetry data for the specified project and date range
            var telemetryEntries = await _context.JobTelemetries
                .Where(jt => jt.ProjectID == projectId && jt.EntryDate >= startDate && jt.EntryDate <= endDate)
                .ToListAsync();

            if (telemetryEntries == null || telemetryEntries.Count == 0)
            {
                return NotFound("No telemetry entries found for the specified criteria.");
            }

            // Calculate cumulative time saved and cost saved
            var cumulativeTimeSaved = telemetryEntries.Sum(jt => jt.HumanTime ?? 0);

            // Assuming a cost savings calculation based on an hourly rate (e.g., $50/hour)
            decimal hourlyRate = 50m;
            var cumulativeCostSaved = cumulativeTimeSaved * hourlyRate;

            // Return the result as an anonymous object
            return Ok(new
            {
                ProjectID = projectId,
                StartDate = startDate,
                EndDate = endDate,
                CumulativeTimeSaved = cumulativeTimeSaved,
                CumulativeCostSaved = cumulativeCostSaved
            });
        }

        //
        [HttpGet("GetClientSavings")]
        public async Task<IActionResult> GetSavings(Guid clientId, DateTime startDate, DateTime endDate)
        {
            // Validate the input dates
            if (startDate > endDate)
            {
                return BadRequest("Start date cannot be greater than end date.");
            }

            // Query the telemetry data for the specified client and date range
            var telemetryEntries = await _context.JobTelemetries
                .Include(jt => jt.Project) // Ensure the related Project data is included
                .Where(jt => jt.Project.ClientID == clientId && jt.EntryDate >= startDate && jt.EntryDate <= endDate)
                .ToListAsync();

            if (telemetryEntries == null || telemetryEntries.Count == 0)
            {
                return NotFound("No telemetry entries found for the specified criteria.");
            }

            // Calculate cumulative time saved and cost saved
            var cumulativeTimeSaved = telemetryEntries.Sum(jt => jt.HumanTime ?? 0);

            // Assuming a cost savings calculation based on an hourly rate (e.g., $50/hour)
            decimal hourlyRate = 50m;
            var cumulativeCostSaved = cumulativeTimeSaved * hourlyRate;

            // Return the result as an anonymous object
            return Ok(new
            {
                ClientID = clientId,
                StartDate = startDate,
                EndDate = endDate,
                CumulativeTimeSaved = cumulativeTimeSaved,
                CumulativeCostSaved = cumulativeCostSaved
            });
        }


    }
}
