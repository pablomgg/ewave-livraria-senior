using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;
using ToDo.WebApi.Dtos;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("pessoa")]
    public class PessoaController : WriteApiBase
    {
        public PessoaController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Alterar uma pessoa fisica.
        /// </summary>
        /// <param name="aggregateId">AggregateId de pessoa.</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId}/pessoa-fisica")]
        public async Task<IActionResult> AlterarPessoaFisicaAsync(Guid aggregateId, [FromBody] PessoaFisicaDto dto)
        {
            await DomainService
                .Execute<IPessoaFisicaService>(async (service) => { await service.AlterarAsync(aggregateId, dto.Cpf, dto.Nome); })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Alterar uma pessoa juridica.
        /// </summary>
        /// <param name="aggregateId">AggregateId de pessoa.</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId}/pessoa-juridica")]
        public async Task<IActionResult> AlterarPessoaJuridicaAsync(Guid aggregateId, [FromBody] PessoaJuridicaDto dto)
        {
            await DomainService
                .Execute<IPessoaJuridicaService>(async (service) => { await service.AlterarAsync(aggregateId, dto.Cnpj, dto.RazaoSocial, dto.NomeFantasia); })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Alterar um endereco.
        /// </summary>
        /// <param name="aggregateId">AggregateId de pessoa.</param>
        /// <param name="dto">Parâmentros esperados.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId}/endereco")]
        public async Task<IActionResult> AlterarEnderecoAsync(Guid aggregateId, [FromBody] PessoaEnderecoDto dto)
        {
            await DomainService
                .Execute<IPessoaService>(async (service) =>
                {
                    await service.AlterarEnderecoAsync(aggregateId, dto.Cep, dto.Bairro, dto.Logradouro, dto.CidadeId, dto.Numero, dto.Complemento);
                })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Adicionar um telefone.
        /// </summary>
        /// <param name="aggregateId">AggregateId de pessoa.</param>
        /// <param name="dto">Parâmentros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{aggregateId}/telefone")]
        public async Task<IActionResult> AdicionarTelefoneAsync(Guid aggregateId, [FromBody] IList<PessoaTelefoneDto> dto)
        {
            await DomainService
                .Execute<IPessoaService>(async (service) =>
                {
                    foreach (var telefone in dto)
                    {
                        await service.AdicionarTelefoneAsync(aggregateId, telefone.Numero, telefone.TipoId);
                    }
                })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Alterar um telefone.
        /// </summary>
        /// <param name="aggregateId">AggregateId de pessoa.</param>
        /// <param name="id">Id do telefone.</param>
        /// <param name="dto">Parâmentros esperados.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId}/telefone/{id}")]
        public async Task<IActionResult> AlterarTelefoneAsync(Guid aggregateId, int id, [FromBody] PessoaTelefoneDto dto)
        {
            await DomainService
                .Execute<IPessoaService>(async (service) => { await service.AlterarTelefoneAsync(aggregateId, id, dto.Numero, dto.TipoId); })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Adicionar um e-mail.
        /// </summary>
        /// <param name="aggregateId">AggregateId de pessoa.</param>
        /// <param name="dto">Parâmentros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{aggregateId}/email")]
        public async Task<IActionResult> AdicionarEmailAsync(Guid aggregateId, [FromBody] IList<PessoaEmailDto> dto)
        {
            await DomainService
                .Execute<IPessoaService>(async (service) =>
                {
                    foreach (var email in dto)
                    {
                        await service.AdicionarEmailAsync(aggregateId, email.Endereco, email.TipoId);
                    }
                }) 
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Alterar um e-mail.
        /// </summary>
        /// <param name="aggregateId">AggregateId de pessoa.</param>
        /// <param name="id">Id do e-mail.</param>
        /// <param name="dto">Parâmentros esperados.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId}/email/{id}")]
        public async Task<IActionResult> AlterarEmailAsync(Guid aggregateId, int id, [FromBody] PessoaEmailDto dto)
        {
            await DomainService
                .Execute<IPessoaService>(async (service) => { await service.AlterarEmailAsync(aggregateId, id, dto.Endereco, dto.TipoId); })
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
