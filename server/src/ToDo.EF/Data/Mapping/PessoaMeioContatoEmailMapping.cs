using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Models;

namespace ToDo.EF.Data.Mapping
{
    public class PessoaMeioContatoEmailMapping : IEntityTypeConfiguration<PessoaMeioContatoEmail>
    {
        public void Configure(EntityTypeBuilder<PessoaMeioContatoEmail> builder)
        {
            builder.ToTable("Email").HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.PessoaId);
            builder.Property(x => x.Endereco);
            builder.Property(x => x.TipoId);

            builder
                .HasOne(x => x.Tipo)
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.TipoId);
        }
    }
}