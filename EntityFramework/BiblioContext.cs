using BiblioCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EntityFramework
{
    public class BiblioContext:DbContext
    {
        public DbSet<Libro> Libri { get; set; }
        public DbSet<Prestito> Prestiti { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public BiblioContext() : base() { }
        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder op)
        {
            if (!op.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                string connectionStringSQL = config.GetConnectionString("AcademyG");
                op.UseSqlServer(connectionStringSQL);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // tabella libri

            var e = mb.Entity<Libro>();

            e.HasKey(l => l.Id);
            e.Property(l => l.Isbn).HasMaxLength(20).IsRequired();
            e.Property(l => l.Autore).HasMaxLength(100).IsRequired();
            e.Property(l => l.Sommario).HasMaxLength(500).IsRequired(false);
            e.Property(l => l.Titolo).HasMaxLength(200).IsRequired();

            // tabella prestiti

            var e2 = mb.Entity<Prestito>();

            e2.HasKey(p => p.Id);
            e2.Property(p => p.LibroId).IsRequired();
            e2.Property(p => p.UtenteId).IsRequired();
            e2.Property(p => p.DataPrestito).IsRequired();
            e2.Property(p => p.DataReso).IsRequired(false);

            //tabella utenti

            var e3 = mb.Entity<Utente>();

            e3.HasKey(u => u.Id);
            e3.Property(u => u.Nome).IsRequired().HasMaxLength(100);
            e3.Property(u => u.Cognome).IsRequired().HasMaxLength(100);
            e3.Property(u => u.DataIscrizione).IsRequired(false);

            // relazione 1 libro ha molti prestiti

            e.HasMany(l => l.Prestiti).WithOne(p => p.Libro);
            e2.HasOne(p => p.Libro).WithMany(l => l.Prestiti).HasForeignKey(p=>p.LibroId);

            // relazione 1 utente ha molti prestiti

            e3.HasMany(u => u.Prestiti).WithOne(p => p.Utente);
            e2.HasOne(p => p.Utente).WithMany(u => u.Prestiti).HasForeignKey(p=>p.UtenteId);
        }
    }
}
