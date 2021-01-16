using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;
using ToDo.WebApi.Dtos;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("emprestimo")]
    public class EmprestimoController : WriteApiBase
    {
        public EmprestimoController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Criar um emprestimo.
        /// </summary>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] EmprestimoDto dto)
        {
            await DomainService
                .NewGuid(out var aggregateId)
                .Execute<IEmprestimoService>(async (service) =>
                {
                    await service.CriarAsync(aggregateId, dto.UsuarioAggregateId, dto.LivroAggregateId, dto.DataEmprestimo);
                })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Devolver um livro.
        /// </summary>
        /// <param name="aggregateId">AggregateId do emprestimo.</param>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId}/devolver")]
        public async Task<IActionResult> DevolverAsync(Guid aggregateId, [FromBody] EmprestimoDto dto)
        {
            await DomainService 
                .Execute<IEmprestimoService>(async (service) =>
                {
                    await service.DevolverAsync(aggregateId, dto.DataDevolucao);
                })
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
