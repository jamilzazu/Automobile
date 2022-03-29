using Automobile.Domain.Commands.Veiculo;
using Automobile.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Application.Test.Commands.Veiculo
{
    [TestClass]
    public class AtualizarVeiculoCommandTests
    {
        private readonly CadastrarVeiculoCommand _veiculo = new(Guid.NewGuid(), Guid.NewGuid(), new Modelo("Modelo", 2000, 2022, Guid.NewGuid()), "12592282981", 50000, 100000);

        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_uma_novo_comando_atualizacao_invalida_o_proprietario_nao_deve_ser_atualizado()
        {
            var command = new AtualizarVeiculoCommand(_veiculo.Id, "", _veiculo.Modelo, 54400, 100000);

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
