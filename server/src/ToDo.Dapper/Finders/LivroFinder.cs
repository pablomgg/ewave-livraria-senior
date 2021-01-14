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
    public class LivroFinder : FinderBase, ILivroFinder
    {
        public LivroFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo) { }

        public async Task<IEnumerable<LivroModel>> ObterTodosAsync()
        {
            using var conn = CreateConnection();
            var livros = await conn.QueryAsync<LivroModel>(LivroQueries.Query);

            string query = $" {AutorQueries.QueryById} " +
                           $" {GeneroQueries.QueryById} ";

            await livros.ParallelForEachAsync(async livro => await ObterInformacoesDoLivroAsync(livro, query));

            return livros;
        }

        private async Task ObterInformacoesDoLivroAsync(LivroModel livro, string query)
        {
            using var conn = CreateConnection();
            using var multi = await conn.QueryMultipleAsync(query, new { AutorId = livro.AutorId, GeneroId = livro.GeneroId });

            livro.Autor = await multi.ReadSingleOrDefaultAsync<AutorModel>();
            livro.Genero = await multi.ReadSingleOrDefaultAsync<GeneroModel>();
        }
    }
}