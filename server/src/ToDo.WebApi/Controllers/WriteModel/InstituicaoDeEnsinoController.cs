using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;
using ToDo.WebApi.Dtos;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("instituicao")]
    public class InstituicaoDeEnsinoController : WriteApiBase
    {
        public InstituicaoDeEnsinoController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Criar uma instituição de ensino.
        /// </summary>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] InstituicaoDeEnsinoDto dto)
        {
            await DomainService
                .NewGuid(out var pessoaAggregateId)
                .Execute<IPessoaJuridicaService>(async (service) => { await service.CriarAsync(pessoaAggregateId, dto.PessoaJuridica.Cnpj, dto.PessoaJuridica.RazaoSocial, dto.PessoaJuridica.NomeFantasia); })
                .Execute<IPessoaService>(async (service) =>
                {
                    await service.CriarEnderecoAsync(pessoaAggregateId, dto.Endereco.Cep, dto.Endereco.Bairro, dto.Endereco.Logradouro, dto.Endereco.CidadeId, dto.Endereco.Numero, dto.Endereco.Complemento);

                    foreach (var telefone in dto.Telefones)
                    {
                        await service.AdicionarTelefoneAsync(pessoaAggregateId, telefone.Numero, telefone.TipoId);
                    }

                    foreach (var email in dto.Emails)
                    {
                        await service.AdicionarEmailAsync(pessoaAggregateId, email.Endereco, email.TipoId);
                    }
                })
                .NewGuid(out var aggregateId)
                .Execute<IInstituicaoDeEnsinoService>(async (service) => { await service.CriarAsync(aggregateId, pessoaAggregateId); })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Inativar ou ativar uma instituição de ensino.
        /// </summary>
        /// <param name="aggregateId">AggregateId da instituição de ensino.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("inativar-ou-ativar/{aggregateId:guid}")]
        public async Task<IActionResult> InativarOuAtivarAsync(Guid aggregateId)
        {
            await DomainService
                .Execute<IInstituicaoDeEnsinoService>(async (service) => { await service.InativarOuAtivarAsync(aggregateId); })
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
