using Automobile.Core.Mediator;
using Automobile.Core.Messages.Integration;
using Automobile.Domain.Commands.Veiculo;
using Automobile.MessageBus;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Automobile.Integracao.Services
{
    public class CadastroVeiculoIntegrationHanlder : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CadastroVeiculoIntegrationHanlder(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
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

            if (sucesso.IsValid)
                await EnviarEmail(message.Renavam, message.Quilometragem, message.Valor);

            return new ResponseMessage(sucesso);
        }

        public async Task EnviarEmail(string renavam, decimal quilometragem, decimal valor)
        {
            var apiKey = "SEND_GRID_KEY";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("jamilzazu@hotmail.com", "Jamil Zazu]"),
                Subject = "Novo veiculo cadastrado",
                PlainTextContent = $@"Veiculo: 
                {renavam}, {quilometragem}, {valor}"
            };
            msg.AddTo(new EmailAddress("E-mail Destinatario"));
            var response = await client.SendEmailAsync(msg);
        }
    }
}