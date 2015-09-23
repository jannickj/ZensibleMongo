namespace ZensibleMongo
{
    using System.Collections.Immutable;
    using Create;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Create extension
    /// </summary>
    public static class CreateExtension
    {
        /// <summary>
        /// Recipe for creating multiple documents on the collection.
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="collection"></param>
        /// <param name="documents">Documents to be created.</param>
        /// <returns></returns>
        public static ICreateMultiRecipe<TDocument> Create<TDocument>(this IMongoCollection<TDocument> collection, params TDocument[] documents)
        {
            return new CreateMultiRecipe<TDocument> { Collection = collection, Documents = ImmutableList.Create(documents) };
        }


        /// <summary>
        /// Recipe for creating a single document on the collection.
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="collection"></param>
        /// <param name="document">Document to be created.</param>
        /// <returns></returns>
        public static ICreateSingleRecipe<TDocument> Create<TDocument>(this IMongoCollection<TDocument> collection, TDocument document)
        {
            return new CreateSingleRecipe<TDocument> { Collection = collection, Document = document };
        }
    }
}
