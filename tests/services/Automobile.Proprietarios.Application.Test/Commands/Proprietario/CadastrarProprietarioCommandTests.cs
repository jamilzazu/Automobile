using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Proprietarios.Application.Test.Commands.Proprietario
{
    [TestClass]
    public class CadastrarProprietarioCommandTests
    {
        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_um_novo_comando_de_cadastro_invalido_o_proprietario_nao_deve_ser_gerado()
        {
            var command = new CadastrarProprietarioCommand("", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

            Assert.AreEqual(command.EhValido(), false);
        }

        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_uma_nova_atualizacao_invalido_o_proprietario_nao_deve_ser_atualizado()
        {
            var command = new AtualizarProprietarioCommand(Guid.NewGuid(), "", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

            Assert.AreEqual(command.EhValido(), false);
        }

        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_um_cancelamento_invalido_o_proprietario_nao_deve_ser_cancelado()
        {
            var command = new CancelarProprietarioCommand(Guid.Empty);

            Assert.AreEqual(command.EhValido(), false);
        }

        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_um_ativamento_invalido_o_proprietario_nao_deve_ser_ativado()
        {
            var command = new AtivarProprietarioCommand(Guid.Empty);

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
