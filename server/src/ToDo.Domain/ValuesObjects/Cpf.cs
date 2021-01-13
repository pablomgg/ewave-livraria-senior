using System;
using System.Linq;
using ToDo.Domain.Enums;
using ToDo.Infra.Core;

namespace ToDo.Domain.ValuesObjects
{
    public class Cpf
    {
        private readonly string _numero;

        public Cpf(string numero, bool bypass = false)
        {
            if (!bypass)
            {
                if (!IsValid(numero))
                {
                    throw new InvalidoException(numero);
                }
            }

            _numero = LimparFormatacao(numero);
        }

        public Cpf(Cpf cpf) : this(cpf.ToString()) { }

        protected Cpf() { }

        public override string ToString() => _numero;

        public string ToString(TipoFormatacaoCpf tipoFormatacao)
        {
            switch (tipoFormatacao)
            {
                case TipoFormatacaoCpf.SemFormatacao:
                    return _numero;
                case TipoFormatacaoCpf.FormatacaoPadrao:
                    return Convert.ToUInt64(_numero).ToString(@"000\.000\.000\-00");
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoFormatacao), tipoFormatacao, "O tipo de formatação informado não é válido.");
            }
        }

        public static bool TryParse(string numero, out Cpf cpf)
        {
            cpf = null;
            try
            {
                cpf = new Cpf(numero);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool IsValid(string cpf)
        {
            try
            {
                var cpfLimpo = LimparFormatacao(cpf);

                if (cpfLimpo?.Length != 11)
                    return false;

                if (SaoDigitosRepetidos(cpfLimpo))
                    return false;

                var digito = CalcularDigitoVerificador(cpfLimpo);

                return cpf.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        private static string LimparFormatacao(string cpf)
        {
            return cpf?.Trim().Replace(".", "").Replace("-", "");
        }

        private static string CalcularDigitoVerificador(string numero)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = numero.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;
            digito = digito + resto;

            return digito;
        }

        private static bool SaoDigitosRepetidos(string numero)
        {
            var firstDigit = numero[0];
            return numero.All(digito => digito == firstDigit);
        }

        public static implicit operator string(Cpf cpf)
        {
            return cpf.ToString();
        }

        public static implicit operator Cpf(string cpf)
        {
            return new Cpf(cpf);
        }

        public class InvalidoException : BusinessException
        {
            public InvalidoException(string cpf) : base($"O valor '{cpf}' informado não é um CPF válido.") { }
        }
    }
}