using System.Threading.Tasks;
using photopic.domain;

namespace photopic.repositories
{
    public interface IBaseMongoRepository : IReadOnlyMongoRepository
    {
        Task AddOneAsync<TDocument>(TDocument document) where TDocument : IDocument;
        void AddOne<TDocument>(TDocument document) where TDocument : IDocument;
    }
}