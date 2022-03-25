using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Application.Services.Interfaces
{
    public interface IProprietarioService
    {
        Task<bool> ExisteCpfJaCadastrado(Documento documento);
    }
}
