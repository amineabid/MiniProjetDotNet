using FacturesApi.Data;
using FacturesApi.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace FacturesApi.Consumer
{
    public class PieceCreatedConsumer : IConsumer<PieceCreated>
    {
        private readonly ApplicationDbContext _context;
        public PieceCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<PieceCreated> context)
        {
            if (context.Message.action == "Add")
            {
                var newProduct = new Piece
                {
                    Id=context.Message.Id,
                    Name = context.Message.Name,
                    price = context.Message.price,
                    ArticleId = context.Message.articleId
                };
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Delete")
            {
                var deleted = await _context.Piece.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                if (deleted!=null)
                {
                    _context.Piece.Remove(deleted);
                    await _context.SaveChangesAsync();
                }

            }
            else if (context.Message.action == "Put")
            {
                var updated = await _context.Piece.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                if (updated!=null)
                {
                    updated.Name = context.Message.Name;
                    updated.price = context.Message.price;
                    updated.ArticleId = context.Message.articleId;
                    _context.Piece.Update(updated);
                    await _context.SaveChangesAsync();
                }

            }
        }
    }
}
