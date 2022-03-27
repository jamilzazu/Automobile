using Automobile.Proprietarios.Domain.Events.Endereco;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Domain.Events.Proprietario.Handlers
{
    public class EnderecoAtualizadoEventHandler : INotificationHandler<EnderecoAtualizadoEvent>
    {
        public Task Handle(EnderecoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
