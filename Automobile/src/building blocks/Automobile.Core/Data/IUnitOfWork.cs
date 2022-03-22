using System.Threading.Tasks;

namespace Automobile.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}