using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacturesApi.Data;
using FacturesApi.Models;

namespace FacturesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigneFacturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LigneFacturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LigneFactures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LigneFacture>>> GetLigneFacture()
        {
            return await _context.LigneFacture.ToListAsync();
        }

        // GET: api/LigneFactures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LigneFacture>> GetLigneFacture(int id)
        {
            var ligneFacture = await _context.LigneFacture.FindAsync(id);

            if (ligneFacture == null)
            {
                return NotFound();
            }

            return ligneFacture;
        }

        // PUT: api/LigneFactures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLigneFacture(int id, LigneFacture ligneFacture)
        {
            if (id != ligneFacture.id)
            {
                return BadRequest();
            }

            _context.Entry(ligneFacture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LigneFactureExists(id))
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

        // POST: api/LigneFactures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LigneFacture>> PostLigneFacture(LigneFacture ligneFacture)
        {
            _context.LigneFacture.Add(ligneFacture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLigneFacture", new { id = ligneFacture.id }, ligneFacture);
        }

        // DELETE: api/LigneFactures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLigneFacture(int id)
        {
            var ligneFacture = await _context.LigneFacture.FindAsync(id);
            if (ligneFacture == null)
            {
                return NotFound();
            }

            _context.LigneFacture.Remove(ligneFacture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LigneFactureExists(int id)
        {
            return _context.LigneFacture.Any(e => e.id == id);
        }
    }
}
