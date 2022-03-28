using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Application.Test.Commands.Proprietario
{
    [TestClass]
    public class CancelarMarcaCommandTests
    {
        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_um_comando_cancelamento_invalido_a_marca_nao_deve_ser_ativada()
        {
            bool marcaIdValido = Guid.TryParse("", out _);

            Assert.IsFalse(marcaIdValido);
        }
    }
}
