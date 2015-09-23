namespace ZensibleMongo.Delete
{
    using Interfaces;

    /// <summary>
    /// Recipe for deleting a single document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    internal class DeleteSingleRecipe<TDocument> : Recipe<TDocument>, IDeleteSingleRecipe<TDocument>
    {
    }
}