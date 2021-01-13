using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Models;

namespace ToDo.EF.Data.Mapping
{
    public class PessoaMeioContatoTelefoneTipoMapping : IEntityTypeConfiguration<PessoaMeioContatoTelefoneTipo>
    {
        public void Configure(EntityTypeBuilder<PessoaMeioContatoTelefoneTipo> builder)
        {
            builder.ToTable("TelefoneTipo").HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Nome);
        }
    }
}