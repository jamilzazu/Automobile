using Automobile.Proprietarios.API.ViewModel;

namespace Automobile.Proprietarios.API.Models
{
    public class EnderecoModelBuilder
    {
        public EnderecoViewModel CarregaInformacaoProprietario(Endereco endereco)
        {
            return new EnderecoViewModel
            {
                Id = endereco.Id,
                ProprietarioId = endereco.ProprietarioId,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado
            };
        }
    }
}