using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using photopic.domain;

namespace photopic.repositories.Contexts
{
    public interface IMongoContext
    {
        IMongoClient Client { get; set; }
        IMongoDatabase Database { get; set; }
        IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : IDocument;
    }
}