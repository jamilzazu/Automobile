using Automobile.Domain.Events.Endereco;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class EnderecoCadastradoEventHandler : INotificationHandler<EnderecoCadastradoEvent>
    {
        public Task Handle(EnderecoCadastradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
