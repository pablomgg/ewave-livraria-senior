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
    public class UsuarioFinder: FinderBase, IUsuarioFinder
    {
        public UsuarioFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo) { }

        public async Task<IEnumerable<UsuarioModel>> ObterAsync()
        {
            using var conn = CreateConnection();
            var usuarios = await conn.QueryAsync<UsuarioModel>(UsuarioQueries.Query);

            string query = $" { PessoaQueries.PessoaFisica.QueryById } " +
                           $" { PessoaQueries.PessoaEndereco.QueryById } " +
                           $" { PessoaQueries.PessoaTelefone.QueryById } " +
                           $" { PessoaQueries.PessoaEmail.QueryById } ";

            await usuarios.ParallelForEachAsync(async usuario => await ObterInformacoesDaPessoaAsync(usuario, query));

            return usuarios;
        }

        private async Task ObterInformacoesDaPessoaAsync(UsuarioModel usuario, string query)
        {
            using var conn = CreateConnection();
            var multi = await conn.QueryMultipleAsync(query, new { Id = usuario.PessoaId });

            usuario.PessoaFisica = await multi.ReadSingleOrDefaultAsync<PessoaFisicaModel>();
            usuario.Endereco = await multi.ReadSingleOrDefaultAsync<PessoaEnderecoModel>();
            usuario.Telefones = await multi.ReadAsync<PessoaTelefoneModel>();
            usuario.Emails = await multi.ReadAsync<PessoaEmailModel>();
        }
    }
}