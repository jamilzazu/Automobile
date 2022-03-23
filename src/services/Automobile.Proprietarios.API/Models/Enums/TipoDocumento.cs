using System.ComponentModel;

namespace Automobile.Proprietarios.API.Models.Enums
{
    public enum TipoDocumento
    {
        [Description("Cpf")]
        Cpf = 1,
        [Description("Cnpj")]
        Cnpj = 0
    }
}
