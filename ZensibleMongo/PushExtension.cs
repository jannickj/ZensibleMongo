namespace ZensibleMongo
{
    using System;
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
        /// Updates to the mongo db based on the createMultiRecipe
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="options">Update Options</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<UpdateResult> PushAsync<TDocument>(
            this IUpdateRecipe<TDocument> recipe,
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
        public static async Task<TDocument> PushAsync<TDocument>(
            this IUpdateSingleRecipe<TDocument> recipe,
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
        public static async Task<TDocument> PushAsync<TDocument>(
            this ICreateSingleRecipe<TDocument> recipe,
            CancellationToken token = default(CancellationToken))
        {
            
            var value =  recipe.Document.CloneObject();
            await recipe.Collection.InsertOneAsync(value, token);
            return value;
        }

        /// <summary>
        /// Creates multiple documents and returns them updated with their id. 
        /// (Input is cloned and is not affected)
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="createMultiRecipe"></param>
        /// <param name="options"></param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<IEnumerable<TDocument>> PushAsync<TDocument>(
            this ICreateMultiRecipe<TDocument> createMultiRecipe,
            InsertManyOptions options = null,
            CancellationToken token = default(CancellationToken))
        {
            var inserts = createMultiRecipe.AllDocuments().Select(v => v.CloneObject()).ToArray();
            await createMultiRecipe.Collection.InsertManyAsync(inserts, options, token);
            return inserts;
        }

        /// <summary>
        /// Deletes multiple documents based on the createMultiRecipe
        /// (Input is cloned and is not affected)
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public static async Task<DeleteResult> PushAsync<TDocument>(
            this IDeleteMultiRecipe<TDocument> recipe,
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
        public static async Task<TDocument> PushAsync<TDocument>(
            this IDeleteSingleRecipe<TDocument> recipe,
            CancellationToken token = default(CancellationToken))
        {
            var filter = Factory.ExtractFilter(recipe);
            return await recipe.Collection.FindOneAndDeleteAsync(filter, cancellationToken: token);
        }
    }
}
