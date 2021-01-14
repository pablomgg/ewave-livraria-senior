using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Models;

namespace ToDo.Dapper.Abstractions.Finders
{
    public interface ITerritorioFinder
    {
        Task<IEnumerable<EstadoModel>> ObterEstadosAsync();
        Task<IEnumerable<CidadeModel>> ObterCidadesPorEstadoIdAsync(int id);
    }
}