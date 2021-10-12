using BiblioCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EntityFramework
{
    public class BiblioContext:DbContext
    {
        public DbSet<Libro> Libri { get; set; }
        public BiblioContext() : base() { }
        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder op)
        {
            if (!op.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                string connectionStringSQL = config.GetConnectionString("AcademyG");

                op.UseLazyLoadingProxies();
                op.UseSqlServer(connectionStringSQL);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            var e = mb.Entity<Libro>();

            e.HasKey(l => l.Id);
            e.Property(l => l.Isbn).HasMaxLength(50).IsRequired();
            e.Property(l => l.Autore).HasMaxLength(50).IsRequired();
            e.Property(l => l.Sommario).HasMaxLength(50).IsRequired();
            e.Property(l => l.Titolo).HasMaxLength(50).IsRequired();
        }
    }
}
