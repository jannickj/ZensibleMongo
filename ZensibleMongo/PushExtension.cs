namespace ZensibleMongo
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Create;
    using Delete;
    using Interfaces;
    using MongoDB.Driver;

    /// <summary>
    /// Extension for handling pushes to mongo collection
    /// </summary>
    public static class PushExtension
    {
        /// <summary>
        /// Updates to the mongo db based on the recipe
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="options">Update Options</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<UpdateResult> Push<TDocument>(
            this IUpdateDefinition<TDocument> recipe,
            UpdateOptions options = null,
            CancellationToken token = default(CancellationToken))
        {
            var filter = Factory.ExtractFilter(recipe);
            var update = Factory.Combine(recipe.UpdateDefinitions());

            return await recipe.Collection.UpdateManyAsync(filter, update, options, token);
        }

        /// <summary>
        /// Finds and updates a single documents and returns the document
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="options">Update Options</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<TDocument> Push<TDocument>(
            this IUpdateSingleDefinition<TDocument> recipe,
            UpdateOptions options = null,
            CancellationToken token = default(CancellationToken))
        {
            var filter = Factory.ExtractFilter(recipe);
            var update = Factory.Combine(recipe.UpdateDefinitions());
            return await recipe.Collection.FindOneAndUpdateAsync(filter, update, null, token);
        }

        /// <summary>
        /// Creates a single documents and returns the document
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<TDocument> Push<TDocument>(
            this CreateSingleRecipe<TDocument> recipe,
            CancellationToken token = default(CancellationToken))
        {
            var value = recipe.Document.CloneJson();
            await recipe.Collection.InsertOneAsync(value, token);
            return value;
        }

        /// <summary>
        /// Creates multiple documents and returns them updated with their id. 
        /// (Input is cloned and is not affected)
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="options"></param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<IEnumerable<TDocument>> Push<TDocument>(
            this CreateRecipe<TDocument> recipe,
            InsertManyOptions options = null,
            CancellationToken token = default(CancellationToken))
        {
            var inserts = recipe.AllDocuments().Select(v => v.CloneJson()).ToArray();
            await recipe.Collection.InsertManyAsync(inserts, options, token);
            return inserts;
        }

        /// <summary>
        /// Deletes multiple documents based on the recipe
        /// (Input is cloned and is not affected)
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<DeleteResult> Push<TDocument>(
            this DeleteRecipe<TDocument> recipe,
            CancellationToken token = default(CancellationToken))
        {
            var filter = Factory.ExtractFilter(recipe);
            return await recipe.Collection.DeleteManyAsync(filter, token);
        }

        /// <summary>
        /// Finds and deletes a single documents then returns that document
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="token">Cancellation Token</param>
        public static async Task<TDocument> Push<TDocument>(
            this DeleteSingleRecipe<TDocument> recipe,
            CancellationToken token = default(CancellationToken))
        {
            var filter = Factory.ExtractFilter(recipe);
            return await recipe.Collection.FindOneAndDeleteAsync(filter, cancellationToken: token);
        }
    }
}
