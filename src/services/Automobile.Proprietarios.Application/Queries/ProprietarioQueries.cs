using Automobile.Core.Helpers;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Application.Queries.Dto;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Automobile.Proprietarios.Domain.Entities.Objects;

namespace Automobile.Proprietarios.Domain.Queries
{
    public class ProprietarioQueries : IProprietarioQueries
    {
        private readonly IDbConnection _dbConnection;

        public ProprietarioQueries(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<ProprietarioDto> ObterProprietarioPorId(Guid idProprietario)
        {
            var sql = GetType().Assembly.GetScript("ObterProprietarioPorId.sql");

            return _dbConnection.QueryFirstOrDefaultAsync<ProprietarioDto>(sql, new { idProprietario });
        }

        public Task<ProprietarioDto> ObterProprietarioPeloNumeroDocumento(Documento documento)
        {
            var sql = GetType().Assembly.GetScript("ObterProprietarioPeloNumeroDocumento.sql");

            return _dbConnection.QueryFirstOrDefaultAsync<ProprietarioDto>(sql, new { documento.NumeroDocumento });
        }
    }
}
