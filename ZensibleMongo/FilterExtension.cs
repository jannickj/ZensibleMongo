namespace ZensibleMongo
{
    using System;
    using System.Linq.Expressions;
    using Filter;
    using Interfaces;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// Extension for all filter recipes
    /// </summary>
    public static class FilterExtension
    {
        /// <summary>
        /// Recipe for seleting documents based on a predicate
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate">a function to test documents for a condition</param>
        /// <returns></returns>
        public static IFilterMultiRecipe<TDocument> ForAllWhere<TDocument>(
            this IMongoCollection<TDocument> collection,
            Expression<Func<TDocument, bool>> predicate)
        {
            return new ForAllWhereRecipe<TDocument> { Collection = collection, Predicate = predicate };
        }

        /// <summary>
        /// Recipe for seleting all documents
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IFilterMultiRecipe<TDocument> ForAll<TDocument>(this IMongoCollection<TDocument> collection)
        {
            return new ForAllRecipe<TDocument> { Collection = collection };
        }

        /// <summary>
        /// Recipe for seleting documents based on a its id
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="collection"></param>
        /// <param name="id">Mongo id of the document</param>
        /// <returns></returns>
        public static IFilterSingleRecipe<TDocument> ForId<TDocument>(this IMongoCollection<TDocument> collection, ObjectId id)
        {
            return new ForIdRecipe<TDocument> { Collection = collection, Id = id };
        }

        /// <summary>
        /// Recipe for seleting the first document that passes a condition
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate">a function to test documents for a condition</param>
        /// <returns></returns>
        public static IFilterSingleRecipe<TDocument> ForSingleWhere<TDocument>(
            this IMongoCollection<TDocument> collection,
            Expression<Func<TDocument, bool>> predicate)
        {
            return new ForFilterSingleWhere<TDocument> { Collection = collection, Predicate = predicate };
        }
    }
}
