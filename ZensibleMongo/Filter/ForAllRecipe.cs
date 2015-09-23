namespace ZensibleMongo.Filter
{
    using System.Collections.Immutable;
    using Interfaces;
    using MongoDB.Driver;


    /// <summary>
    /// For all selector recipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class ForAllRecipe<TDocument> : IFilterDefinition<TDocument>
    {
        /// <summary>
        /// Mongo collection
        /// </summary>
        public IMongoCollection<TDocument> Collection { get; set; }

        /// <summary>
        /// Selector filters
        /// </summary>
        /// <returns></returns>
        public ImmutableList<FilterDefinition<TDocument>> Filters()
        {
            return ImmutableList<FilterDefinition<TDocument>>.Empty;
        }
    }
}