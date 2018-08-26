using MongoDB.Driver;
using photopic.domain;

namespace photopic.repositories.Contexts
{
    public class MongoContext: IMongoContext
    {
        public MongoContext()
        {

        }

        public IMongoClient Client { get; set; }

        public IMongoDatabase Database { get; set; }

        public IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : IDocument
        {
            throw new System.NotImplementedException();
        }
    }
}