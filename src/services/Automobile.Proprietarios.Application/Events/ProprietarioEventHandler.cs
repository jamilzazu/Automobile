using Automobile.Proprietarios.Domain.Events.Proprietario;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Domain.Events.Events
{
    public class ProprietarioEventHandler : INotificationHandler<ProprietarioCadastradoEvent>
    {
        public Task Handle(ProprietarioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
