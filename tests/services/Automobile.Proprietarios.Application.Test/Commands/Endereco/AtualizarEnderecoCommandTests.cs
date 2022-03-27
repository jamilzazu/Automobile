using Automobile.Proprietarios.Domain.Commands.Endereco;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Proprietarios.Application.Test.Commands.Endereco
{
    [TestClass]
    public class AtualizarEnderecoCommandTests
    {
        private readonly CadastrarEnderecoCommand _enderecoCommando = new(Guid.NewGuid(), "", "44", "", "Centro", "78005000", "Cuiabá", "MT");

        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_uma_novo_comando_atualizacao_invalida_o_endereco_nao_deve_ser_atualizado()
        {
            var command = new AtualizarEnderecoCommand(_enderecoCommando.Id, _enderecoCommando.ProprietarioId, "", "44", "", "Centro", "78005000", "Cuiabá", "MT");

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
