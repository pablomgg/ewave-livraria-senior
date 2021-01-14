using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;
using ToDo.WebApi.Dtos;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("autor")]
    public class AutorController : WriteApiBase
    {
        public AutorController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Criar um autor(a).
        /// </summary>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] AutorDto dto)
        {
            await DomainService
                .NewGuid(out var aggregateId)
                .Execute<IAutorService>(async service => await service.CriarAsync(aggregateId, dto.Nome))
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Alterar um autor(a).
        /// </summary>
        /// <param name="aggregateId">Parâmetro esperado.</param>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId:guid}")]
        public async Task<IActionResult> AlterarAsync(Guid aggregateId, [FromBody] AutorDto dto)
        {
            await DomainService
                .Execute<IAutorService>(async service => await service.AlterarAsync(aggregateId, dto.Nome))
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Inativar ou Ativar um autor(a).
        /// </summary>
        /// <param name="aggregateId">Parâmetro esperado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("inativar-ou-ativar/{aggregateId:guid}")]
        public async Task<IActionResult> InativarOuAtivarAsync(Guid aggregateId)
        {
            await DomainService
                .Execute<IAutorService>(async service => await service.InativarOuAtivarAsync(aggregateId))
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
