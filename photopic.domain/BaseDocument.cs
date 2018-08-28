using System;
using MongoDB.Bson.Serialization.Attributes;

namespace photopic.domain
{
    public class BaseDocument : IDocument
    {

        public BaseDocument()
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
        }

        [BsonId]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
    }
}