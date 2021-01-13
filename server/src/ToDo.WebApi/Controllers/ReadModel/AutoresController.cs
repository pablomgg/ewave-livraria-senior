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
    [Route("autores")]
    public class AutoresController : ReadApiBase
    {
        private readonly IAutorFinder _autorFinder;

        public AutoresController(IAutorFinder autorFinder)
        {
            _autorFinder = autorFinder;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await _autorFinder.ObterTodosAsync());
        }
    }
}
