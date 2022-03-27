using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace Automobile.Proprietarios.Domain.Test.Entities
{
    [TestClass]
    public class ProprietarioTests
    {
        #region Testes

        #region Nome

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_Nome_deve_ser_obrigatorio()
        {
            Proprietario _proprietario_CampoNomeVazio = new(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com", Cancelado.Nao);

            Assert.AreNotEqual(_proprietario_CampoNomeVazio.Nome, string.Empty);
            Assert.IsNotNull(_proprietario_CampoNomeVazio.Nome);
        }

        #endregion Nome

        #region Id

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_uma_novo_cadastro_ou_atualizacao_o_campo_Guid_Id_deve_ser_valido()
        {
            Proprietario _proprietario_CampoIdValido = new(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com", Cancelado.Nao);


            Assert.IsTrue(Guid.TryParse(_proprietario_CampoIdValido.Id.ToString(), out Guid guidResult));
            Assert.IsNotNull(guidResult);
        }

        #endregion Id

        #region E-mail

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_Email_deve_ser_valido()
        {
            bool emailValido = ValidarDocumento("teste@teste.com");

            Assert.IsTrue(emailValido);
            Assert.AreNotEqual("teste@teste.com", string.Empty);
            Assert.IsNotNull("teste@teste.com");
        }

        #endregion E-mail

        #region Documento

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_Documento_deve_ser_valido_como_CPF()
        {
            var documento = ValidarDocumento(TipoDocumento.Cpf, "77753102001");

            Assert.IsTrue(documento);
        }


        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cadastro_ou_atualizacao_o_campo_Documento_deve_ser_valido_como_CNPJ()
        {
            var documento = ValidarDocumento(TipoDocumento.Cnpj, "72873649000128");

            Assert.IsTrue(documento);
        }

        #endregion Documento

        #region Atualizar

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_uma_nova_atualizacao_o_Nome_Documento_Email_deve_ser_Alterado()
        {
            Proprietario proprietario = new(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com", Cancelado.Nao);

            string nome_cadastrado = proprietario.Nome;
            Documento document_cadastrado = proprietario.Documento;
            string email_cadastrado = proprietario.Email.Endereco;

            proprietario.Atualizar("Nome_Atualizado", new Documento(TipoDocumento.Cpf, "77753102001"), "teste_Atualizado@teste.com");

            Assert.AreNotEqual(nome_cadastrado, proprietario.Nome);
            Assert.AreNotEqual(document_cadastrado, proprietario.Documento);
            Assert.AreNotEqual(email_cadastrado, proprietario.Email);
        }

        #endregion Atualizar

        #region Cancelar

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_cancelamento_o_Status_deve_ser_Cancelado()
        {
            Proprietario _proprietario_Cancelamento = new(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com", Cancelado.Nao);

            _proprietario_Cancelamento.Cancelar();

            Assert.AreEqual(_proprietario_Cancelamento.Cancelado, Cancelado.Sim);
        }

        #endregion Cancelar 

        #region Ativar

        [TestMethod]
        [TestCategory("Proprietario.Domain.Entity.Proprietario")]
        public void Dado_um_novo_ativamento_o_Status_deve_ser_Ativado()
        {
            Proprietario _proprietario_Cancelamento = new(Guid.NewGuid(), "Jamil Zazu", new Documento(TipoDocumento.Cpf, "77753102001"), "teste@teste.com", Cancelado.Sim);

            _proprietario_Cancelamento.Ativar();

            Assert.AreEqual(_proprietario_Cancelamento.Cancelado, Cancelado.Nao);
        }

        #endregion Ativar 

        #endregion Testes 



        #region Métodos 

        public static bool ValidarDocumento(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }

        public static bool ValidarDocumento(TipoDocumento tipoDocumento, string documento)
        {
            return (IsCpf(tipoDocumento, documento) || IsCnpj(tipoDocumento, documento));
        }

        private static bool IsCpf(TipoDocumento tipoDocumento, string documento)
        {
            if (tipoDocumento == TipoDocumento.Cnpj) { return false; }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            documento = documento.Trim().Replace(".", "").Replace("-", "");
            if (documento.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == documento)
                    return false;

            string tempdocumento = documento.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempdocumento[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempdocumento += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempdocumento[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return documento.EndsWith(digito);
        }

        private static bool IsCnpj(TipoDocumento tipoDocumento, string cnpj)
        {
            if (tipoDocumento == TipoDocumento.Cpf) { return false; }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }

        #endregion Métodos 
    }
}
