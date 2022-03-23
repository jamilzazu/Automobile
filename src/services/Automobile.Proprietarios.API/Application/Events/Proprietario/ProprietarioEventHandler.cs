using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class ProprietarioEventHandler : INotificationHandler<ProprietarioRegistradoEvent>,
        INotificationHandler<ProprietarioAlteradoEvent>,
        INotificationHandler<ProprietarioCanceladoEvent>,
        INotificationHandler<ProprietarioAtivadoEvent>
    {
        public Task Handle(ProprietarioRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProprietarioAlteradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProprietarioCanceladoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProprietarioAtivadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
