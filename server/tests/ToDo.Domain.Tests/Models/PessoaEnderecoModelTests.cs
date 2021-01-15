using System;
using Bogus;
using FluentAssertions;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Models;
using ToDo.Infra.Tests.Builders.ModelBuilders;
using ToDo.Infra.Tests.Core;
using Xunit;

namespace ToDo.Domain.Tests.Models
{
    public class PessoaEnderecoModelTests
    {
        private readonly PessoaEnderecoBuilder _builder;
        private readonly Faker _faker;

        public PessoaEnderecoModelTests()
        {
            _builder = new PessoaEnderecoBuilder().Create();
            _faker = new Faker();
        }

        [Fact]
        public void Quando_criar_com_sucesso()
        {
            var act = new Action(() => new PessoaEndereco(_builder.Cep, _builder.Bairro, _builder.Logradouro, _builder.CidadeId, _builder.Numero, _builder.Complemento));
            act.Should().NotThrow();
        }

        [Fact]
        public void Quando_criar_com_Cep_maior_que_permitido()
        {
            var act = new Action(() => new PessoaEndereco(_faker.Random.AlphaNumeric(9), _builder.Bairro, _builder.Logradouro, _builder.CidadeId, _builder.Numero, _builder.Complemento));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_criar_com_Bairro_maior_que_permitido()
        {
            var act = new Action(() => new PessoaEndereco(_builder.Cep, _faker.Random.AlphaNumeric(181), _builder.Logradouro, _builder.CidadeId, _builder.Numero, _builder.Complemento));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_criar_com_Logradouro_maior_que_permitido()
        {
            var act = new Action(() => new PessoaEndereco(_builder.Cep, _builder.Bairro, _faker.Random.AlphaNumeric(181), _builder.CidadeId, _builder.Numero, _builder.Complemento));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_criar_com_Numero_maior_que_permitido()
        {
            var act = new Action(() => new PessoaEndereco(_builder.Cep, _builder.Bairro, _builder.Logradouro, _builder.CidadeId, _faker.Random.AlphaNumeric(7), _builder.Complemento));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_criar_com_Complemento_maior_que_permitido()
        {
            var act = new Action(() => new PessoaEndereco(_builder.Cep, _builder.Bairro, _builder.Logradouro, _builder.CidadeId, _builder.Numero, _faker.Random.AlphaNumeric(256)));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

    }
}