using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticleApi.Data;
using ArticleApi.Models;

namespace ArticleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiecesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PiecesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pieces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piece>>> GetPiece()
        {
            return await _context.Piece.ToListAsync();
        }

        // GET: api/Pieces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Piece>> GetPiece(int id)
        {
            var piece = await _context.Piece.FindAsync(id);

            if (piece == null)
            {
                return NotFound();
            }

            return piece;
        }

        // PUT: api/Pieces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiece(int id, Piece piece)
        {
            if (id != piece.Id)
            {
                return BadRequest();
            }

            _context.Entry(piece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceExists(id))
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

        // POST: api/Pieces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Piece>> PostPiece(Piece piece)
        {
            _context.Piece.Add(piece);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiece", new { id = piece.Id }, piece);
        }

        // DELETE: api/Pieces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiece(int id)
        {
            var piece = await _context.Piece.FindAsync(id);
            if (piece == null)
            {
                return NotFound();
            }

            _context.Piece.Remove(piece);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PieceExists(int id)
        {
            return _context.Piece.Any(e => e.Id == id);
        }
    }
}
