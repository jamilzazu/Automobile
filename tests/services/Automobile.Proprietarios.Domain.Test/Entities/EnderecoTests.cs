using Automobile.Core.Enums;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Proprietarios.Domain.Test.Entities
{
    [TestClass]
    public class EnderecoTests
    {
        #region Testes

        private readonly Proprietario _proprietario = new(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com", Cancelado.Nao);


        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Endereco")]
        public void Dado_um_novo_cadastro_ou_atualizacao_todos_os_campos_devem_ser_obrigatorios_exceto_Complemento()
        {
            Endereco endereco = new(Guid.NewGuid(), _proprietario.Id, "Rua 1", "44", "", "Centro", "78005000", "Cuiabá", "MT");

            Assert.AreNotEqual(endereco.Logradouro, string.Empty);
            Assert.IsNotNull(endereco.Logradouro);
        }

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Endereco")]
        public void Dado_uma_novo_cadastro_ou_atualizacao_o_campo_Guid_Id_deve_ser_valido()
        {
            Assert.IsTrue(Guid.TryParse(_proprietario.Id.ToString(), out Guid guidResult));
            Assert.IsNotNull(guidResult);
        }
    }

    #endregion Testes 
}
