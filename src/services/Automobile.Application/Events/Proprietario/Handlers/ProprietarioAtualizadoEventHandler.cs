using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class ProprietarioAtualizadoEventHandler : INotificationHandler<ProprietarioAtualizadoEvent>
    {
        public Task Handle(ProprietarioAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
