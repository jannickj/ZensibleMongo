namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;

    /// <summary>
    /// Inferface for multiple creates recipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface ICreateMultiRecipe<TDocument> : ICreateRecipe<TDocument>
    {
        /// <summary>
        /// Immutable list of documents to create
        /// </summary>
        /// <returns></returns>
        ImmutableList<TDocument> AllDocuments();
    }
}