using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi.Controllers.ReadModel
{
    [Route("livros")]
    public class LivrosController : ReadApiBase
    {
        private readonly ILivroFinder _livroFinder;

        public LivrosController(ILivroFinder livroFinder)
        {
            _livroFinder = livroFinder;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<LivroModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await _livroFinder.ObterTodosAsync());
        }
    }
}
