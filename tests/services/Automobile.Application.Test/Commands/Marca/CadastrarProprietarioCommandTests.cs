using Automobile.Domain.Commands.Marca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automobile.Application.Test.Commands.Proprietario
{
    [TestClass]
    public class CadastrarMarcaoCommandTests
    {
        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_um_novo_comando_de_cadastro_invalido_a_marca_nao_deve_ser_gerada()
        {
            var command = new CadastrarMarcaCommand("");

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
