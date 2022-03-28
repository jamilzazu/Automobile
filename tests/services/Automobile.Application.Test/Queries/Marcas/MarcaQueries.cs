using Automobile.Core.Enums;
using Automobile.Domain.Entitites;
using System;
using System.Linq.Expressions;

namespace Automobile.Application.Queriess.Marcas
{
    public static class MarcaQueries
    {
        public static Expression<Func<Marca, bool>> ListarTodasMarcas()
        {
            return x => x.Cancelado == Cancelado.Nao || x.Cancelado == Cancelado.Sim;
        }

        public static Expression<Func<Marca, bool>> ListarMarcasCanceladas()
        {
            return x => x.Cancelado == Cancelado.Sim;
        }

        public static Expression<Func<Marca, bool>> ListarMarcasAtivas()
        {
            return x => x.Cancelado == Cancelado.Nao;
        }
    }
}
