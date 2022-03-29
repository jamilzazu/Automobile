using Automobile.Application.Events.Veiculo;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class VeiculoAtualizadoEventHandler : INotificationHandler<VeiculoAtualizadoEvent>
    {
        public Task Handle(VeiculoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
