using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TarefasSistemas.Models;

namespace TarefasSistemas.Data.Map
{
    public class ComentarioMap : IEntityTypeConfiguration<ComentarioModel>
    {
        public void Configure(EntityTypeBuilder<ComentarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Comment).IsRequired();
            builder.Property(x => x.MovieId).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
        }
    }
}
