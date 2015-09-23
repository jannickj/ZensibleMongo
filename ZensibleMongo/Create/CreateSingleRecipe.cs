namespace ZensibleMongo.Create
{
    using System.Collections.Immutable;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Create a single document recipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class CreateSingleRecipe<TDocument> : ICollectionContainer<TDocument>
    {
        /// <summary>
        /// Document to be created
        /// </summary>
        public TDocument Document { get; set; }

        /// <summary>
        /// Mongo Collection
        /// </summary>
        public IMongoCollection<TDocument> Collection { get; set; }
        
    }
}