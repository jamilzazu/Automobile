﻿using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Proprietario.Request;
using Automobile.Application.Queries.Response;

namespace Automobile.Application.Queries.Interfaces
{
    public interface IProprietarioQueries
    {
        PaginatedResult<ListaProprietarioResponse> ListarProprietarios(FiltroListaProprietariosRequest filtro);
    }
}