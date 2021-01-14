using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.InstituicaoDeEnsino;
using ToDo.Domain.Entities.Pessoa;

namespace ToDo.EF.Data.Mapping
{
    public class InstituicaoDeEnsinoMapping : IEntityTypeConfiguration<InstituicaoDeEnsino>
    {
        public void Configure(EntityTypeBuilder<InstituicaoDeEnsino> builder)
        {
            builder.ToTable("InstituicaoDeEnsino").HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.AggregateId);
            builder.Property(x => x.PessoaAggregateId);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.Ativo);

            builder
                .HasOne(x=>x.Pessoa)
                .WithOne()
                .HasPrincipalKey<Pessoa>(x=>x.AggregateId)
                .HasForeignKey<InstituicaoDeEnsino>(x=>x.PessoaAggregateId);
        }
    }
}