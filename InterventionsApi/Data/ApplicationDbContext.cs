using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InterventionsApi.Models;

namespace InterventionsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Reclamation> Reclamation { get; set; } = default!;

        public DbSet<Intervention> Intervention { get; set; } = default!;
    }
}
