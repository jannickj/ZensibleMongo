namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;
    using MongoDB.Driver;

    /// <summary>
    /// Inferface for recipes that updates the collection
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IDeleteRecipe<TDocument> : IMongoCollectionContainer<TDocument>, IFilterRecipeContainer<TDocument>
    {
    }
}