using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Domain.Test.Entities
{
    [TestClass]
    public class VeiculoTests
    {
        private readonly Veiculo _veiculo = new(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "12592282981", 50000, 100000, FluxoRevenda.Disponivel);


        [TestMethod]
        [TestCategory("Domain.Entity.Veiculo")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_renavam_deve_ser_obrigatorio()
        {
            _veiculo.Atualizar("12592282981", 50000, 100000, FluxoRevenda.Disponivel);

            Assert.AreNotEqual(_veiculo.Renavam, string.Empty);
            Assert.IsNotNull(_veiculo.Renavam);
        }

        [TestMethod]
        [TestCategory("Domain.Entity.Veiculo")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_status_Indisponivel_nao_deve_voltar_para_Disponivel()
        {
            _veiculo.Atualizar("12592282981", 50000, 100000, FluxoRevenda.Indisponivel);

            Assert.AreNotEqual(_veiculo.Status, FluxoRevenda.Disponivel);
        }

        [TestMethod]
        [TestCategory("Domain.Entity.Veiculo")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_status_Vendido_nao_deve_voltar_para_Disponivel()
        {
            _veiculo.Atualizar("12592282981", 50000, 100000, FluxoRevenda.Vendido);

            Assert.AreNotEqual(_veiculo.Status, FluxoRevenda.Disponivel);
        }
    }
}
