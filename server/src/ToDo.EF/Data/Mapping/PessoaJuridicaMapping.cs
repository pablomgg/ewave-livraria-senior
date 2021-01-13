using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.EF.Data.Mapping
{
    public class PessoaJuridicaMapping : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("PessoaJuridica").HasKey(x => x.PessoaId);
            builder.Property(x => x.Cnpj);
            builder.Property(x => x.RazaoSocial);
            builder.Property(x => x.NomeFantasia);
        }
    }
}