namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;
    using MongoDB.Driver;

    /// <summary>
    /// Inferface for update recipe that only updates a single document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IUpdateSingleRecipe<TDocument> : IUpdateRecipe<TDocument>
    {
    }
}