namespace ZensibleMongo.Create
{
    using System.Collections.Immutable;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Create a single document createMultiRecipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    internal class CreateSingleRecipe<TDocument> : ICreateSingleRecipe<TDocument>
    {
        public IMongoCollection<TDocument> Collection { get; set; }
        public TDocument Document { get; set; }
    }
}