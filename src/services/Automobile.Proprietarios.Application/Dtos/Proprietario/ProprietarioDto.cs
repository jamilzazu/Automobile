using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;

namespace Automobile.Proprietarios.Application.Queries.Dto
{
    public class ProprietarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoDocumento{ get; set; }
        public string Documento { get; set; }
        public Cancelado Cancelado { get; set; }
    }
}