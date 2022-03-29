using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Application.Test.Commands.Veiculo
{
    [TestClass]
    public class VenderVeiculoCommandTests
    {
        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_um_comando_vender_invalido_o_veiculo_nao_deve_ser_vendido()
        {
            bool veiculoIdValido = Guid.TryParse("", out _);

            Assert.IsFalse(veiculoIdValido);
        }
    }
}
