using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;
using ToDo.WebApi.Dtos;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("genero")]
    public class GeneroController : WriteApiBase
    {
        public GeneroController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Criar um genero.
        /// </summary>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] GeneroDto dto)
        {
            await DomainService
                .NewGuid(out var aggregateId)
                .Execute<IGeneroService>(async service => await service.CriarAsync(aggregateId, dto.Nome))
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Alterar um genero.
        /// </summary>
        /// <param name="aggregateId">Parâmetro esperado.</param>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId:guid}")]
        public async Task<IActionResult> AlterarAsync(Guid aggregateId, [FromBody] GeneroDto dto)
        {
            await DomainService
                .Execute<IGeneroService>(async service => await service.AlterarAsync(aggregateId, dto.Nome))
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Inativar ou Ativar um genero.
        /// </summary>
        /// <param name="aggregateId">Parâmetro esperado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("inativar-ou-ativar/{aggregateId:guid}")]
        public async Task<IActionResult> InativarOuAtivarAsync(Guid aggregateId)
        {
            await DomainService
                .Execute<IGeneroService>(async service => await service.InativarOuAtivarAsync(aggregateId))
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
