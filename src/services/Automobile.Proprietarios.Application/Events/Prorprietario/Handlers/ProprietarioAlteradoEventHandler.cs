using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Domain.Events.Proprietario.Handlers
{
    public class ProprietarioAlteradoEventHandler : INotificationHandler<ProprietarioAtualizadoEvent>
    {
        public Task Handle(ProprietarioAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
