namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;

    /// <summary>
    /// Inferface for create recipes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreateRecipe<T> : IMongoCollectionContainer<T>
    {
        


    }
}