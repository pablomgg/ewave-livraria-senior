using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi.Controllers.ReadModel
{
    [Route("autores")]
    public class AutoresController : ReadApiBase
    {
        private readonly IAutorFinder _autorFinder;

        public AutoresController(IAutorFinder autorFinder)
        {
            _autorFinder = autorFinder;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<AutorModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await _autorFinder.ObterTodosAsync());
        }
    }
}
