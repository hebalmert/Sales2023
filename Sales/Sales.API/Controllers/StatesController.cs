using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [Route("api/states")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            if (_context.States == null)
            {
                return NotFound();
            }
            return await _context.States.Include(x => x.Cities).ToListAsync();
        }

        // GET: api/States/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            if (_context.States == null)
            {
                return NotFound();
            }
            var state = await _context.States
                .Include(x => x.Cities)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutState(State state)
        {
            try
            {

                _context.States.Update(state);
                await _context.SaveChangesAsync();
                return Ok(state);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya Existe un Estado con el mismo Nombre");
                }
                return BadRequest(dbUpdateException);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            try
            {
                if (_context.States == null)
                {
                    return BadRequest("No Existen Registros en Estado");
                }
                _context.States.Add(state);
                await _context.SaveChangesAsync();

                return Ok(state);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya Existe un Estado con el mismo Nombre");
                }
                return BadRequest(dbUpdateException);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/States/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            if (_context.States == null)
            {
                return NotFound();
            }
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
