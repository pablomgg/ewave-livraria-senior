using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.Infra.Extensions;
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
                .NewGuid(out var aggregateId)
                .Execute<IPessoaFisicaService>(async (service) => { await service.CriarAsync(aggregateId, dto.PessoaFisica.Cpf, dto.PessoaFisica.Nome); })
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
