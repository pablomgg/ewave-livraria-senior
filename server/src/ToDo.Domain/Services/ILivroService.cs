using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface ILivroService : IService
    {
        Task AddAsync(string nome);
    }
}