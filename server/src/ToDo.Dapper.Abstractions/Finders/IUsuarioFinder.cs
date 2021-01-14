using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Models;

namespace ToDo.Dapper.Abstractions.Finders
{
    public interface IUsuarioFinder
    {
        Task<IEnumerable<UsuarioModel>> ObterAsync();
    }
}