using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Models;

namespace ToDo.EF.Data.Mapping
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa").HasKey(x => x.Id);
            builder.Property(x => x.AggregateId); 
            builder.Property(x => x.TipoId);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.Ativo);

            builder
                .HasOne(x => x.PessoaFisica)
                .WithOne()
                .HasPrincipalKey<Pessoa>(x => x.Id)
                .HasForeignKey<PessoaFisica>(x => x.PessoaId);

            builder
                .HasOne(x => x.PessoaJuridica)
                .WithOne()
                .HasPrincipalKey<Pessoa>(x => x.Id)
                .HasForeignKey<PessoaJuridica>(x => x.PessoaId);

            builder
                .HasOne(x => x.Endereco)
                .WithOne()
                .HasPrincipalKey<Pessoa>(x => x.Id)
                .HasForeignKey<PessoaEndereco>(x => x.PessoaId);

            builder
                .HasMany(x => x.Emails)
                .WithOne()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.PessoaId);

            builder
                .HasMany(x => x.Telefones)
                .WithOne()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.PessoaId);
        }
    }
}