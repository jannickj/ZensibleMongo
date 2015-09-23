namespace ZensibleMongo
{
    using System;
    using System.Linq.Expressions;
    using Filter;
    using Interfaces;
    using Update;

    /// <summary>
    /// Extension for update recipes
    /// </summary>
    public static class UpdateExtension
    {
        /// <summary>
        /// Recipe for setting a field on multiple documents
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="field">Field selector</param>
        /// <param name="value">Updates field with the specificed value</param>
        /// <returns></returns>
        public static IUpdateMultiRecipe<TDocument> Set<TDocument, TField>(
            this IFilterRecipe<TDocument> recipe,
            Expression<Func<TDocument, TField>> field,
            TField value)
        {
            return new SetUpdateMultiRecipe<TDocument, TField>
            {
                Collection = recipe.Collection,
                Field = field,
                Value = value,
                FilterRecipe = recipe
            };
        }

        /// <summary>
        /// Recipe for setting a field on multiple documents
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <param name="updateMultiRecipe"></param>
        /// <param name="field">Field selector</param>
        /// <param name="value">Updates field with the specificed value</param>
        /// <returns></returns>
        public static IUpdateMultiRecipe<TDocument> Set<TDocument, TField>(
            this IUpdateMultiRecipe<TDocument> updateMultiRecipe,
            Expression<Func<TDocument, TField>> field, TField value)
        {
            return new SetUpdateMultiRecipe<TDocument, TField>
            {
                Collection = updateMultiRecipe.Collection,
                Field = field,
                Value = value,
                FilterRecipe = updateMultiRecipe.FilterRecipe
            };
        }

        /// <summary>
        /// Recipe for setting a field on a single document
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="field">Field selector</param>
        /// <param name="value">Updates field with the specificed value</param>
        /// <returns></returns>
        public static IUpdateSingleRecipe<TDocument> Set<TDocument, TField>(
            this IUpdateSingleRecipe<TDocument> recipe,
            Expression<Func<TDocument, TField>> field, TField value)
        {
            return new SetUpdateSingleRecipe<TDocument, TField>
            {
                Collection = recipe.Collection,
                Field = field,
                Value = value
            };
        }

        /// <summary>
        /// Recipe for setting a field on a single document
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="field">Field selector</param>
        /// <param name="value">Updates field with the specificed value</param>
        /// <returns></returns>
        public static IUpdateSingleRecipe<TDocument> Set<TDocument, TField>(
            this IFilterSingleRecipe<TDocument> recipe,
            Expression<Func<TDocument, TField>> field, TField value)
        {
            return new SetUpdateSingleRecipe<TDocument, TField>
            {
                Collection = recipe.Collection,
                FilterRecipe = recipe,
                Field = field,
                Value = value
            };
        }
        
    }
}
