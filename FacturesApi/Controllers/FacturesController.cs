using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacturesApi.Data;
using FacturesApi.Models;
using Newtonsoft.Json;

namespace FacturesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Factures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facture>>> GetFacture()
        {
            var factures = await _context.Facture.Include(a => a.LigneFactures).ThenInclude(a => a.Piece).Include(a => a.Intervention).ThenInclude(r => r.Reclamation).ToListAsync();
            var jsonString = JsonConvert.SerializeObject(factures, Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
            List<Facture> ordd = JsonConvert.DeserializeObject<List<Facture>>(jsonString);

            return ordd;
        }

        // GET: api/Factures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facture>> GetFacture(int id)
        {
            var facture = await _context.Facture.Include(a=>a.LigneFactures).ThenInclude(a=>a.Piece).Include(a=>a.Intervention).ThenInclude(r=>r.Reclamation).FirstOrDefaultAsync(a=>a.Id==id);

            if (facture == null)
            {
                return NotFound();
            }
            var jsonString = JsonConvert.SerializeObject(facture, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            Facture ordd = JsonConvert.DeserializeObject<Facture>(jsonString);

            return ordd;
        }

        // PUT: api/Factures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacture(int id, Facture facture)
        {
            if (id != facture.Id)
            {
                return BadRequest();
            }

            _context.Entry(facture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactureExists(id))
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

        // POST: api/Factures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facture>> PostFacture(Facture facture)
        {
            _context.Facture.Add(facture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacture", new { id = facture.Id }, facture);
        }

        // DELETE: api/Factures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacture(int id)
        {
            var facture = await _context.Facture.Include(a=>a.LigneFactures).FirstOrDefaultAsync(i=>i.Id==id);
            if (facture == null)
            {
                return NotFound();
            }

            _context.Facture.Remove(facture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactureExists(int id)
        {
            return _context.Facture.Any(e => e.Id == id);
        }
    }
}
