using System;
using System.Threading.Tasks;
using photopic.domain;

namespace photopic.repositories
{
    public interface IReadOnlyMongoRepository
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        Task<TDocument> GetByIdAsync<TDocument>(Guid id) where TDocument : IDocument;

        TDocument GetById<TDocument>(Guid id) where TDocument : IDocument;

    }
}