using ToDo.Domain.Models;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.ModelBuilders
{
    public class PessoaEnderecoBuilder : ModelBuilderBase<PessoaEnderecoBuilder, PessoaEndereco>
    {
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public int CidadeId { get; private set; }

        public override PessoaEnderecoBuilder Create()
        {
            Cep = Faker.Address.ZipCode("########");
            Bairro = Faker.Random.AlphaNumeric(180);
            Logradouro = Faker.Random.AlphaNumeric(180);
            Numero = Faker.Random.AlphaNumeric(6);
            Complemento = Faker.Random.AlphaNumeric(255);
            CidadeId = Faker.Random.Number(1, 999);

            return this;
        }

        public override PessoaEndereco Build() => new PessoaEndereco(Cep, Bairro, Logradouro, CidadeId, Numero, Complemento);
    }
}