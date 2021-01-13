using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.EF.Data.Mapping
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero").HasKey(x => x.Id);
            builder.Property(x => x.AggregateId);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.Ativo);
            builder.Property(x => x.Nome);
        }
    }
}