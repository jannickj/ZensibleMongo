namespace ZensibleMongo.Update
{
    using System;
    using System.Collections.Immutable;
    using System.Linq.Expressions;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Recipe for setting a field on a document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    /// <typeparam name="TField"></typeparam>
    public class SetRecipe<TDocument, TField> : IUpdateDefinition<TDocument>, ICollectionContainer<TDocument>
    {
        /// <summary>
        /// Field selector
        /// </summary>
        public Expression<Func<TDocument, TField>> Field { get; set; }

        /// <summary>
        /// Value to set the selected field to
        /// </summary>
        public TField Value { get; set; }

        /// <summary>
        /// Next update recipe
        /// </summary>
        public IUpdateDefinition<TDocument> NextDefinition { get; set; }

        /// <summary>
        /// Filter to use for update
        /// </summary>
        public IFilterDefinition<TDocument> FilterDefinition { get; set; }

        /// <summary>
        /// Mongo collection
        /// </summary>
        public IMongoCollection<TDocument> Collection { get; set; }

        /// <summary>
        /// All updates to perform on document
        /// </summary>
        /// <returns></returns>
        public ImmutableList<UpdateDefinition<TDocument>> UpdateDefinitions()
        {
            var update = Builders<TDocument>.Update.Set(Field, Value);
            return NextDefinition?.UpdateDefinitions().Add(update) ?? ImmutableList.Create(update);
        }
    }
}