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
        public static SetRecipe<TDocument, TField> Set<TDocument, TField>(
            this IFilterDefinition<TDocument> recipe,
            Expression<Func<TDocument, TField>> field,
            TField value)
        {
            return new SetRecipe<TDocument, TField>
            {
                Collection = recipe.Collection,
                Field = field,
                Value = value,
                FilterDefinition = recipe
            };
        }

        /// <summary>
        /// Recipe for setting a field on multiple documents
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <param name="recipe"></param>
        /// <param name="field">Field selector</param>
        /// <param name="value">Updates field with the specificed value</param>
        /// <returns></returns>
        public static SetRecipe<TDocument, TField> Set<TDocument, TField>(
            this SetRecipe<TDocument, TField> recipe,
            Expression<Func<TDocument, TField>> field, TField value)
        {
            return new SetRecipe<TDocument, TField>
            {
                Collection = recipe.Collection,
                Field = field,
                Value = value,
                FilterDefinition = recipe.FilterDefinition
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
        public static IUpdateSingleDefinition<TDocument> Set<TDocument, TField>(
            this IUpdateSingleDefinition<TDocument> recipe,
            Expression<Func<TDocument, TField>> field, TField value)
        {
            return new SetSingleRecipe<TDocument, TField>
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
        public static IUpdateSingleDefinition<TDocument> Set<TDocument, TField>(
            this ForIdRecipe<TDocument> recipe,
            Expression<Func<TDocument, TField>> field, TField value)
        {
            return new SetSingleRecipe<TDocument, TField>
            {
                Collection = recipe.Collection,
                FilterDefinition = recipe,
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
        public static IUpdateSingleDefinition<TDocument> Set<TDocument, TField>(
            this ForSingleWhere<TDocument> recipe,
            Expression<Func<TDocument, TField>> field, TField value)
        {
            return new SetSingleRecipe<TDocument, TField>
            {
                Collection = recipe.Collection,
                FilterDefinition = recipe,
                Field = field,
                Value = value
            };
        }
    }
}
