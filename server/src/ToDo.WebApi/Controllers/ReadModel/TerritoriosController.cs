using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;

namespace ToDo.WebApi.Controllers.ReadModel
{
    [Route("territorios")]
    public class TerritoriosController : Controller
    {
        private readonly ITerritorioFinder _territorioFinder;

        public TerritoriosController(ITerritorioFinder territorioFinder)
        {
            _territorioFinder = territorioFinder;
        }

        /// <summary>
        /// Obter todos os estados.
        /// </summary>
        /// <returns></returns>
        [HttpGet("estados")]
        [ProducesResponseType(typeof(EstadoModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterEstadosAsync()
        {
            return Ok(await _territorioFinder.ObterEstadosAsync());
        }

        /// <summary>
        /// Obter todos as cidades por id de um estado.
        /// </summary>
        /// <param name="estadoId">Parâmetro esperado.</param>
        /// <returns></returns>
        [HttpGet("estados/{estadoId}/cidades")]
        [ProducesResponseType(typeof(CidadeModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterCidadesPorEstadoIdAsync(int estadoId)
        {
            return Ok(await _territorioFinder.ObterCidadesPorEstadoIdAsync(estadoId));
        }
    }
}
