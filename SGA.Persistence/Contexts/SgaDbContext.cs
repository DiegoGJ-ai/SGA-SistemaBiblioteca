using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;

namespace SGA.Persistence.Contexts
{
    public class SgaDbContext : DbContext
    {
        public SgaDbContext(DbContextOptions<SgaDbContext> options) : base(options) { }

        // DbSets de ejemplo (agrega más luego)
        public DbSet<Libro> Libros => Set<Libro>();

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // modelBuilder.ApplyConfigurationsFromAssembly(typeof(SgaDbContext).Assembly);
        // }
    }
}
