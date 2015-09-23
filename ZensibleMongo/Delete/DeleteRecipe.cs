namespace ZensibleMongo.Delete
{
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Delete recipe
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DeleteRecipe<T> : ICollectionContainer<T>, IFilterDefinitionContainer<T>
    {
        /// <summary>
        /// Mongo collection
        /// </summary>
        public IMongoCollection<T> Collection { get; set; }

        /// <summary>
        /// Selector for delete
        /// </summary>
        public IFilterDefinition<T> FilterDefinition { get; set; }
    }
}