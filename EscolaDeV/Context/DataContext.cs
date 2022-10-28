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

            builder.Entity<User>()
                .Property(x => x.PrimeiroNome).IsRequired();

            builder.Entity<Curso>()
                .HasOne(x => x.Professor)
                .WithMany(x => x.CursosProfessor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Curso>()
                .HasMany(x => x.Estudantes)
                .WithMany(x => x.CursoEstudando)
                .UsingEntity<EstudanteCurso>()
                .HasOne(x => x.Estudante)
                .WithMany(x => x.EstudanteCursos)
                .HasForeignKey(x => x.EstudanteId);

            builder.Entity<EstudanteCurso>()
                .HasOne(x => x.Curso)
                .WithMany(x => x.EstudanteCursos)
                .HasForeignKey(x => x.CursoId);

            builder.Entity<EstudanteCurso>()
                .HasKey(x => new { x.EstudanteId, x.CursoId });
        }
    }
}
