using EscolaDeV.Enums;
using EscolaDeV.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeV.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .Property(x => x.TipoUsuario)
                   .HasConversion(x => x.ToString(),
                                  x => (TipoUsuario)Enum.Parse(typeof(TipoUsuario), x));

        }



    }
}
