namespace ZensibleMongo
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using Interfaces;
    using MongoDB.Driver;

    internal static class Factory
    {

        /// <summary>
        /// Clones a object via shallow copy
        /// </summary>
        /// <typeparam name="T">Object Type to Clone</typeparam>
        /// <param name="obj">Object to Clone</param>
        /// <returns>New Object reference</returns>
        /// http://stackoverflow.com/questions/2023210/cannot-access-protected-member-object-memberwiseclone
        internal static T CloneObject<T>(this T obj) 
        {
            if (obj == null) return default(T);
            System.Reflection.MethodInfo inst = obj.GetType().GetMethod("MemberwiseClone",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (inst != null)
                return (T)inst.Invoke(obj, null);
            else
                return default(T);
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