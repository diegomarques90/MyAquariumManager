using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MyAquariumManager.Core.Helpers
{
    public static class ValidadorDeDocumentosHelper
    {
        private const int SUBTRACAO_ASCII = 48;

        /// <summary>
        /// Valida um número de CPF.
        /// </summary>
        /// <param name="cpf">O número do CPF (com ou sem máscara).</param>
        /// <returns>Retorna verdadeiro se o CPF for válido.</returns>
        public static bool EhUmCpfValido(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            cpf = RemoverCaracteresNaoNumericos(cpf);

            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            if (new string(cpf[0], 11) == cpf)
                return false;

            var estruturaCpf = new EstruturaCpf(cpf);

            CalcularPrimeiroDigitoVerificadorCpf(estruturaCpf);
            CalcularSegundoDigitoVerificadorCpf(estruturaCpf);

            return cpf.EndsWith(estruturaCpf.Digito);
        }

        private static void CalcularPrimeiroDigitoVerificadorCpf(EstruturaCpf estruturaCpf)
        {
            int[] multiplicador = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int soma = 0;
            var cpf = estruturaCpf.Cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicador[i];

            var resto = ObterResto(soma);

            estruturaCpf.Digito = resto.ToString();
            estruturaCpf.Cpf = cpf + resto;
        }

        private static void CalcularSegundoDigitoVerificadorCpf(EstruturaCpf estruturaCpf)
        {
            int[] multiplicador = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
            var cpf = estruturaCpf.Cpf.Substring(0, 10);
            int soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicador[i];

            var resto = ObterResto(soma);

            estruturaCpf.Digito += resto.ToString();
            estruturaCpf.Cpf = cpf + resto;
        }

        private static string ObterResto(int soma)
        {
            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return resto.ToString();
        }

        /// <summary>
        /// Valida um número de CNPJ.
        /// </summary>
        /// <param name="cnpj">O número do CNPJ (com ou sem máscara).</param>
        /// <returns>Retorna verdadeiro se o CNPJ for válido.</returns>
        public static bool EhUmCnpjValido(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            cnpj = RemoverCaracteresInvalidosParaCNPJ(cnpj);

            if (cnpj.Length != 14)
                return false;

            if (new string(cnpj[0], 14) == cnpj)
                return false;

            var estruturaCnpj = new EstruturaCnpj(cnpj);

            CalcularPrimeiroDigitoVerificadorCnpj(estruturaCnpj);
            CalcularSegundoDigitoVerificadorCnpj(estruturaCnpj);

            return cnpj.EndsWith(estruturaCnpj.Digito);
        }

        private static void CalcularPrimeiroDigitoVerificadorCnpj(EstruturaCnpj estruturaCnpj)
        {
            int[] multiplicador = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int soma = 0;
            var cnpj = estruturaCnpj.Cnpj.Substring(0, 12);

            for (int i = 0; i < 12; i++)
                soma += (cnpj[i] - SUBTRACAO_ASCII) * multiplicador[i];

            var resto = ObterResto(soma);

            estruturaCnpj.Digito = resto.ToString();
            estruturaCnpj.Cnpj = cnpj + resto;
        }

        private static void CalcularSegundoDigitoVerificadorCnpj(EstruturaCnpj estruturaCnpj)
        {
            int[] multiplicador = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            var cnpj = estruturaCnpj.Cnpj.Substring(0, 13);
            int soma = 0;

            for (int i = 0; i < 13; i++)
                soma += (cnpj[i] - SUBTRACAO_ASCII) * multiplicador[i];

            var resto = ObterResto(soma);

            estruturaCnpj.Digito += resto.ToString();
            estruturaCnpj.Cnpj = cnpj + resto;
        }

        /// <summary>
        /// Verificas se o documento (CPF ou CNPJ) é válido.
        /// </summary>
        /// <param name="documento">string contendo o documento (CPF ou CNPJ).</param>
        /// <returns>Retorna verdadeiro se o documento é um CPF ou CNPJ válido.</returns>
        public static bool EhUmDocumentoValido(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return false;

            string documentoLimpo = RemoverCaracteresNaoNumericos(documento);

            if (documentoLimpo.Length == 11)
                return EhUmCpfValido(documentoLimpo);
            else if (documentoLimpo.Length == 14)
                return EhUmCnpjValido(documentoLimpo);
            else
                return false;
        }

        private static string RemoverCaracteresNaoNumericos(string documento) => Regex.Replace(documento, @"[^\d]", "");
        private static string RemoverCaracteresInvalidosParaCNPJ(string cnpj) => Regex.Replace(cnpj, @"[ ./-]", "");
    }

    public class EstruturaCpf
    {
        public EstruturaCpf(string cpf)
        {
            Cpf = cpf;
        }

        public string Cpf { get; set; }
        public string Digito { get; set; }
    }

    public class EstruturaCnpj
    {
        public EstruturaCnpj(string cnpj)
        {
            Cnpj = cnpj;
        }
        public string Cnpj { get; set; }
        public string Digito { get; set; }
    }
}
