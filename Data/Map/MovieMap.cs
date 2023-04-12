using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TarefasSistemas.Models;

namespace TarefasSistemas.Data.Map
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        
        
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.ImgUrl).IsRequired();
            builder.Property(x => x.Genre).IsRequired();
            builder.Property(x => x.Rating).IsRequired();

        }
        
    }
}
