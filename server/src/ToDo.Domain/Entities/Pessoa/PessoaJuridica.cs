using System;
using ToDo.Domain.Enums;
using ToDo.Domain.Models;

namespace ToDo.Domain.Entities.Pessoa
{
    public partial class Pessoa
    {
        public virtual PessoaJuridica PessoaJuridica { get; protected set; }

        public Pessoa(Guid aggregateId, string cnpj, string razaoSocial, string nomeFantasia) : this(aggregateId, EPessoaTipo.PessoaJuridica) => PessoaJuridica = new PessoaJuridica(cnpj, razaoSocial, nomeFantasia);

        public void AlterarPessoaJuridica(string cnpj, string razaoSocial, string nomeFantasia) => PessoaJuridica.Alterar(cnpj, razaoSocial, nomeFantasia);
    }
}