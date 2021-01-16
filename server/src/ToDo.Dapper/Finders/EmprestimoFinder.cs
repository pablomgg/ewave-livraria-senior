using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dasync.Collections;
using Microsoft.Extensions.Options;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.Dapper.Core;
using ToDo.Dapper.Queries;
using ToDo.Infra.Settings;

namespace ToDo.Dapper.Finders
{
    public class EmprestimoFinder : FinderBase, IEmprestimoFinder
    {
        public EmprestimoFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo) { }

        public async Task<IEnumerable<EmprestimoModel>> ObterAsync()
        {
            using var conn = CreateConnection();
            var emprestimos = await conn.QueryAsync<EmprestimoModel>(EmprestimoQueries.Query);

            string query = $" { UsuarioQueries.QueryById } " +
                           $" { LivroQueries.QueryById } ";

            await emprestimos.ParallelForEachAsync(async (emprestimo) => await ObterInformacoesDoEmprestimoAsync(emprestimo, query));

            return emprestimos;
        }

        private async Task ObterInformacoesDoEmprestimoAsync(EmprestimoModel emprestimo, string query)
        {
            using var conn = CreateConnection();
            using var multi = await conn.QueryMultipleAsync(query, new { emprestimo.UsuarioId, emprestimo.LivroId });

            emprestimo.Usuario = await multi.ReadSingleOrDefaultAsync<UsuarioModel>();
            emprestimo.Livro = await multi.ReadSingleOrDefaultAsync<LivroModel>();
        }
    }
}