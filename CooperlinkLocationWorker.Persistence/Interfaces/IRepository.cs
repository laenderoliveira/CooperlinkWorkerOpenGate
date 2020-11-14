using CooperlinkLocationWorker.Domain.Collections;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Persistence.Interfaces
{
    public interface IRepository<T> where T : CollectionModel
    {
        Task AddAsync(T document);

        Task<T> FindAsync(FilterDefinition<T> filter, SortDefinition<T> sort);
    }
}
