using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;
using ToDo.WebApi.Dtos;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("livro")]
    public class LivroController : WriteApiBase
    {
        public LivroController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Criar um livro.
        /// </summary>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] LivroDto dto)
        {
            await DomainService
                .NewGuid(out var aggregateId)
                .Execute<ILivroService>(async service => await service.CriarAsync(aggregateId, dto.autorAggregateId, dto.generoAggregateId, dto.Titulo, dto.Capa, dto.Sinopse, dto.Paginas))
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Alterar um livro.
        /// </summary>
        /// <param name="aggregateId">Parâmetro esperado.</param>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId:guid}")]
        public async Task<IActionResult> AlterarAsync(Guid aggregateId, [FromBody] LivroDto dto)
        {
            await DomainService 
                .Execute<ILivroService>(async service => await service.AlterarAsync(aggregateId, dto.autorAggregateId, dto.generoAggregateId, dto.Titulo, dto.Capa, dto.Sinopse, dto.Paginas))
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Inativar ou Ativar um livro.
        /// </summary>
        /// <param name="aggregateId">Parâmetro esperado.</param>
        /// <returns></returns>
        [HttpPut] 
        [Route("inativar-ou-ativar/{aggregateId:guid}")]
        public async Task<IActionResult> InativarOuAtivarAsync(Guid aggregateId)
        {
            await DomainService
                .Execute<ILivroService>(async service => await service.InativarOuAtivarAsync(aggregateId))
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
