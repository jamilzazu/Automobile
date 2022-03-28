using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Entities.Enums;
using Automobile.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automobile.Application.Test.Commands.Proprietario
{
    [TestClass]
    public class CadastrarProprietarioCommandTests
    {
        [TestMethod]
        [TestCategory("Application.Commands")]
        public void Dado_um_novo_comando_de_cadastro_invalido_o_proprietario_nao_deve_ser_gerado()
        {
            var command = new CadastrarProprietarioCommand("", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
