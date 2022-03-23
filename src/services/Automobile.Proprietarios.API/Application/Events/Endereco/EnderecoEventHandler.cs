using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class EnderecoEventHandler : INotificationHandler<EnderecoRegistradoEvent>,
        INotificationHandler<EnderecoAlteradoEvent>
    {
        public Task Handle(EnderecoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(EnderecoAlteradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
