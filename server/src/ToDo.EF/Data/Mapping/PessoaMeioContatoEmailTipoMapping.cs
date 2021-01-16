using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Models;

namespace ToDo.EF.Data.Mapping
{
    public class PessoaMeioContatoEmailTipoMapping : IEntityTypeConfiguration<PessoaMeioContatoEmailTipo>
    {
        public void Configure(EntityTypeBuilder<PessoaMeioContatoEmailTipo> builder)
        {
            builder.ToTable("EmailTipo").HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Nome);
        }
    }
}