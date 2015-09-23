namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;

    /// <summary>
    /// Inferface for single create recipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface ICreateSingleRecipe<TDocument> : ICreateRecipe<TDocument>
    {
        /// <summary>
        /// Document to create on the collection
        /// </summary>
        TDocument Document { get; set; }
    }
}