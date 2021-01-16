using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi.Controllers.ReadModel
{
    [Route("emprestimos")]
    public class EmprestimosController : ReadApiBase
    {
        private readonly IEmprestimoFinder _emprestimoFinder;

        public EmprestimosController(IEmprestimoFinder emprestimoFinder)
        {
            _emprestimoFinder = emprestimoFinder;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmprestimoModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterAsync()
        {
            return Ok(await _emprestimoFinder.ObterAsync());
        }
    }
}
