using System;
using System.Linq;
using ToDo.Infra.Core;

namespace ToDo.Domain.ValuesObjects
{
    public class Cnpj
    {
        private readonly string _value;

        public Cnpj(string value)
        {
            if (!Valid(value)) throw new InvalidoException();
            _value = ToClean(value);
        }

        public Cnpj(string value, bool format) : this(value)
        {
            _value = format ? Convert.ToUInt64(value).ToString(@"00\.000\.000\/0000\-00") : _value;
        }

        public static implicit operator string(Cnpj cnpj) => cnpj?._value;
        public static implicit operator Cnpj(string numero) => new Cnpj(numero);
        public override string ToString() => _value;

        public static bool TryParse(string numero, out Cnpj cnpj)
        {
            cnpj = null;

            try
            {
                cnpj = new Cnpj(numero);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool Valid(string value)
        {
            try
            {
                value = ToClean(value);

                if (value.Length != 14) return false;
                if (value.All(dig => dig == value[0])) return false;

                var soma = 0;
                int resto;
                string digito;
                var temp = value.Substring(0, 12);

                for (var i = 0; i < 12; i++)
                    soma += int.Parse(temp[i].ToString()) * new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }[i];

                resto = (soma % 11);

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                temp += digito;
                soma = 0;

                for (var i = 0; i < 13; i++)
                    soma += int.Parse(temp[i].ToString()) * new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }[i];

                resto = (soma % 11);

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito += resto.ToString();

                return value.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        private string ToClean(string numero)
        {
            var newValue = string.Empty;
            return numero.Trim().Replace(".", newValue).Replace("-", newValue).Replace("/", newValue);
        }

        public class InvalidoException : BusinessException
        {
            public InvalidoException() : base("O Cnpj é inválido.") { }
        }
    }
}