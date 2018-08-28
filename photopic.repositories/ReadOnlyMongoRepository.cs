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
            return await GetCollection<TDocument>().Find(filter).FirstOrDefaultAsync();
        }

        public TDocument GetById<TDocument>(Guid id) where TDocument : IDocument
        {
            var filter = Builders<TDocument>.Filter.Eq("Id", id);
            return MongoContext.GetCollection<TDocument>().Find(filter).FirstOrDefault();
        }

        protected IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : IDocument
        {
            return MongoContext.GetCollection<TDocument>();
        }

        //protected IMongoCollection<TDocument> HandlePartitioned<TDocument, TKey>(string partitionKey)
        //    where TDocument : IDocument<TKey>
        //    where TKey : IEquatable<TKey>
        //{
        //    if (!string.IsNullOrEmpty(partitionKey))
        //    {
        //        return GetCollection<TDocument, TKey>(partitionKey);
        //    }
        //    return GetCollection<TDocument, TKey>();
        //}
    }
}