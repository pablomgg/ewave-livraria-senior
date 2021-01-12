using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
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
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await _livroFinder.ObterTodosAsync());
        }
    }
}
