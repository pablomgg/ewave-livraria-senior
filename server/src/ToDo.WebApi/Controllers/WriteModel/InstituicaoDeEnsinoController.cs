using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .NewGuid(out var aggregateId)
                .Execute<IPessoaJuridicaService>(async (service) => { await service.CriarAsync(aggregateId, dto.PessoaJuridica.Cnpj, dto.PessoaJuridica.RazaoSocial, dto.PessoaJuridica.NomeFantasia); })
                .Execute<IPessoaService>(async (service) =>
                {
                    await service.CriarEnderecoAsync(aggregateId, dto.Endereco.Cep, dto.Endereco.Bairro, dto.Endereco.Logradouro, dto.Endereco.CidadeId, dto.Endereco.Numero, dto.Endereco.Complemento);

                    foreach (var telefone in dto.Telefones)
                    {
                        await service.AdicionarTelefoneAsync(aggregateId, telefone.Numero, telefone.TipoId);
                    }

                    foreach (var email in dto.Emails)
                    {
                        await service.AdicionarEmailAsync(aggregateId, email.Endereco, email.TipoId);
                    }
                })
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
