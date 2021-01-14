using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi.Controllers.ReadModel
{
    [Route("instituicoes")]
    public class InstituicaoDeEnsinosController : ReadApiBase
    {
        private readonly IInstituicaoDeEnsinoFinder _instituicaoDeEnsinoFinder;

        public InstituicaoDeEnsinosController(IInstituicaoDeEnsinoFinder instituicaoDeEnsinoFinder)
        {
            _instituicaoDeEnsinoFinder = instituicaoDeEnsinoFinder;
        }

        /// <summary>
        /// Obter todas as instituições de ensino.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<InstituicaoDeEnsinoModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterAsync()
        {
            return Ok(await _instituicaoDeEnsinoFinder.ObterAsync());
        }
    }
}
