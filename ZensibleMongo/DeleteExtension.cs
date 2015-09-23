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
        public static IDeleteMultiRecipe<TDocument> Delete<TDocument>(this IFilterMultiRecipe<TDocument> recipe)
        {
            return new Recipe<TDocument> { Collection = recipe.Collection, FilterRecipe = recipe };
        }

        /// <summary>
        /// Recipe for deleting a single document on the collection.
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static IDeleteSingleRecipe<TDocument> Delete<TDocument>(this IFilterSingleRecipe<TDocument> recipe)
        {
            return new DeleteSingleRecipe<TDocument>
            {
                Collection = recipe.Collection,
                FilterRecipe = recipe
            };
        }

    }
}
