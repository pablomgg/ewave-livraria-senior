using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WebApi.Configurations;
using ToDo.WebApi.Dtos;

namespace ToDo.WebApi.Controllers.WriteModel
{
    [Route("usuario")]
    public class UsuarioController : WriteApiBase
    {
        public UsuarioController(IDomainService domainService) : base(domainService) { }

        /// <summary>
        /// Criar um usuario.
        /// </summary>
        /// <param name="dto">Parâmetros esperados.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] UsuarioDto dto)
        {
            await DomainService
                .NewGuid(out var pessoaAggregateId)
                .Execute<IPessoaFisicaService>(async (service) => { await service.CriarAsync(pessoaAggregateId, dto.PessoaFisica.Cpf, dto.PessoaFisica.Nome); })
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
                .Execute<IUsuarioService>(async (service) => { await service.CriarAsync(aggregateId, pessoaAggregateId, dto.InstituicaoDeEnsinoAggregateId); })
                .CommitAsync();

            return Ok(aggregateId);
        }

        /// <summary>
        /// Inativar ou ativar um usuario.
        /// </summary>
        /// <param name="aggregateId">AggregateId do usuario.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{aggregateId:guid}/inativar-ou-ativar")]
        public async Task<IActionResult> InativarOuAtivarAsync(Guid aggregateId)
        {
            await DomainService
                .Execute<IUsuarioService>(async (service) => { await service.InativarOuAtivarAsync(aggregateId); })
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
