using System;
using System.Threading.Tasks;
using ToDo.Domain.Entities.InstituicaoDeEnsino;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Services;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Services
{
    public class InstituicaoDeEnsinoService : IInstituicaoDeEnsinoService
    {
        private readonly IRepository _repository;

        public InstituicaoDeEnsinoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId, Guid pessoaAggregateId)
        {
            Validar(pessoaAggregateId);

            await _repository.AddAsync(new InstituicaoDeEnsino(aggregateId, pessoaAggregateId));
        }

        public async Task InativarOuAtivarAsync(Guid aggregateId)
        {
            var insiInstituicaoDeEnsino = await _repository.GetByAsync<InstituicaoDeEnsino>(aggregateId);
            if (insiInstituicaoDeEnsino.IsNull()) throw new InstituicaoDeEnsinoNaoEncontradaException();

            insiInstituicaoDeEnsino.InativarOuAtivar();
        }

        private void Validar(Guid pessoaAggregateId)
        {
            if (pessoaAggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(pessoaAggregateId), pessoaAggregateId.GetType());
        }
    }
}