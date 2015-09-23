namespace ZensibleMongo
{
    using Delete;
    using Filter;
    using Interfaces;

    /// <summary>
    /// Extention for all delete recipes
    /// </summary>
    public static class DeleteExtension
    {
        /// <summary>
        /// Recipe for deleting multiple documents on the collection.
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static DeleteRecipe<TDocument> Delete<TDocument>(this IFilterDefinition<TDocument> recipe)
        {
            return new DeleteRecipe<TDocument> { Collection = recipe.Collection, FilterDefinition = recipe };
        }

        /// <summary>
        /// Recipe for deleting a single document on the collection.
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static DeleteSingleRecipe<TDocument> Delete<TDocument>(this ForIdRecipe<TDocument> recipe)
        {
            return new DeleteSingleRecipe<TDocument>
            {
                Collection = recipe.Collection,
                FilterDefinition = recipe
            };
        }

        /// <summary>
        /// Recipe for deleting a single document on the collection.
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static DeleteSingleRecipe<TDocument> Delete<TDocument>(this ForSingleWhere<TDocument> recipe)
        {
            return new DeleteSingleRecipe<TDocument>
            {
                Collection = recipe.Collection,
                FilterDefinition = recipe
            };
        }
    }
}
