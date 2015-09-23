namespace ZensibleMongo.Filter
{
    using System.Collections.Immutable;
    using Interfaces;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// For Id Recipe
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ForIdRecipe<T> : IFilterSingleRecipe<T>
    {
        /// <summary>
        /// Mongo document id
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Mongo collection
        /// </summary>
        public IMongoCollection<T> Collection { get; set; }

        /// <summary>
        /// Selectors
        /// </summary>
        /// <returns></returns>
        public ImmutableList<FilterDefinition<T>> Filters()
        {
            var filter = Builders<T>.Filter.Eq(new StringFieldDefinition<T, ObjectId>("_id"), Id);
            return ImmutableList.Create(filter);
        }
    }
}