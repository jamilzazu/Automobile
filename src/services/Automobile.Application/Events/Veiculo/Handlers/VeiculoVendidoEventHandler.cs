using Automobile.Application.Events.Veiculo;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class VeiculoVendidoEventHandler : INotificationHandler<VeiculoVendidoEvent>
    {
        public Task Handle(VeiculoVendidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
