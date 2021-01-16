using Dapper;
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
    public class GeneroFinder : FinderBase, IGeneroFinder
    {
        public GeneroFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo) { }

        public async Task<IEnumerable<GeneroModel>> ObterTodosAsync()
        {
            using (var conn = CreateConnection())
                return await conn.QueryAsync<GeneroModel>(GeneroQueries.Query);
        }
    }
}