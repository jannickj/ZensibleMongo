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
    internal class SetUpdateMultiRecipe<TDocument, TField> : IUpdateMultiRecipe<TDocument>
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
        public IUpdateRecipe<TDocument> NextRecipe { get; set; }

        /// <summary>
        /// Filter to use for update
        /// </summary>
        public IFilterRecipe<TDocument> FilterRecipe { get; set; }

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
            return NextRecipe?.UpdateDefinitions().Add(update) ?? ImmutableList.Create(update);
        }
    }
}