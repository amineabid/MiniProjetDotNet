using FacturesApi.Data;
using FacturesApi.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace FacturesApi.Consumer
{
    public class InterventionCreatedConsumer : IConsumer<InterventionCreated>
    {
        private readonly ApplicationDbContext _context;
        public InterventionCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<InterventionCreated> context)
        {
            if (context.Message.action == "Add")
            {
                var newProduct = new Intervention
                {
                    Id = context.Message.Id,
                    Description = context.Message.Description,
                    garantie = context.Message.garnatie,
                    ReclamationId = context.Message.ReclamationId
                };
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Delete")
            {
                var deleted = await _context.Intervention.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                if (deleted!=null)
                {
                    _context.Intervention.Remove(deleted);
                    await _context.SaveChangesAsync();
                }

            }
            else if (context.Message.action == "Put")
            {
                var updated = await _context.Intervention.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                if (updated!=null)
                {
                    updated.Description = context.Message.Description;
                    updated.garantie = context.Message.garnatie;
                    updated.ReclamationId = context.Message.ReclamationId;
                    _context.Intervention.Update(updated);
                    await _context.SaveChangesAsync();
                }

            }


        }
    }
}