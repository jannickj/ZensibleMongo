namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;
    using MongoDB.Driver;

    /// <summary>
    /// Interface for selector recipes
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IFilterDefinition<TDocument> : ICollectionContainer<TDocument>
    {
        /// <summary>
        /// Immutable list of filters to select with
        /// </summary>
        /// <returns></returns>
        ImmutableList<FilterDefinition<TDocument>> Filters();
    }
}