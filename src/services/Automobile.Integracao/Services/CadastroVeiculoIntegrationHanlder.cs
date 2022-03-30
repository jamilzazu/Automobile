using Automobile.Core.Mediator;
using Automobile.Core.Messages.Integration;
using Automobile.Domain.Commands.Veiculo;
using Automobile.MessageBus;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Automobile.Integracao.Services
{
    public class CadastroVeiculoIntegrationHanlder : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CadastroVeiculoIntegrationHanlder(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<VeiculoCadastradoIntegrationEvent, ResponseMessage>(async request =>
                await CadastrarVeiculo(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }

        private async Task<ResponseMessage> CadastrarVeiculo(VeiculoCadastradoIntegrationEvent message)
        {
            var veiculoCommand = new CadastrarVeiculoCommand(message.ProprietarioId, message.MarcaId, null, message.Renavam, message.Quilometragem, message.Valor);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(veiculoCommand);
            }

            return new ResponseMessage(sucesso);
        }
    }
}