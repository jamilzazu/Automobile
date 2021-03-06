using System;

namespace Automobile.Application.Queries.Response
{
    public class ListaProprietarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Cancelado { get; set; }
        public string DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
    }
}