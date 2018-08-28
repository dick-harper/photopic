using System;
using System.Threading.Tasks;
using photopic.domain;
using photopic.repositories.Contexts;

namespace photopic.repositories
{
    public abstract class BaseMongoRepository : ReadOnlyMongoRepository, IBaseMongoRepository
    {
        protected BaseMongoRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
            MongoContext = new MongoContext(connectionString, databaseName);
        }

        public virtual async Task AddOneAsync<TDocument>(TDocument document) where TDocument : IDocument
        {
            FormatDocument(document);
            await GetCollection<TDocument>().InsertOneAsync(document);
        }

        public virtual void AddOne<TDocument>(TDocument document) where TDocument : IDocument
        {
            FormatDocument(document);
            GetCollection<TDocument>().InsertOneAsync(document);
        }

        private void FormatDocument(IDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }
            if (document.Id == default(Guid))
            {
                document.Id = Guid.NewGuid();
            }
        }
    }
}