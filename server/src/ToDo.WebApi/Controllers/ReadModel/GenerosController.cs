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
    [Route("generos")]
    public class GenerosController : ReadApiBase
    {
        private readonly IGeneroFinder _generoFinder;

        public GenerosController(IGeneroFinder generoFinder)
        {
            _generoFinder = generoFinder;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await _generoFinder.ObterTodosAsync());
        }
    }
}
