using Automobile.Domain.Commands.Endereco;
using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Entities.Enums;
using Automobile.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Application.Test.Commands.Endereco
{
    [TestClass]
    public class AtualizarEnderecoCommandTests
    {
        private readonly CadastrarEnderecoCommand _enderecoCommando = new(Guid.NewGuid(), "", "44", "", "Centro", "78005000", "Cuiabá", "MT", DateTime.Now);

        [TestMethod]
        [TestCategory("Proprietario.Application.Commands")]
        public void Dado_uma_novo_comando_atualizacao_invalida_o_endereco_nao_deve_ser_atualizado()
        {
            var command = new AtualizarEnderecoCommand(_enderecoCommando.Id, _enderecoCommando.ProprietarioId, "", "44", "", "Centro", "78005000", "Cuiabá", "MT", DateTime.Now);

            Assert.AreEqual(command.EhValido(), false);
        }
    }
}
