using Automobile.Proprietarios.API.Models.Enums;
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
                    TipoDocumento = item.TipoDocumento,
                    Documento = item.FormatarCPF(item.Documento.Numero),
                    Email = item.Email.Endereco,
                    Cancelado = item.Cancelado
                };
            }
        }

        public ProprietarioViewModel CarregaInformacaoProprietario(Proprietario proprietario)
        {
            return new ProprietarioViewModel
            {
                Id = proprietario.Id,
                Nome = proprietario.Nome,
                TipoDocumento = proprietario.TipoDocumento,
                Documento = proprietario.FormatarCPF(proprietario.Documento.Numero),
                Email = proprietario.Email.Endereco,
                Cancelado = proprietario.Cancelado
            };
        }
    }
}