namespace ZensibleMongo.Filter
{
    using System;
    using System.Collections.Immutable;
    using System.Linq.Expressions;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// For a single document where recipe
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class ForSingleWhere<TDocument> : IFilterDefinition<TDocument>
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
        /// Selectors
        /// </summary>
        /// <returns></returns>
        public ImmutableList<FilterDefinition<TDocument>> Filters()
        {
            var theFilter = Builders<TDocument>.Filter.Where(Predicate);
            return ImmutableList.Create(theFilter);
        }
    }
}