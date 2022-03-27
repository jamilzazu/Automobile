//using Automobile.Core.Enums;
//using Automobile.Domain.Entitites;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;

//namespace Automobile.Domain.Test.Entities
//{
//    public class MarcaTests
//    {
//        [TestClass]
//        public class ProprietarioTests
//        {
//            private readonly Marca _marca = new(Guid.NewGuid(), "Honda", Cancelado.Nao);

//            #region Testes

//            #region Nome

//            [TestMethod]
//            [TestCategory("Veiculos.Domain.Entity.Marca")]
//            public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_Nome_deve_ser_obrigatorio()
//            {
//                Assert.AreNotEqual(_marca.Nome, string.Empty);
//                Assert.IsNotNull(_marca.Nome);
//            }

//            #endregion Nome

//            #region Id

//            [TestMethod]
//            [TestCategory("Veiculos.Domain.Entity.Marca")]
//            public void Dado_uma_novo_cadastro_ou_atualizacao_o_campo_Guid_Id_deve_ser_valido()
//            {
//                Assert.IsTrue(Guid.TryParse(_marca.Id.ToString(), out Guid guidResult));
//                Assert.IsNotNull(guidResult);
//            }

//            #endregion Id

//            #region Atualizar

//            [TestMethod]
//            [TestCategory("Veiculos.Domain.Entity.Marca")]
//            public void Dado_uma_nova_atualizacao_o_Nome_Documento_Email_deve_ser_Alterado()
//            {
//                string nome_cadastrado = _marca.Nome;

//                _marca.Atualizar("Nome_Atualizado");

//                Assert.AreNotEqual(_marca.Nome, nome_cadastrado);
//            }

//            #endregion Atualizar

//            #region Cancelar

//            [TestMethod]
//            [TestCategory("Veiculos.Domain.Entity.Marca")]
//            public void Dado_um_novo_cancelamento_o_Status_deve_ser_Cancelado()
//            {
//                _marca.Cancelar();
//                Assert.AreEqual(_marca.Cancelado, Cancelado.Sim);
//            }

//            #endregion Cancelar 

//            #region Ativar

//            [TestMethod]
//            [TestCategory("Veiculos.Domain.Entity.Marca")]
//            public void Dado_um_novo_ativamento_o_Status_deve_ser_Ativado()
//            {
//                _marca.Ativar();
//                Assert.AreEqual(_marca.Cancelado, Cancelado.Nao);
//            }

//            #endregion Ativar 

//            #endregion Testes 

//        }
//    }
//}