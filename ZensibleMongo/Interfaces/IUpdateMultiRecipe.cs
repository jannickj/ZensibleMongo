namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;
    using MongoDB.Driver;

    /// <summary>
    /// Inferface for update recipe that only updates multiple documents
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IUpdateMultiRecipe<TDocument> : IUpdateRecipe<TDocument>
    {
    }
}