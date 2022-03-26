using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;

namespace Automobile.Proprietarios.Application.Queries.Response
{
    public class ProprietarioResponse
    {
        public ProprietarioResponse()
        {
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Documento Documento { get; set; }
        public Cancelado Cancelado { get; set; }
    }
}