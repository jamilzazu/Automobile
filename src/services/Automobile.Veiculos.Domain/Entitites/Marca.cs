using Automobile.Core.DomainObjects;
using Automobile.Core.Enums;

namespace Automobile.Veiculos.Domain.Entitites
{
    public class Marca : Entity, IAggregateRoot
    {
        public string Nome { get; private set; } 
        public Cancelado Documento { get; private set; }
    }
}
