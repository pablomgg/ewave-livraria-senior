using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Services;
using ToDo.Infra.Core;

namespace ToDo.Services
{
    public class LivroService : ILivroService
    {
        private readonly IRepository _repository;

        public LivroService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(string nome)
        {
            var livro = new Livro(nome);
            await _repository.AddAsync(livro);
        }
    }
}