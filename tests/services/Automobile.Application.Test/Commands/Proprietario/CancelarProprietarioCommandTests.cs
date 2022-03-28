using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Application.Test.Commands.Proprietario
{
    [TestClass]
    public class CancelarProprietarioCommandTests
    {
        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_um_comando_cancelamento_invalido_o_proprietario_nao_deve_ser_ativado()
        {
            bool proprietarioIdValido = Guid.TryParse("", out _);

            Assert.IsFalse(proprietarioIdValido);
        }
    }
}
