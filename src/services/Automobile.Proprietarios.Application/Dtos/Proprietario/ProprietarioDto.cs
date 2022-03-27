using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;

namespace Automobile.Proprietarios.Application.Dto
{
    public class ProprietarioDto
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Documento Documento { get; set; }
        public Cancelado Cancelado { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}