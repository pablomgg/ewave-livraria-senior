using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Domain.Entities.Livro;

namespace ToDo.EF.Data.Mapping
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro").HasKey(x => x.Id);
            builder.Property(x => x.AggregateId);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.Ativo);
            builder.Property(x => x.Titulo);
            builder.Property(x => x.Capa);
            builder.Property(x => x.Sinopse);
            builder.Property(x => x.Paginas);
            builder.Property(x => x.Disponivel);
            builder.Property(x => x.AutorId);
            builder.Property(x => x.GeneroId);

            builder.HasOne(x => x.Autor)
                .WithMany()
                .HasForeignKey(x => x.AutorId)
                .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.Genero)
                .WithMany()
                .HasForeignKey(x => x.GeneroId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}