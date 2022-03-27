using Automobile.Core.Enums;
using Automobile.Application.Test.Queries.Proprietarios;
using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Enums;
using Automobile.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Automobile.Application.Test.Queries.Tests
{
    [TestClass]
    public class ProprietarioQueriesTests
    {
        private readonly IList<Proprietario> _proprietario;

        public ProprietarioQueriesTests()
        {
            _proprietario = new List<Proprietario>
            {
                new(Guid.NewGuid(), "Jamil", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com", Cancelado.Sim),

                new(Guid.NewGuid(), "Jamil Tadeu", new Documento(TipoDocumento.Cpf, "14689669015"), "teste2@teste.com", Cancelado.Nao),

                new(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cnpj, "74354306000182"), "teste3@teste.com", Cancelado.Nao),

                new(Guid.NewGuid(), "Tadeu Zazu", new Documento(TipoDocumento.Cnpj, "84994306000109"), "teste4@teste.com", Cancelado.Sim),

                new(Guid.NewGuid(), "Zazu", new Documento(TipoDocumento.Cnpj, "82442237000197"), "teste5@teste.com", Cancelado.Nao)
            };
        }

        [TestMethod]
        [TestCategory("Proprietario.Application.Queries")]
        public void Dado_a_consulta_de_Proprietarios_deve_retornar_Todos()
        {
            var resultado = _proprietario.AsQueryable().Where(ProprietarioQueries.ListarTodosProprietarios());
            Assert.AreEqual(resultado.Count(), 5);
        }

        [TestMethod]
        [TestCategory("Proprietario.Application.Queries")]
        public void Dado_a_consulta_de_Proprietarios_deve_retornar_Os_Cancelados()
        {
            var resultado = _proprietario.AsQueryable().Where(ProprietarioQueries.ListarProprietariosCancelados());
            Assert.AreEqual(resultado.Count(), 2);
        }

        [TestMethod]
        [TestCategory("Proprietario.Application.Queries")]
        public void Dado_a_consulta_de_Proprietarios_deve_retornar_Os_Ativos()
        {
            var resultado = _proprietario.AsQueryable().Where(ProprietarioQueries.ListarProprietariosAtivos());
            Assert.AreEqual(resultado.Count(), 3);
        }
    }
}
