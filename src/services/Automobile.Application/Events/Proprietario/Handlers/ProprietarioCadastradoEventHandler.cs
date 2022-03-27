using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class ProprietarioCadastradoEventHandler : INotificationHandler<ProprietarioCadastradoEvent>
    {
        public Task Handle(ProprietarioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
