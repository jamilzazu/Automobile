using System.ComponentModel;

namespace Automobile.Domain.Entities.Enums
{
    public enum StatusFluxo
    {
        [Description("Disponível")]
        Disponivel = 0,
        [Description("Indisponível")]
        Indisponivel = 1,
        [Description("Vendido")]
        Vendido = 99
    }
}
