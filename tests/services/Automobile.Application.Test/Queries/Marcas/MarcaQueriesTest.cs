using Automobile.Application.Queriess.Marcas;
using Automobile.Core.Enums;
using Automobile.Domain.Entitites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Automobile.Application.Queries.Marcas
{
    [TestClass]
    public class MarcaQueriesTests
    {
        private readonly IList<Marca> _proprietario;

        public MarcaQueriesTests()
        {
            _proprietario = new List<Marca>
            {
                new(Guid.NewGuid(), "Honda", Cancelado.Nao),
                new(Guid.NewGuid(), "Toyota", Cancelado.Sim),
                new(Guid.NewGuid(), "Ferrari", Cancelado.Nao),
                new(Guid.NewGuid(), "Fiat", Cancelado.Sim),
                new(Guid.NewGuid(), "Hyundai", Cancelado.Sim),
            };
        }

        [TestMethod]
        [TestCategory("Application.Queries")]
        public void Dado_a_consulta_de_Marcas_deve_retornar_Todos()
        {
            var resultado = _proprietario.AsQueryable().Where(MarcaQueries.ListarTodasMarcas());
            Assert.AreEqual(resultado.Count(), 5);
        }

        [TestMethod]
        [TestCategory("Application.Queries")]
        public void Dado_a_consulta_de_Marcas_deve_retornar_Os_Cancelados()
        {
            var resultado = _proprietario.AsQueryable().Where(MarcaQueries.ListarMarcasCanceladas());
            Assert.AreEqual(resultado.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Application.Queries")]
        public void Dado_a_consulta_de_Marcas_deve_retornar_Os_Ativos()
        {
            var resultado = _proprietario.AsQueryable().Where(MarcaQueries.ListarMarcasAtivas());
            Assert.AreEqual(resultado.Count(), 2);
        }
    }
}
