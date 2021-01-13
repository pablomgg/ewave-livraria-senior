using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Models;

namespace ToDo.EF.Data.Mapping
{
    public class PessoaEnderecoMapping : IEntityTypeConfiguration<PessoaEndereco>
    {
        public void Configure(EntityTypeBuilder<PessoaEndereco> builder)
        {
            builder.ToTable("Endereco").HasKey(x => x.PessoaId);
            builder.Property(x=>x.PessoaId);
            builder.Property(x=>x.Cep);
            builder.Property(x=>x.Bairro);
            builder.Property(x=>x.Logradouro);
            builder.Property(x=>x.Numero);
            builder.Property(x=>x.Complemento);
            builder.Property(x=>x.CidadeId);
        }
    }
}