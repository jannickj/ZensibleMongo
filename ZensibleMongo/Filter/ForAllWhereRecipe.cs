namespace ZensibleMongo.Filter
{
    using System;
    using System.Collections.Immutable;
    using System.Linq.Expressions;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// For all where recipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class ForAllWhereRecipe<TDocument> : IFilterDefinition<TDocument>
    {
        /// <summary>
        /// Predicate to satisfy for selection
        /// </summary>
        public Expression<Func<TDocument, bool>> Predicate { get; set; }

        /// <summary>
        /// Mongo collection
        /// </summary>
        public IMongoCollection<TDocument> Collection { get; set; }

        /// <summary>
        /// Document selectors
        /// </summary>
        /// <returns></returns>
        public ImmutableList<FilterDefinition<TDocument>> Filters()
        {
            var theFilter = Builders<TDocument>.Filter.Where(Predicate);
            return ImmutableList.Create(theFilter);
        }
    }
}