using CursoOnline.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Dados.Contextos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
