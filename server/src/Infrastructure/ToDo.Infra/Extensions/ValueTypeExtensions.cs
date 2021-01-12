using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ToDo.Infra.Extensions
{
    public static class ValueTypeExtensions
    {
        /// <summary>
        /// Verificar se a lista tem valores
        /// </summary>
        /// <param name="values">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool HasItens<T>(this IEnumerable<T> values) => values != null && values.Any();


        /// <summary>
        /// Verificar se o valor é vazio.
        /// </summary>
        /// <param name="guid">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsEmpty(this Guid guid) => guid == Guid.Empty;

        /// <summary>
        /// Verificar se o guid tem valor.
        /// </summary>
        /// <param name="guid">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool HasValue(this Guid guid) => !guid.IsEmpty() && guid.IsNotNull();

        /// <summary>
        /// Verificar se o guid tem valor.
        /// </summary>
        /// <param name="guid">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool HasValue(this Guid? guid) => guid.HasValue && guid.Value != Guid.Empty;

        /// <summary>
        /// Verifica se a string informada é vazia ou nula.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source) => string.IsNullOrEmpty(source);

        /// <summary>
        /// Verifica se a string informada é vazia, nula ou espaço.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string source) => string.IsNullOrWhiteSpace(source);

        /// <summary>
        /// Verifica se a string informada nao é vazia, nula ou espaço.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullOrWhiteSpace(this string source) => !source.IsNullOrWhiteSpace();

        /// <summary>
        /// Verifica se a string informada é vazia, nula ou é espaço e se seu tamanho é maior ao tamanho informado.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length">Parametro para validar o tamanho da string</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpaceAndTheSizeIsLargerThan(this string source, int length) =>
            string.IsNullOrWhiteSpace(source) || source.Length > length;

        /// <summary>
        /// Verifica se a string informada é vazia, nula ou é espaço e se seu tamanho é menor ao tamanho informado.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length">Parametro para validar o tamanho da string</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpaceAndTheSizeIsLessThan(this string source, int length) =>
            string.IsNullOrWhiteSpace(source) || source.Length < length;

        /// <summary>
        /// Verificar se o valor é nulo ou vazio.
        /// </summary>
        /// <param name="guid">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsNullOrEmpty(this Guid? guid) => guid == null || guid == Guid.Empty;

        /// <summary>
        /// Verifica se o valor é menor que zero
        /// </summary>
        /// <param name="number">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsNegative(this int number) => number < 0;

        /// <summary>
        /// Verificar se o valor é menor ou igual a zero
        /// </summary>
        /// <param name="number">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsLessThanZero(this int number) => number <= 0;

        /// <summary>
        /// Verificar se o valor é menor ou igual a zero
        /// </summary>
        /// <param name="number">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsLessThanZero(this decimal number) => number <= 0;

        /// <summary>
        /// Verificar se o valor é nulo e menor ou igual a zero
        /// </summary>
        /// <param name="number">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsLessThanZero(this decimal? number) => !number.HasValue || number <= 0;

        /// <summary>
        /// Verificar se o valor é nulo e menor ou igual a zero
        /// </summary>
        /// <param name="number">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsLessThanZero(this int? number) => !number.HasValue || number <= 0;

        /// <summary>
        /// Verifica se o valor é falso
        /// </summary>
        /// <param name="boolean">O Parâmetro para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsFalse(this bool boolean) => boolean.Equals(false);

        /// <summary>
        /// Verifica se o objeto é Nulo
        /// </summary>
        /// <param name="value">Um valor para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsNull<T>(this T value) => value == null;


        /// <summary>
        /// Verifica se o objeto não é Nulo
        /// </summary>
        /// <param name="value">Um valor para a verificação.</param>
        /// <returns>Valor boleano</returns>
        public static bool IsNotNull<T>(this T value) => !value.IsNull();

        /// <summary>
        /// Verifica se uma lista de valores é vazia ou nula
        /// </summary>
        /// <typeparam name="T">Qualquer tipo de objeto</typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsNullOrCountEqualsZero<T>(this IEnumerable<T> values) => values == null || !values.Any();

        /// <summary>
        /// Verifica se Data que está sendo inserida é inválida '1/1/0001'.
        /// </summary>
        /// <param name="source">Um parâmetro do tipo data</param>
        /// <returns></returns>
        public static bool IsInvalid(this DateTime source) =>
            default(DateTime) == source
            || source.IsNull()
            || source.Date == DateTime.MaxValue.Date
            || source.Date == DateTime.MinValue.Date
            || source.Date <= new DateTime(1900, 1, 1).Date;

        /// <summary>
        /// Verifica se Data nullable que está sendo inserida é inválida '1/1/0001'.
        /// </summary>
        /// <param name="source">Um parâmetro do tipo data</param>
        /// <returns></returns>
        public static bool IsInvalid(this DateTime? source) =>
            source.HasValue &&
            (default(DateTime) == source
             || source.Value.Date == DateTime.MaxValue.Date
             || source.Value.Date == DateTime.MinValue.Date
             || source.IsNull()
             || source.Value.Date <= new DateTime(1900, 1, 1));


        /// <summary>
        /// Verifica se um Enum é diferente ao valor informado
        /// </summary>
        /// <param name="source">Um parâmetro do tipo enum para validar</param>
        /// <param name="value">Um parâmetro do tipo enum para ser validado</param>
        /// <returns></returns>
        public static bool NotEquals(this Enum source, Enum value) => !source.Equals(value);

        /// <summary>
        /// Verifica se um Enum é do tipo informado
        /// </summary>
        /// <param name="source">Um parâmetro do tipo enum para validar</param>
        /// <returns></returns>
        public static bool IsType<T>(this Enum source) where T : struct, IConvertible =>
            Enum.IsDefined(typeof(T), source);

        /// <summary>
        /// Verifica se um Enum não é do tipo informado
        /// </summary>
        /// <param name="source">Um parâmetro do tipo enum para validar</param>
        /// <returns></returns>
        public static bool IsNotType<T>(this Enum source) where T : struct, IConvertible => !source.IsType<T>();


        /// <summary>
        /// Remove todos os acentos da string
        /// </summary>
        /// <param name="source">Um parâmetro do tipo string para remover acentos</param>
        /// <returns></returns>
        public static string WithoutAccents(this string source)
        {
            const string strComAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç'";
            const string strSemAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc ";
            var i = 0;

            foreach (var c in strComAcentos)
            {
                source = source.Replace(c.ToString().Trim(), strSemAcentos[i].ToString().Trim());
                i++;
            }

            return source;
        }

        /// <summary>
        /// Verifica se no campo string tem somente letras
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool OnlyLetter(this string source) => !Regex.IsMatch(source, "\\d");

        /// <summary>
        /// Verifica se campo tem somente letras e caracteres especiais
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool OnlyLetterAndSpecialCharacters(this string source) => !Regex.IsMatch(source, @"^\D+$");

        /// <summary>
        /// Obtém a descrição do Enum
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum obj)
        {
            var fi = obj.GetType().GetField(obj.ToString());
            if (fi == null) return string.Empty;

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return obj.ToString();
        }

        /// <summary>
        /// Verifica se há alguma propriedade com valor na classe.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool HasValue<TObject>(this TObject source) where TObject : class
        {
            return source
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Select(f => f.GetValue(source))
                .Any(v => v.IsNotNull());
        }

        /// <summary>
        /// Verifica se todas as propriedades de uma classe não tem valor.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool Worthless<TObject>(this TObject source) where TObject : class
        {
            return !HasValue(source);
        }

        /// <summary>
        /// Obtém a idade através dos anos.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int GetAge(this DateTime source)
        {
            return ((DateTime.Today.Year * 100 + DateTime.Today.Month) * 100 + DateTime.Today.Day -
                    (source.Year * 100 + source.Month) * 100 + source.Day) / 10000;
        }
    }
}