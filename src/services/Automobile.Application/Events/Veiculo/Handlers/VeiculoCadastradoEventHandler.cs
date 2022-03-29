using Automobile.Application.Events.Veiculo;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Events.Proprietario.Handlers
{
    public class VeiculoCadastradoEventHandler : INotificationHandler<VeiculoCadastradoEvent>
    {
        public Task Handle(VeiculoCadastradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
