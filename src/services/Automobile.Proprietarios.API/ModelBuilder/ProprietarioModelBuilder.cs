using Automobile.Proprietarios.API.ViewModel;
using System.Collections.Generic;

namespace Automobile.Proprietarios.API.Models
{
    public class ProprietarioModelBuilder
    {
        public IEnumerable<ProprietarioViewModel> ListaProprietarioViewModel(IEnumerable<Proprietario> lista)
        {
            foreach (var item in lista)
            {
                yield return new ProprietarioViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.FormatarCPF(item.Cpf.Numero),
                    Email = item.Email.Endereco,
                    Status = item.Cancelado ? "Cancelado" : "Ativo"
                };
            }
        }

        public ProprietarioViewModel CarregaInformacaoProprietario(Proprietario proprietario)
        {
            return new ProprietarioViewModel
            {
                Id = proprietario.Id,
                Nome = proprietario.Nome,
                Cpf = proprietario.FormatarCPF(proprietario.Cpf.Numero),
                Email = proprietario.Email.Endereco,
                Status = proprietario.Cancelado ? "Cancelado" : "Ativo"
            };
        }
    }
}