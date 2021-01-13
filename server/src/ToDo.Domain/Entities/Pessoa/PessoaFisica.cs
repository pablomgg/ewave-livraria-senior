using System;
using ToDo.Domain.Enums;
using ToDo.Domain.Models;

namespace ToDo.Domain.Entities.Pessoa
{
    public partial class Pessoa
    {
        public virtual PessoaFisica PessoaFisica { get; protected set; }

        public Pessoa(Guid aggregateId, string cpf, string nome) : this(aggregateId, EPessoaTipo.PessoaFisica) => PessoaFisica = new PessoaFisica(cpf, nome);

        public void AlterarPessoaFisica(string cpf, string nome) => PessoaFisica.Alterar(cpf, nome);
    }
}