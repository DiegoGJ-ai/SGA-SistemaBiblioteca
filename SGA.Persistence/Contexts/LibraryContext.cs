using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;

namespace SGA.Persistence.Context;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Ejemplar> Ejemplares => Set<Ejemplar>();
    public DbSet<Prestamo> Prestamos => Set<Prestamo>();
    public DbSet<Reserva> Reservas => Set<Reserva>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Autor>(e =>
        {
            e.ToTable("Autores");
            e.HasKey(x => x.Id);
            e.Property(x => x.Nombre).IsRequired().HasMaxLength(150);
        });

        b.Entity<Libro>(e =>
        {
            e.ToTable("Libros");
            e.HasKey(x => x.Id);
            e.Property(x => x.Titulo).IsRequired().HasMaxLength(200);
            e.HasOne(x => x.Autor)
             .WithMany(a => a.Libros)
             .HasForeignKey(x => x.AutorId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Ejemplar>(e =>
        {
            e.ToTable("Ejemplares");
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Libro)
             .WithMany(l => l.Ejemplares)
             .HasForeignKey(x => x.LibroId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Prestamo>(e =>
        {
            e.ToTable("Prestamos");
            e.HasKey(x => x.Id);
            e.Property(x => x.Fecha).IsRequired();
            e.Property(x => x.Vence).IsRequired();
            e.HasOne(x => x.Ejemplar)
             .WithMany()
             .HasForeignKey(x => x.EjemplarId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Reserva>(e =>
        {
            e.ToTable("Reservas");
            e.HasKey(x => x.Id);
            e.Property(x => x.Fecha).IsRequired();
            e.HasOne(x => x.Libro)
             .WithMany()
             .HasForeignKey(x => x.LibroId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
