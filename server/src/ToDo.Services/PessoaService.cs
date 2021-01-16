using System;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Services;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IRepository _repository;

        public PessoaService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarEnderecoAsync(Guid aggregateId, string cep, string bairro, string logradouro, int cidadeId, string numero, string complemento)
        {
            ValidarEndereco(cep, bairro, logradouro, cidadeId);

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();

            pessoa.AdicionarEndereco(cep, bairro, logradouro, cidadeId, numero, complemento);
        }

        public async Task AlterarEnderecoAsync(Guid aggregateId, string cep, string bairro, string logradouro, int cidadeId, string numero, string complemento)
        {
            ValidarEndereco(cep, bairro, logradouro, cidadeId);

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();

            pessoa.AlterarEndereco(cep, bairro, logradouro, cidadeId, numero, complemento);
        }

        public async Task AdicionarTelefoneAsync(Guid aggregateId, string numero, int tipoId)
        {
            ValidarTelefone(numero, tipoId);

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();
            if (pessoa.Telefones.Any(x => x.Numero == numero)) throw new PessoaTelefoneJaExisteException();

            pessoa.AdicionarTelefone(numero, (EPessoaMeioContatoTelefoneTipo)tipoId);
        }

        public async Task AlterarTelefoneAsync(Guid aggregateId, int id, string numero, int tipoId)
        {
            ValidarTelefone(numero, tipoId);

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();
            if (pessoa.Telefones.IsNullOrCountEqualsZero()) throw new PessoaNaoExisteTelefoneException();

            var existeTelefone = pessoa.Telefones.Any(x => x.Id == id);
            if (!existeTelefone) throw new PessoaTelefoneNaoEncontradoException();

            if (pessoa.Telefones.Any(x => x.Numero == numero)) throw new PessoaTelefoneJaExisteException();

            pessoa.AlterarTelefone(id, numero, (EPessoaMeioContatoTelefoneTipo)tipoId);
        }

        public async Task AdicionarEmailAsync(Guid aggregateId, string endereco, int tipoId)
        {
            ValidarEmail(endereco, tipoId);

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();
            if (pessoa.Emails.Any(x => x.Endereco == endereco)) throw new PessoaEmailJaExisteException();

            pessoa.AdicionarEmail(endereco, (EPessoaMeioContatoEmailTipo)tipoId);
        }

        public async Task AlterarEmailAsync(Guid aggregateId, int id, string endereco, int tipoId)
        {
            ValidarEmail(endereco, tipoId);

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();
            if (pessoa.Telefones.IsNullOrCountEqualsZero()) throw new PessoaNaoExisteEmailException();

            var existeEmail = pessoa.Emails.Any(x => x.Id == id);
            if (!existeEmail) throw new PessoaEmailNaoEncontradoException();
            if (pessoa.Emails.Any(x => x.Endereco == endereco)) throw new PessoaEmailJaExisteException();

            pessoa.AlterarEmail(id, endereco, (EPessoaMeioContatoEmailTipo)tipoId);
        }

        private void ValidarEndereco(string cep, string bairro, string logradouro, int cidadeId)
        {
            if (cep.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(cep), cep.GetType());
            if (bairro.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(bairro), bairro.GetType());
            if (logradouro.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(logradouro), logradouro.GetType());
            if (cidadeId.IsLessThanZero()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(cidadeId), cidadeId.GetType());
        }

        private void ValidarTelefone(string numero, int tipoId)
        {
            if (numero.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(numero), numero.GetType());
            if (((EPessoaMeioContatoTelefoneTipo)tipoId).IsNotType<EPessoaMeioContatoTelefoneTipo>()) throw new PessoaTipoTelefoneNaoEncontradoException();
        }

        private void ValidarEmail(string endereco, int tipoId)
        {
            if (endereco.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(endereco), endereco.GetType());
            if (((EPessoaMeioContatoEmailTipo)tipoId).IsNotType<EPessoaMeioContatoEmailTipo>()) throw new PessoaTipoEmailNaoEncontradoException();
        }
    }
}