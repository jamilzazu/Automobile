using Automobile.Core.Helpers;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Application.Queries.Dto;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Automobile.Proprietarios.Application.Queries.Proprietario.Request;
using Automobile.Proprietarios.Application.Queries.Response;
using Automobile.Database.SqlServer.Extensions;
using Automobile.Database.SqlServer.Order;
using System.Linq;

namespace Automobile.Proprietarios.Domain.Queries
{
    public class ProprietarioQueries : IProprietarioQueries
    {
        private readonly IDbConnection _dbConnection;

        public ProprietarioQueries(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PaginatedResult<ListaProprietarioResponse>> ListarProprietariosAsync(FiltroListaProprietariosRequest filtro)
        {
            var sql = GetType().Assembly.GetScript("ListaProprietario.sql");

            if (!string.IsNullOrWhiteSpace(filtro.Busca))
            {
                sql += " AND (Nome LIKE @Busca OR Documento LIKE @Busca )";
            }

            var filtroTodos = new FiltroListaProprietariosRequest
            {
                Busca = filtro.Busca,
                Nome = filtro.Nome,
                NumeroDocumento = filtro.NumeroDocumento,
                OrderBy = filtro.OrderBy,
                PageIndex = 1,
                PageSize = 99999
            };

            var lista = await _dbConnection.PaginatedQueryAuthorizedAsync<ListaProprietarioResponse>(sql, filtroTodos);

            var listaRetorno = new PaginatedResult<ListaProprietarioResponse>(filtro.PageIndex, filtro.PageSize, lista.Data.Count(), lista.Data.Skip((filtro.PageIndex - 1) * filtro.PageSize).Take(filtro.PageSize));

            return listaRetorno;
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
