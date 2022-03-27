using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automobile.Proprietarios.Application.Test.Commands.Proprietario
{
    [TestClass]
    public class AtualizarProprietarioCommandTests
    {
        private readonly CadastrarProprietarioCommand _proprietarioCommand = new("Jamil", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_uma_novo_comando_atualizacao_invalida_o_proprietario_nao_deve_ser_atualizado()
        {
            var command = new AtualizarProprietarioCommand(_proprietarioCommand.Id, "", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
