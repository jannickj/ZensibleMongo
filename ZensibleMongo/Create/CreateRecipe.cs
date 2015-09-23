namespace ZensibleMongo.Create
{
    using System.Collections.Immutable;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Create recipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class CreateRecipe<TDocument> : ICollectionContainer<TDocument>, ICreateDefinition<TDocument>
    {
        /// <summary>
        /// Documents
        /// </summary>
        public ImmutableList<TDocument> Documents { get; set; }

        /// <summary>
        /// Mongo collection
        /// </summary>
        public IMongoCollection<TDocument> Collection { get; set; }

        /// <summary>
        /// Immutable list of documents to create
        /// </summary>
        /// <returns></returns>
        public ImmutableList<TDocument> AllDocuments()
        {
            return Documents;
        }
    }
}