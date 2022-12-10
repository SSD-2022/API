using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// This class will handle all calls made to api/MedicalHistories
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoriesController : ControllerBase
    { 
        private readonly DbContext_dpal _context;

        /// <summary>
        /// getting context to database through constructor
        /// </summary>
        /// <param name="context"></param>
        public MedicalHistoriesController(DbContext_dpal context)
        {
            _context = context;
        }

        // GET: api/MedicalHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalHistory>>> GetMedicalHistory()
        {
            return await _context.MedicalHistory.ToListAsync();
        }

        // GET: api/MedicalHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalHistory>> GetMedicalHistory(Guid id)
        {
            var medicalHistory = await _context.MedicalHistory.FindAsync(id);

            if (medicalHistory == null)
            {
                return NotFound();
            }

            return medicalHistory;
        }

        // PUT: api/MedicalHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalHistory(Guid id, MedicalHistory medicalHistory)
        {
            if (id != medicalHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalHistoryExists(id))
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

        // POST: api/MedicalHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MedicalHistory>> PostMedicalHistory(MedicalHistory medicalHistory)
        {
            _context.MedicalHistory.Add(medicalHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalHistory", new { id = medicalHistory.Id }, medicalHistory);
        }

        // DELETE: api/MedicalHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalHistory>> DeleteMedicalHistory(Guid id)
        {
            var medicalHistory = await _context.MedicalHistory.FindAsync(id);
            if (medicalHistory == null)
            {
                return NotFound();
            }

            _context.MedicalHistory.Remove(medicalHistory);
            await _context.SaveChangesAsync();

            return medicalHistory;
        }

        private bool MedicalHistoryExists(Guid id)
        {
            return _context.MedicalHistory.Any(e => e.Id == id);
        }
    }
}
