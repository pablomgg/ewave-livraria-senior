using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
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
            using (var conn = CreateConnection())
                return await conn.QueryAsync<LivroModel>(LivroQueries.Query);
        }
    }
}