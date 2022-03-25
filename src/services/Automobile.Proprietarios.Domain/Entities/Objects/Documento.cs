using Automobile.Core.Utils;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Automobile.Proprietarios.Domain.Entities.Objects
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
            if (!Validar(numeroDocumento)) throw new DomainException("Documento inválido");
            NumeroDocumento = numeroDocumento;
            TipoDocumento = TipoDocumento;
        }

        public static bool Validar(string cpf)
        {
            cpf = cpf.ApenasNumeros(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}