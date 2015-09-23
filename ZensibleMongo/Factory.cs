namespace ZensibleMongo
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using Interfaces;
    using MongoDB.Driver;
    using Newtonsoft.Json;

    internal static class Factory
    {
        /// <summary>
        ///     Perform a deep Copy of the object, using Json as a serialisation method.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        // See http://stackoverflow.com/questions/78536/deep-cloning-objects
        internal static T CloneJson<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }

        internal static FilterDefinition<T> Combine<T>(ImmutableList<FilterDefinition<T>> filters)
        {
            if (filters.IsEmpty)
            {
                return Builders<T>.Filter.Where(_ => true);
            }

            return filters.Count == 1 ? filters.First() : Builders<T>.Filter.And(filters);
        }

        internal static UpdateDefinition<T> Combine<T>(ImmutableList<UpdateDefinition<T>> updates)
        {
            return Builders<T>.Update.Combine(updates.ToArray());
        }

        internal static FilterDefinition<T> ExtractFilter<T>(IFilterRecipeContainer<T> recipe)
        {
            if (recipe.FilterRecipe == null)
            {
                throw new Exception("No Filter found");
            }

            return Combine(recipe.FilterRecipe.Filters());
        }
    }
}