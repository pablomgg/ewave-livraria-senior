using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Finders;
using ToDo.Dapper.Abstractions.Models;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi.Controllers.ReadModel
{
    [Route("usuarios")]
    public class UsuariosController : ReadApiBase
    {
        private readonly IUsuarioFinder _usuarioFinder;

        public UsuariosController(IUsuarioFinder usuarioFinder)
        {
            _usuarioFinder = usuarioFinder;
        }

        /// <summary>
        /// Obter todos os usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<UsuarioModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterAsync()
        {
            return Ok(await _usuarioFinder.ObterAsync());
        }

        /// <summary>
        /// Obter um usuario.
        /// </summary>
        /// <param name="aggregateId">AggregateId do usuario.</param>
        /// <returns></returns>
        [HttpGet("{aggregateId:guid}")]
        [ProducesResponseType(typeof(UsuarioModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterAsync(Guid aggregateId)
        {
            return Ok(await _usuarioFinder.ObterAsync(aggregateId));
        }
    }
}
