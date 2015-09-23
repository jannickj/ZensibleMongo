namespace ZensibleMongo.Interfaces
{
    using MongoDB.Driver;

    /// <summary>
    /// Interface for mongo collection holders
    /// </summary>
    /// <typeparam name="TDocuments"></typeparam>
    public interface ICollectionContainer<TDocuments>
    {
        /// <summary>
        /// Mongo collection
        /// </summary>
        IMongoCollection<TDocuments> Collection { get; }
    }
}