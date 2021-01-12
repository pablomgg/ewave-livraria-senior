using System.Threading.Tasks;

namespace ToDo.Dapper.Abstractions.Finders
{
    public interface ILivroFinder
    {
        Task<dynamic> ObterTodosAsync();
    }
}