using System;
using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class CampoMaiorQuePermitidoException : BusinessException
    {
        public CampoMaiorQuePermitidoException(string campo, int tamanho) : base($"Campo '{campo}' com tamanho maior que o permitido. O tamanho máximo permitido é {tamanho} caracteres!") { }
    }

    public class CampoNuloOuVazioOuMenorOuIgualZeroException : BusinessException
    {
        public CampoNuloOuVazioOuMenorOuIgualZeroException(string campo, Type type) : base(type == typeof(string) || type == typeof(Guid) ? $"Campo '{campo}' não pode ser vazio." : $"Campo '{campo}' não pode ser igual ou menor que zero.") { }
    }
}