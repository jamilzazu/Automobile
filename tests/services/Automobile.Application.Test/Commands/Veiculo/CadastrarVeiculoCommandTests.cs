using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Application.Test.Commands.Veiculo
{
    [TestClass]
    public class CadastrarVeiculoCommandTests
    {
        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_um_novo_comando_de_cadastro_invalido_o_veiculo_nao_deve_ser_cadastrado()
        {
            var command = new CadastrarVeiculoCommand("", new Modelo("Honda", 2022, 2022, Guid.NewGuid()), 100000, 50000);

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
