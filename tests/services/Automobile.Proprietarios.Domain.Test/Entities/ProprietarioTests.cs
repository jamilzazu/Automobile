using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Proprietarios.Domain.Test.Entities
{
    [TestClass]
    public class ProprietarioTests
    {
        // Nome

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_o_campo_Nome_deve_ser_obrigatorio()
        {
            Proprietario _proprietario_CampoNomeVazio = new Proprietario(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

            Assert.AreNotEqual(_proprietario_CampoNomeVazio.Nome, string.Empty);
            Assert.IsNotNull(_proprietario_CampoNomeVazio.Nome);
        }

        // Id

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_uma_novo_cadastro_o_campo_Guid_Id_deve_ser_valido()
        {
            Proprietario _proprietario_CampoIdValido = new Proprietario(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

            bool ehValido = Guid.TryParse(_proprietario_CampoIdValido.Id.ToString(), out Guid guidOutput);

            Assert.IsTrue(ehValido);
        }

        // E-mail

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_o_campo_Email_deve_ser_valido()
        {
            bool email = new Email("teste@teste.com").Endereco == "teste@teste.com";

            Assert.IsTrue(email);
            Assert.AreNotEqual(email, string.Empty);
            Assert.IsNotNull(email);
        }


        // Documento

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_o_campo_Documento_deve_ser_valido_como_CPF()
        {
            var documento = new Documento(TipoDocumento.Cpf, "77753102001").ValidarDocumento(TipoDocumento.Cpf, "77753102001");

            Assert.IsTrue(documento);
        }

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_o_campo_Documento_deve_ser_valido_como_CNPJ()
        {
            var documento = new Documento(TipoDocumento.Cnpj, "72873649000128").ValidarDocumento(TipoDocumento.Cnpj, "72873649000128");

            Assert.IsTrue(documento);
        }
    }
}
