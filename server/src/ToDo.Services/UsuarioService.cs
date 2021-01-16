using System;
using System.Threading.Tasks;
using ToDo.Domain.Entities.InstituicaoDeEnsino;
using ToDo.Domain.Entities.Usuario;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Services;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository _repository;

        public UsuarioService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId, Guid pessoaAggregateId, Guid instituicaoDeEnsinoAggregateId)
        {
            Validar(pessoaAggregateId, instituicaoDeEnsinoAggregateId);
            
            var existeInstituicao = await _repository.ExistAsync<InstituicaoDeEnsino>(x => x.AggregateId == instituicaoDeEnsinoAggregateId);
            if(!existeInstituicao) throw new InstituicaoDeEnsinoNaoEncontradaException();

            await _repository.AddAsync(new Usuario(aggregateId, pessoaAggregateId, instituicaoDeEnsinoAggregateId));
        }

        public async Task InativarOuAtivarAsync(Guid aggregateId)
        {
            var usuario = await _repository.GetByAsync<Usuario>(aggregateId);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();

            usuario.InativarOuAtivar();
        }

        private void Validar(Guid pessoaAggregateId, Guid instituicaoDeEnsinoAggregateId)
        {
            if (pessoaAggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(pessoaAggregateId), pessoaAggregateId.GetType());
            if (instituicaoDeEnsinoAggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(instituicaoDeEnsinoAggregateId), instituicaoDeEnsinoAggregateId.GetType());
        }
    }
}