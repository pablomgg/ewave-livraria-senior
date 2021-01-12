using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.EF.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ToDoContext _context;

        public UnitOfWork(ToDoContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}