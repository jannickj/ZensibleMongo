namespace ZensibleMongo.Delete
{
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Delete recipe
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Recipe<T> : IDeleteMultiRecipe<T>
    {
        /// <summary>
        /// Mongo collection
        /// </summary>
        public IMongoCollection<T> Collection { get; set; }

        /// <summary>
        /// Selector for delete
        /// </summary>
        public IFilterRecipe<T> FilterRecipe { get; set; }
    }
}