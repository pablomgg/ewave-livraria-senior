using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Core;
using ToDo.Infra.Settings;

namespace ToDo.Dapper.Finders
{
    public class LivroFinder : FinderBase, ILivroFinder
    {
        public string stringConection { get; }

        public LivroFinder(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.Data?.ToDo)
        {
            stringConection = appSettings?.Value?.Data?.ToDo;
        }

        public async Task<dynamic> ObterTodosAsync()
        { 
            return await Task.FromResult(stringConection);
        }
    }
}