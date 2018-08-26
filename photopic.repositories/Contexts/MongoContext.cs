using System.Linq;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Driver;
using photopic.domain;
using photopic.repositories.Attributes;

/*
 * Thanks to Alexandre SPIESER, https://github.com/alexandre-spieser
 * for the great MongoDB generic repository architecture!
 * https://github.com/alexandre-spieser/mongodb-generic-repository
 *  
 */

namespace photopic.repositories.Contexts
{
    public class MongoContext: IMongoContext
    {
        static MongoContext()
        {
            MongoDefaults.GuidRepresentation = GuidRepresentation.Standard;
        }

        public MongoContext(IMongoDatabase mongoDatabase)
        {
            Database = mongoDatabase;
            Client = Database.Client;
        }

        public MongoContext(string connectionString, string databaseName)
        {
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(databaseName);
        }

        public IMongoClient Client { get; set; }

        public IMongoDatabase Database { get; set; }

        public IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : IDocument
        {
            throw new System.NotImplementedException();
        }

        public void SetGuidRepresentation(GuidRepresentation guidRepresentation)
        {
            MongoDefaults.GuidRepresentation = guidRepresentation;
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string partitionKey = null) where TDocument : IDocument
        {
            if (string.IsNullOrEmpty(partitionKey))
            {
                return Database.GetCollection<TDocument>(GetAttributeCollectionName<TDocument>());
            }
            return Database.GetCollection<TDocument>(partitionKey + "-" + GetAttributeCollectionName<TDocument>());
        }

        private string GetAttributeCollectionName<TDocument>()
        {
            return (typeof(TDocument).GetTypeInfo()
                .GetCustomAttributes(typeof(CollectionNameAttribute))
                .FirstOrDefault() as CollectionNameAttribute)?.Name;
        }
    }
}