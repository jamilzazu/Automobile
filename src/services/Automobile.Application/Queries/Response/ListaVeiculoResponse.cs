using System;

namespace Automobile.Application.Queries.Response
{
    public class ListaVeiculoResponse
    {
        public Guid Id { get; set; }
        public string Renavam { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoModelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string Quilometragem { get; set; }
        public string Valor { get; set; }
        public string Cidade { get; set; }
        public string Status { get; set; }
        public string DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
    }
}