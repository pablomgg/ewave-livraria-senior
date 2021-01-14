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
    public class TerritorioFinder : FinderBase, ITerritorioFinder
    {
        public TerritorioFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo) { }

        public async Task<IEnumerable<EstadoModel>> ObterEstadosAsync()
        {
            using var conn = CreateConnection();
            return await conn.QueryAsync<EstadoModel>(TerritorioQueries.Estado.Query);
        }

        public async Task<IEnumerable<CidadeModel>> ObterCidadesPorEstadoIdAsync(int id)
        {
            using var conn = CreateConnection();
            return await conn.QueryAsync<CidadeModel>(TerritorioQueries.Cidade.QueryById, new { EstadoId = id });
        }
    }
}