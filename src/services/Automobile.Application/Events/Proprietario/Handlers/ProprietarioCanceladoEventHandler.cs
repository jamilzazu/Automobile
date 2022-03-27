using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class ProprietarioCanceladoEventHandler : INotificationHandler<ProprietarioCanceladoEvent>
    {
        public Task Handle(ProprietarioCanceladoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
