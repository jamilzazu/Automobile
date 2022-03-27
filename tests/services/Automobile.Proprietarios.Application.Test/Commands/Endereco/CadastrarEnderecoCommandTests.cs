﻿using Automobile.Proprietarios.Domain.Commands.Endereco;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Proprietarios.Application.Test.Commands.Endereco
{
    [TestClass]
    public class CadastrarEnderecoCommandTests
    {
        private readonly CadastrarProprietarioCommand _proprietarioCommand = new("Jamil", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com");

        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_um_novo_comando_de_cadastro_invalido_o_endereco_nao_deve_ser_gerado()
        {
            var command = new CadastrarEnderecoCommand(_proprietarioCommand.Id, "", "44", "", "Centro", "78005000", "Cuiabá", "MT", DateTime.Now);

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
