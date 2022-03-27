using System.ComponentModel;

namespace Automobile.Domain.Entities.Enums
{
    public enum TipoDocumento
    {
        [Description("Cpf")]
        Cpf = 1,
        [Description("Cnpj")]
        Cnpj = 0
    }
}
