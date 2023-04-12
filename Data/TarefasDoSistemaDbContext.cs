using Microsoft.EntityFrameworkCore;
using TarefasSistemas.Data.Map;
using TarefasSistemas.Models;

namespace TarefasSistemas.Data
{
    public class TarefasDoSistemaDbContext : DbContext
    {
        public TarefasDoSistemaDbContext(DbContextOptions<TarefasDoSistemaDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var isValid = modelBuilder;
            isValid.Entity<UsuarioModel>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new MovieMap()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
