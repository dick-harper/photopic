using System;
using MongoDB.Bson.Serialization;

namespace photopic.domain
{
    public interface IDocument<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
        DateTime Created { get; set; }
    }

    public interface IDocument : IDocument<Guid>
    {
    }
}