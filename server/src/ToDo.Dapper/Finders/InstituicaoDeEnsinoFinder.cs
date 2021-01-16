using System;
using Dapper;
using Dasync.Collections;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.Dapper.Core;
using ToDo.Dapper.Queries;
using ToDo.Infra.Settings;

namespace ToDo.Dapper.Finders
{
    public class InstituicaoDeEnsinoFinder : FinderBase, IInstituicaoDeEnsinoFinder
    {
        public InstituicaoDeEnsinoFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo) { }

        public async Task<IEnumerable<InstituicaoDeEnsinoModel>> ObterAsync()
        {
            using var conn = CreateConnection();
            var instituicoes = await conn.QueryAsync<InstituicaoDeEnsinoModel>(InstituicaoDeEnsinoQueries.Query);

            string query = $" { PessoaQueries.PessoaJuridica.QueryById } " +
                           $" { PessoaQueries.PessoaEndereco.QueryById } " +
                           $" { PessoaQueries.PessoaTelefone.QueryById } " +
                           $" { PessoaQueries.PessoaEmail.QueryById } ";

            await instituicoes.ParallelForEachAsync(async instituicao => await ObterInformacoesDaPessoaAsync(instituicao, query));

            return instituicoes;
        }

        public async Task<InstituicaoDeEnsinoModel> ObterAsync(Guid aggregateId)
        {
            using var conn = CreateConnection();
            var instituicao = await conn.QuerySingleOrDefaultAsync<InstituicaoDeEnsinoModel>(InstituicaoDeEnsinoQueries.QueryByAggregateId, new { AggregateId = aggregateId });

            string query = $" { PessoaQueries.PessoaJuridica.QueryById } " +
                           $" { PessoaQueries.PessoaEndereco.QueryById } " +
                           $" { PessoaQueries.PessoaTelefone.QueryById } " +
                           $" { PessoaQueries.PessoaEmail.QueryById } ";

            await ObterInformacoesDaPessoaAsync(instituicao, query);

            return instituicao;
        }

        private async Task ObterInformacoesDaPessoaAsync(InstituicaoDeEnsinoModel instituicao, string query)
        {
            using var conn = CreateConnection();
            var multi = await conn.QueryMultipleAsync(query, new { Id = instituicao.PessoaId });

            instituicao.PessoaJuridica = await multi.ReadSingleOrDefaultAsync<PessoaJuridicaModel>();
            instituicao.Endereco = await multi.ReadSingleOrDefaultAsync<PessoaEnderecoModel>();
            instituicao.Telefones = await multi.ReadAsync<PessoaTelefoneModel>();
            instituicao.Emails = await multi.ReadAsync<PessoaEmailModel>();
        }
    }
}