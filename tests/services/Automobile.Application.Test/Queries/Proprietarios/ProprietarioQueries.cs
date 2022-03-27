using Automobile.Core.Enums;
using Automobile.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Automobile.Application.Test.Queries.Proprietarios
{
    public static class ProprietarioQueries
    {
        public static Expression<Func<Proprietario, bool>> ListarTodosProprietarios()
        {
            return x => x.Cancelado == Cancelado.Nao || x.Cancelado == Cancelado.Sim;
        }

        public static Expression<Func<Proprietario, bool>> ListarProprietariosCancelados()
        {
            return x => x.Cancelado == Cancelado.Sim;
        }

        public static Expression<Func<Proprietario, bool>> ListarProprietariosAtivos()
        {
            return x => x.Cancelado == Cancelado.Nao;
        }
    }
}
