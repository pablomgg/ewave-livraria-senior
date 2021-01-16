using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models;

namespace ToDo.EF.Data.Mapping
{
    public class PessoaFisicaMapping : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable("PessoaFisica").HasKey(x => x.PessoaId);
            builder.Property(x => x.Cpf);
            builder.Property(x => x.Nome);
        }
    }
}