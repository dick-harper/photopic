using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using photopic.domain;
using photopic.repositories.Contexts;

namespace photopic.repositories
{
    public class ReadOnlyMongoRepository : IReadOnlyMongoRepository
    {
        protected IMongoContext MongoContext = null;

        public ReadOnlyMongoRepository()
        {
            
        }

        protected ReadOnlyMongoRepository(string connectionString, string databaseName)
        {
            MongoContext = new MongoContext(connectionString, databaseName);
        }

        protected ReadOnlyMongoRepository(IMongoContext mongoContext)
        {
            MongoContext = mongoContext;
        }

        protected ReadOnlyMongoRepository(IMongoDatabase mongoDatabase)
        {
            MongoContext = new MongoContext(mongoDatabase);
        }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public async Task<TDocument> GetByIdAsync<TDocument>(Guid id) where TDocument : IDocument
        {
            var filter = Builders<TDocument>.Filter.Eq("Id", id);
            return await MongoContext.GetCollection<TDocument>().Find(filter).FirstOrDefaultAsync();
        }

        public TDocument GetById<TDocument>(Guid id) where TDocument : IDocument
        {
            var filter = Builders<TDocument>.Filter.Eq("Id", id);
            return MongoContext.GetCollection<TDocument>().Find(filter).FirstOrDefault();
        }
    }
}