using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("livro")]
    public class LivroController : WriteApiBase
    {
        public LivroController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Adicionar um livro
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] string nome)
        {
            await DomainService
                .NewGuid(out var aggregateId)
                .Execute<ILivroService>(async service => await service.AddAsync(nome))
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
