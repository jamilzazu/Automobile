using Automobile.Domain.Commands.Veiculo;
using Automobile.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Application.Test.Commands.Veiculo
{
    [TestClass]
    public class AtualizarVeiculoCommandTests
    {
        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_uma_novo_comando_atualizacao_invalida_o_proprietario_nao_deve_ser_atualizado()
        {
            Modelo _modelo = new("Modelo", 2000, 2022, Guid.NewGuid());

            CadastrarVeiculoCommand _veiculo = new(_modelo.Id, Guid.NewGuid(), _modelo, "12592282981", 50000, 100000);

            var command = new AtualizarVeiculoCommand(_veiculo.Id, _veiculo.ProprietarioId, _veiculo.MarcaId, _modelo, "", 54400, 100000);

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
