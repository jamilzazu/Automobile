using Automobile.Application.Events.Veiculo;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class VeiculoIndisponibilizadoEventHandler : INotificationHandler<VeiculoIndisponibilizadoEvent>
    {
        public Task Handle(VeiculoIndisponibilizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
