using System.ComponentModel;

namespace Automobile.Domain.Entities.Enums
{
    public enum FluxoRevenda
    {
        [Description("Disponível")]
        Disponivel = 1,
        [Description("Indisponível")]
        Indisponivel = 0,
        [Description("Vendido")]
        Vendido = 99
    }
}
