namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;

    /// <summary>
    /// Inferface for create recipes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreateDefinition<T> : ICollectionContainer<T>
    {
        /// <summary>
        /// Immutable list of documents to create
        /// </summary>
        /// <returns></returns>
        ImmutableList<T> AllDocuments();
    }
}