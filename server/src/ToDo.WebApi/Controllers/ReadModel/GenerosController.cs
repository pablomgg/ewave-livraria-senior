using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi.Controllers.ReadModel
{
    [Route("generos")]
    public class GenerosController : ReadApiBase
    {
        private readonly IGeneroFinder _generoFinder;

        public GenerosController(IGeneroFinder generoFinder)
        {
            _generoFinder = generoFinder;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<GeneroModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await _generoFinder.ObterTodosAsync());
        }
    }
}
