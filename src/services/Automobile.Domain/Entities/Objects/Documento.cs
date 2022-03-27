using Automobile.Core.Enums;
using Automobile.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Automobile.Domain.Entities.Objects
{
    public class Documento
    {
        public const int DocumentoMaxLength = 14;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string NumeroDocumento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        //Construtor do EntityFramework
        protected Documento() { }

        public Documento(TipoDocumento tipoDocumento, string numeroDocumento)
        {
            NumeroDocumento = numeroDocumento;
            TipoDocumento = tipoDocumento;
        }
        public string TipoDocumentoDescricao()
        {
            return TipoDocumento.GetDescription().ToUpper();
        }

        public static bool ValidarDocumento(TipoDocumento tipoDocumento, string documento)
        {
            return (IsCpf(tipoDocumento, documento) || IsCnpj(tipoDocumento, documento));
        }

        private static bool IsCpf(TipoDocumento tipoDocumento, string documento)
        {
            if (tipoDocumento == TipoDocumento.Cnpj) { return false; }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            documento = documento.Trim().Replace(".", "").Replace("-", "");
            if (documento.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == documento)
                    return false;

            string tempdocumento = documento.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempdocumento[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempdocumento += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempdocumento[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return documento.EndsWith(digito);
        }

        private static bool IsCnpj(TipoDocumento tipoDocumento, string cnpj)
        {
            if (tipoDocumento == TipoDocumento.Cpf) { return false; }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}