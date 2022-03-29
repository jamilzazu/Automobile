using Automobile.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automobile.Domain.Test.Entities
{
    [TestClass]
    public class ModeloTests
    {
        private readonly Modelo _modelo = new("Modelo", 2021, 2022, Guid.NewGuid());


        [TestMethod]
        [TestCategory("Domain.Entity.Modelo")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_descricao_ser_obrigatorio()
        {
            _modelo.Atualizar("Modelo", 2021, 2022);

            Assert.AreNotEqual(_modelo.Descricao, string.Empty);
            Assert.IsNotNull(_modelo.Descricao);
        }


        [TestMethod]
        [TestCategory("Domain.Entity.Modelo")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_anoFabricacao_ser_obrigatorio()
        {
            _modelo.Atualizar("Modelo", 2021, 2022);

            Assert.AreNotEqual(_modelo.AnoFabricacao, 0);
            Assert.AreNotEqual(_modelo.AnoModelo, string.Empty);
            Assert.IsNotNull(_modelo.AnoModelo);
        }

        [TestMethod]
        [TestCategory("Domain.Entity.Modelo")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_anoModelo_ser_obrigatorio()
        {
            _modelo.Atualizar("Modelo", 2021, 2002);

            Assert.AreNotEqual(_modelo.AnoModelo, 0);
            Assert.AreNotEqual(_modelo.AnoModelo, string.Empty);
            Assert.IsNotNull(_modelo.AnoModelo);
        }

    }
}
