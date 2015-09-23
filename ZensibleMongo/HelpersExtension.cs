namespace ZensibleMongo
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MongoDB.Driver;

    /// <summary>
    /// Addition helper extension for mongo
    /// </summary>
    public static class HelpersExtension
    {
        /// <summary>
        /// Get the first document on the cursor otherwise returns default
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="cursor">Mongo cursor</param>
        /// <returns></returns>
        public static async Task<TDocument> FirstOrDefaultAsync<TDocument>(this IAsyncCursor<TDocument> cursor)
        {
            var hasValue = await cursor.MoveNextAsync();
            return hasValue ? cursor.Current.FirstOrDefault() : default(TDocument);
        }

        /// <summary>
        /// Get the first document on the cursor otherwise returns default
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="cursorTask">Mongo cursor task</param>
        /// <returns></returns>
        public static async Task<TDocument> FirstOrDefaultAsync<TDocument>(this Task<IAsyncCursor<TDocument>> cursorTask)
        {
            var res = await cursorTask;
            return await res.FirstOrDefaultAsync();
        }

        /// <summary>
        /// gets the first document on the cursor otherwise returns default (this method is blocking)
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="cursor">Mongo cursor</param>
        /// <returns></returns>
        public static TDocument FirstOrDefault<TDocument>(this IAsyncCursor<TDocument> cursor)
        {
            return FirstOrDefaultAsync(cursor).Result;
        }

        /// <summary>
        /// Gets a list of all documents on the cursor
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="cursorTask">Mongo cursor task</param>
        /// <returns></returns>
        public static async Task<List<TDocument>> ToListAsync<TDocument>(this Task<IAsyncCursor<TDocument>> cursorTask)
        {
            var res = await cursorTask;
            return await res.ToListAsync();
        }

        /// <summary>
        /// Gets a list of all documents on the cursor
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="cursor">Mongo cursor</param>
        /// <returns></returns>
        public static List<TDocument> ToList<TDocument>(this IAsyncCursor<TDocument> cursor)
        {
            return cursor.ToListAsync().Result;
        }
    }
}
