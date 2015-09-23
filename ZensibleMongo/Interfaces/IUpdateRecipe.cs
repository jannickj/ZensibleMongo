namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;
    using MongoDB.Driver;

    /// <summary>
    /// Inferface for recipes that updates the collection
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IUpdateRecipe<TDocument> : IMongoCollectionContainer<TDocument>, IFilterRecipeContainer<TDocument>
    {
        /// <summary>
        /// All update recipes
        /// </summary>
        /// <returns></returns>
        ImmutableList<UpdateDefinition<TDocument>> UpdateDefinitions();
    }
}