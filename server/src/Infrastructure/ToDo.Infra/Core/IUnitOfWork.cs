using System.Threading.Tasks;

namespace ToDo.Infra.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}