using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class ProprietarioEventHandler : INotificationHandler<ProprietarioRegistradoEvent>
    {
        public Task Handle(ProprietarioRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
