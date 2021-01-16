using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.InstituicaoDeEnsino;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Entities.Usuario;

namespace ToDo.EF.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario").HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.AggregateId);
            builder.Property(x => x.PessoaAggregateId);
            builder.Property(x => x.InstituicaoDeEnsinoAggregateId);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.Ativo);

            builder
                .HasOne(x => x.Pessoa)
                .WithOne()
                .HasPrincipalKey<Pessoa>(x => x.AggregateId)
                .HasForeignKey<Usuario>(x => x.PessoaAggregateId);

            builder
                .HasOne(x => x.InstituicaoDeEnsino)
                .WithOne()
                .HasPrincipalKey<InstituicaoDeEnsino>(x => x.AggregateId)
                .HasForeignKey<Usuario>(x => x.InstituicaoDeEnsinoAggregateId);
        }
    }
}