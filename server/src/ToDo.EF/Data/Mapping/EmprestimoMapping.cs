using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.Emprestimo;

namespace ToDo.EF.Data.Mapping
{
    public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimo").HasKey(x=>x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.AggregateId);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.Ativo);
            builder.Property(x => x.DataEmprestimo);
            builder.Property(x => x.DataVencimento);
            builder.Property(x => x.DataDevolucao);
            builder.Property(x => x.UsuarioId);
            builder.Property(x => x.LivroId);
            builder.Ignore(x => x.DataRestricaoExpirar);

            builder
                .HasOne(x => x.Usuario)
                .WithMany()
                .HasPrincipalKey(x=>x.Id)
                .HasForeignKey(x => x.UsuarioId);

            builder
                .HasOne(x => x.Livro)
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.LivroId);
        }
    }
}