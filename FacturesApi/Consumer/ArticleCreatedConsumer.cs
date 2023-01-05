using FacturesApi.Data;
using FacturesApi.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace FacturesApi.Consumer
{
    public class ArticleCreatedConsumer : IConsumer<ArticleCreated>
    {
        private readonly ApplicationDbContext _context;
        public ArticleCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<ArticleCreated> context)
        {
            if (context.Message.action == "Add")
            {
                var newProduct = new Article
                {
                    Id = context.Message.Id,
                    Name = context.Message.Name
                };
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Delete")
            {
                var lignFacts = await _context.Piece.Where(a => a.ArticleId == context.Message.Id).ToListAsync();
                foreach (var i in lignFacts)
                {
                    _context.Piece.Remove(i);
                    await _context.SaveChangesAsync();
                }
                var deleted = await _context.Article.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                _context.Article.Remove(deleted);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Put")
            {
                var updated = await _context.Article.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                updated.Name = context.Message.Name;
                _context.Article.Update(updated);
                await _context.SaveChangesAsync();
            }
        }
    }
}
