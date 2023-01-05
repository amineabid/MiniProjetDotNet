using InterventionsApi.Data;
using InterventionsApi.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace InterventionsApi.Consumer
{
    public class ReclamationCreatedConsumer : IConsumer<ReclamationCreated>
    {
        private readonly ApplicationDbContext _context;
        public ReclamationCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<ReclamationCreated> context)
        {
            if (context.Message.action == "Add")
            {
                var newProduct = new Reclamation
                {
                    Id = context.Message.Id,
                    Name = context.Message.Name,
                    Email = context.Message.Email,
                    Description = context.Message.Description,
                    ArticleId = context.Message.ArticleId
                };
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Delete")
            {
                var deleted = await _context.Reclamation.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                _context.Reclamation.Remove(deleted);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Put")
            {
                var updated = await _context.Reclamation.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                updated.Name = context.Message.Name;
                updated.Email = context.Message.Email;
                updated.Description = context.Message.Description;
                updated.ArticleId = context.Message.ArticleId;
                _context.Reclamation.Update(updated);
                await _context.SaveChangesAsync();
            }
        }
    }
}