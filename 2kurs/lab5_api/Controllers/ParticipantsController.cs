using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab5_api.Models;

namespace lab5_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly APMSSQLMYDBMDFContext _context;

        public ParticipantsController(APMSSQLMYDBMDFContext context)
        {
            _context = context;
        }

        // GET: api/Participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participants>>> GetParticipants()
        {
            return await _context.Participants.ToListAsync();
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participants>> GetParticipants(int id)
        {
            var Participants = await _context.Participants.FindAsync(id);

            if (Participants == null)
            {
                return NotFound();
            }

            return Participants;
        }

        // PUT: api/Participants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipants(int id, Participants Participants)
        {
            if (id != Participants.Id)
            {
                return BadRequest();
            }

            _context.Entry(Participants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantsExists(id))
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

        // POST: api/Participants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Participants>> PostParticipants(Participants Participants)
        {
            _context.Participants.Add(Participants);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipantsExists(Participants.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParticipants", new { id = Participants.Id }, Participants);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Participants>> DeleteParticipants(int id)
        {
            var Participants = await _context.Participants.FindAsync(id);
            if (Participants == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(Participants);
            await _context.SaveChangesAsync();

            return Participants;
        }

        private bool ParticipantsExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}
