using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Enums;
using ToDo.Domain.Models;
using ToDo.Infra.Core;

namespace ToDo.Domain.Entities.Pessoa
{
    public partial class Pessoa : Entity
    {
        public int TipoId { get; private set; }

        public virtual PessoaTipo Tipo { get; protected set; }
        public virtual ICollection<PessoaMeioContatoEmail> Emails { get; set; } = new HashSet<PessoaMeioContatoEmail>();
        public virtual ICollection<PessoaMeioContatoTelefone> Telefones { get; set; } = new HashSet<PessoaMeioContatoTelefone>();
        public virtual PessoaEndereco Endereco { get; protected set; }

        private const int TAMANHO_NOME = 255;

        public Pessoa() { }

        public Pessoa(Guid aggregateId, EPessoaTipo tipo)
        {
            AggregateId = aggregateId;
            TipoId = (int)tipo;
            DataCriacao = DateTime.Now;
            Ativo = true;
        } 

        public void AdicionarEmail(string endereco, EPessoaMeioContatoEmailTipo tipo) => Emails.Add(new PessoaMeioContatoEmail(endereco, tipo));

        public void AlterarEmail(int id, string endereco, EPessoaMeioContatoEmailTipo tipo)
        {
            var email = Emails.SingleOrDefault(x => x.Id == id);
            email?.Alterar(endereco, tipo);
        }

        public void AdicionarTelefone(string numero, EPessoaMeioContatoTelefoneTipo tipo) => Telefones.Add(new PessoaMeioContatoTelefone(numero, tipo));

        public void AlterarTelefone(int id, string numero, EPessoaMeioContatoTelefoneTipo tipo)
        {
            var telefone = Telefones.SingleOrDefault(x => x.Id == id);
            telefone?.Alterar(numero, tipo);
        }

        public void AdicionarEndereco(string cep, string bairro, string logradouro, int cidadeId, string numero = null, string complemento = null) => Endereco = new PessoaEndereco(cep, bairro, logradouro, cidadeId, numero, complemento);

        public void AlterarEndereco(string cep, string bairro, string logradouro, int cidadeId, string numero = null, string complemento = null) => Endereco.Alterar(cep, bairro, logradouro, cidadeId, numero, complemento);
    }
}