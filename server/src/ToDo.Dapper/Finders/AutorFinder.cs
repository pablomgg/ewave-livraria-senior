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
    public class AutorFinder : FinderBase, IAutorFinder
    {
        public AutorFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo) { }

        public async Task<IEnumerable<AutorModel>> ObterTodosAsync()
        {
            using (var conn = CreateConnection())
                return await conn.QueryAsync<AutorModel>(AutorQueries.Query);
        }
    }
}